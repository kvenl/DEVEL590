using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEVEL590.Properties;

// Code : Kees van Engelen (keesvanengelen@gmail.com)
// 
// Version : 3 (15 feb 26); 
// Name    : The590Box Yaesu FTDX101 @ COMx


namespace The590Box
{
    public partial class MainForm : Form
    {
        #region Radio Commands — Yaesu FTDX-101 CAT
        private const string CMD_READ_MODE      = "MD;";
        private const string CMD_READ_ANT       = "AN;";
        private const string CMD_READ_PREAMP    = "PA;";
        private const string CMD_READ_MENU      = "MF;";
        private const string CMD_READ_DATA      = "DA;";
        private const string CMD_READ_RFGAIN    = "RG;";
        private const string CMD_READ_VOLUME    = "AG0;";
        private const string CMD_READ_POWER     = "PC;";
        private const string CMD_READ_SQUELCH   = "SQ0;";
        private const string CMD_READ_VFO1      = "FA;";
        private const string CMD_READ_VFO2      = "FB;";
        private const string CMD_READ_TUNER     = "AC;";

        private const string CMD_SET_TX         = "TX2;";
        private const string CMD_SET_RX         = "RX;";
        private const string CMD_SET_MODE_USB   = "MD2;";
        private const string CMD_SET_MODE_LSB   = "MD1;";
        private const string CMD_SET_MODE_CW    = "MD3;";
        private const string CMD_SET_MODE_FM    = "MD4;";
        private const string CMD_SET_MODE_AM    = "MD5;";
        private const string CMD_SET_MODE_DIG   = "MD0C;";
        private const string CMD_SET_ANT1       = "AN199;";
        private const string CMD_SET_ANT2       = "AN299;";
        private const string CMD_SET_RXANT_ON   = "AN919;";
        private const string CMD_SET_RXANT_OFF  = "AN909;";
        private const string CMD_SET_PREAMP_OFF = "PA0;";
        private const string CMD_SET_PREAMP_ON  = "PA1;";
        private const string CMD_SET_TUNER_OFF  = "AC000;";
        private const string CMD_SET_TUNER_ON   = "AC110;";
        private const string CMD_SET_TUNER_TUNE = "AC111;";
        private const string CMD_SET_MENU_A     = "MF0;";
        private const string CMD_SET_MENU_B     = "MF1;";
        private const string CMD_SET_DATA_OFF   = "DA0;";
        private const string CMD_SET_DATA_ON    = "DA1;";
        private const string CMD_SET_VOL_MUTE   = "AG0000;";
        #endregion

        public readonly SerialPort Serial_Port;
        private readonly object serialLock = new();

        // Poll timer
        private readonly System.Windows.Forms.Timer pollTimer = new();
        private int pollIndex = 0;
        private readonly string[] pollCmds =
        {
            CMD_READ_MODE,
            CMD_READ_ANT,
            CMD_READ_PREAMP,
            CMD_READ_MENU,
            CMD_READ_DATA,
            CMD_READ_RFGAIN,
            CMD_READ_VOLUME,
            CMD_READ_POWER,
            CMD_READ_SQUELCH,
            CMD_READ_VFO1,
            CMD_READ_VFO2,
            CMD_READ_TUNER,
        };

        // Slider debounce
        private readonly System.Windows.Forms.Timer sliderDebounceTimer = new();
        private readonly Dictionary<TrackBar, string> pendingSliderCommands = new();

        // Radio update flag
        private bool isUpdatingFromRadio = false;

        public string mode, temp, Data,DataB, DATABD, Dspant, DspantD,
             FColorB, Pstr, Mode, ModeD,Dspipo, DspipoD, SButton, DScopspan, Bar = "";
        public decimal  Dsppodnum, SecondNum;

        // Add a field to track the RX antenna state
        private bool rxAntennaOn = false;
        private bool dataOn = false; // Tracks the current DATA state
        private bool menuA = true; // Tracks the current MENU state
  //      private bool isRxAntennaOff = false;
        private bool muted = false;
        private int savedVolume = 0;
        public MainForm()
        {
            InitializeComponent();
            InitializeTrackBarEvents();

            // Make form fixed size (non-resizable)
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Restore position before showing the form
            RestoreWindowPosition();

            string portName = SelectSerialPort();

            // Update form title with selected COM port
            this.Text = $"The590Box v 3 - by Kees, ON9KVE - {portName}";

            Serial_Port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
            {
                Handshake    = Handshake.None,
                RtsEnable    = true,
                DtrEnable    = true,
                ReadTimeout  = 500,
                WriteTimeout = 500
            };

            // Open the serial port on a background thread so UI initialization isn't blocked.
            ExtTuneButton.Enabled = false;

            Task.Run(() =>
            {
                try
                {
                    Serial_Port.Open();
                    ReadRadioStatus();
                    if (IsHandleCreated)
                        Invoke((Action)(() =>
                        {
                            ExtTuneButton.Enabled = true;
                            ExtTuneButton.ForeColor = Color.Yellow;
                            pollTimer.Start();
                        }));
                }
                catch (Exception ex)
                {
                    if (IsHandleCreated)
                        Invoke((Action)(() =>
                            MessageBox.Show(this, "Failed to open serial port: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                }
            });
        }

        private void InitializeTrackBarEvents()
        {
            // Timers
            pollTimer.Interval         = 80;
            pollTimer.Tick            += PollTimer_Tick;
            sliderDebounceTimer.Interval = 150;
            sliderDebounceTimer.Tick  += SliderDebounceTimer_Tick;

            // Form
            this.FormClosing += MainForm_FormClosing;

            // ExtTuner button appearance + events
            ExtTuneButton.BackColor                        = Color.DarkGreen;
            ExtTuneButton.ForeColor                        = Color.Yellow;
            ExtTuneButton.FlatAppearance.BorderSize        = 0;
            ExtTuneButton.FlatAppearance.MouseDownBackColor = Color.Red;
            ExtTuneButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            ExtTuneButton.FlatAppearance.BorderColor       = Color.White;
            ExtTuneButton.MouseDown  += TuneButton_MouseDown;
            ExtTuneButton.MouseUp    += TuneButton_MouseUp;
            ExtTuneButton.MouseEnter += TuneButton_MouseEnter;
            ExtTuneButton.MouseLeave += TuneButton_MouseLeave;
            ExtTuneButton.Paint      += TuneButton_Paint;

            // Mode buttons
            USBB.MouseClick  += USB_click;
            LSBB.MouseClick  += LSB_click;
            CWB.MouseClick   += CW_click;
            AMB.MouseClick   += AM_click;
            FMB.MouseClick   += FM_click;
            DIGB.MouseClick  += DIGB_click;

            // Antenna buttons
            ANT1B.MouseClick   += ANT1B_click;
            ANT2B.MouseClick   += ANT2B_click;
            ANT3RXB.MouseClick += ANT3RXB_click;

            // Preamp buttons
            PREoff.MouseClick += PREoff_click;
            PROon.MouseClick  += PROon_click;

            // Tuner buttons
            IntTune.Click  += IntTune_Click;
            ItuneOn.Click  += ItuneOn_Click;
            ItuneOff.Click += ItuneOff_Click;

            // Menu + Mute
            MENU.MouseClick += MENU_click;
            MUTE.Click      += MuteButton_Click;

            // Sliders
            rfGainTrackBar.ValueChanged      += RfGainTrackBar_ValueChanged;
            volumeGainTrackBar.ValueChanged  += VolumeGainTrackBar_ValueChanged;
            pwrControlTrackBar.ValueChanged  += PwrControlTrackBar_ValueChanged;
            SQLtrackBar.ValueChanged         += SQLtrackBar_ValueChanged;
        }

        private void UpdateTextBox(TextBox tb, string text, Color? foreColor = null)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(() => UpdateTextBox(tb, text, foreColor));
            }
            else
            {
                tb.Text = text;
                if (foreColor.HasValue) tb.ForeColor = foreColor.Value;
            }
        }

        #region ParseXxx response helpers
        private void ParseMode(string r)
        {
            string d = r.Length >= 3
                ? r[2] switch { '1' => "LSB", '2' => "USB", '3' => "CW", '4' => "FM", '5' => "AM", _ => "???" }
                : "???";
            UpdateTextBox(MODE_box, d);
        }

        private void ParseAnt(string r)
        {
            string d = "???";
            if (r.Length >= 4)
            {
                string x = r.Substring(2, 1), y = r.Substring(3, 1);
                d = y == "1" ? "RX ANT" : x switch { "1" => "ANT 1", "2" => "ANT 2", _ => "???" };
            }
            UpdateTextBox(ANT_box, d);
        }

        private void ParsePreamp(string r)
        {
            string d = r.Length >= 3
                ? r[2] switch { '0' => "AMP off", '1' => "AMP on", _ => "???" }
                : "???";
            UpdateTextBox(IPO_box, d);
        }

        private void ParseMenu(string r)
        {
            if (r.Length < 3) return;
            menuA = r[2] == '0';
            if (MENU.InvokeRequired) MENU.BeginInvoke((Action)UpdateMenuButtonAppearance);
            else UpdateMenuButtonAppearance();
        }

        private void ParseData(string r)
        {
            if (r.Length < 3) return;
            dataOn = r[2] == '1';
            SetButtonActive(DIGB, dataOn);
        }

        private void ParseRfGain(string r)
        {
            if (r.Length >= 5 && r.StartsWith("RG") && int.TryParse(r.Substring(2, 3), out int v))
            {
                int slider = 255 - Math.Clamp(v, 0, 255);
                isUpdatingFromRadio = true;
                rfGainTrackBar.Value = Math.Clamp(slider, rfGainTrackBar.Minimum, rfGainTrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(textBox1, slider.ToString("D3"));
            }
        }

        private void ParseVolume(string r)
        {
            if (r.Length >= 6 && int.TryParse(r.Substring(3, 3), out int v))
            {
                isUpdatingFromRadio = true;
                volumeGainTrackBar.Value = Math.Clamp(v, volumeGainTrackBar.Minimum, volumeGainTrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(textBox2, v.ToString("D3"));
            }
        }

        private void ParsePower(string r)
        {
            if (r.Length >= 5 && int.TryParse(r.Substring(2, 3), out int v))
            {
                isUpdatingFromRadio = true;
                pwrControlTrackBar.Value = Math.Clamp(v, pwrControlTrackBar.Minimum, pwrControlTrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(textBox3, v.ToString("D3"));
            }
        }

        private void ParseSquelch(string r)
        {
            if (r.Length >= 6 && int.TryParse(r.Substring(3, 3), out int v))
            {
                isUpdatingFromRadio = true;
                SQLtrackBar.Value = Math.Clamp(v, SQLtrackBar.Minimum, SQLtrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(SQLTextBox, v.ToString("D3"));
            }
        }

        private void ParseVfo1(string r)
        {
            string d = (r.Length >= 3 && long.TryParse(r.Substring(2, r.Length - 3), out long hz))
                ? $"{hz / 100000.0,9:F3}" : "???";
            UpdateTextBox(VFO1_box, $"VFO1:{d} MHz");
        }

        private void ParseVfo2(string r)
        {
            string d = (r.Length >= 3 && long.TryParse(r.Substring(2, r.Length - 3), out long hz))
                ? $"{hz / 100000.0,9:F3}" : "???";
            UpdateTextBox(VFO2_box, $"VFO2:{d} MHz");
        }

        private void ParseTuner(string r)
        {
            if (r.Length < 4) { UpdateTextBox(textBox4, "      "); return; }
            string x = r.Substring(2, 1), y = r.Substring(3, 1);
            string d = (x == "1" || y == "1")
                ? (x == "1" ? "R" : " ") + "<AT>" + (y == "1" ? "T" : " ")
                : "      ";
            UpdateTextBox(textBox4, d);
        }
        #endregion

        private void SetButtonActive(Button btn, bool active)
        {
            if (btn.InvokeRequired) { btn.BeginInvoke((Action)(() => SetButtonActive(btn, active))); return; }
            btn.BackColor = active ? Color.DarkRed : Color.DarkGreen;
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (!Serial_Port.IsOpen) return;
            string cmd = pollCmds[pollIndex];
            pollIndex = (pollIndex + 1) % pollCmds.Length;
            string response;
            try
            {
                lock (serialLock)
                {
                    Serial_Port.DiscardInBuffer();
                    Serial_Port.Write(cmd);
                    Thread.Sleep(6);
                    response = Serial_Port.ReadTo(";");
                }
            }
            catch { return; }

            if      (cmd == CMD_READ_MODE)    ParseMode(response);
            else if (cmd == CMD_READ_ANT)     ParseAnt(response);
            else if (cmd == CMD_READ_PREAMP)  ParsePreamp(response);
            else if (cmd == CMD_READ_MENU)    ParseMenu(response);
            else if (cmd == CMD_READ_DATA)    ParseData(response);
            else if (cmd == CMD_READ_RFGAIN)  ParseRfGain(response);
            else if (cmd == CMD_READ_VOLUME)  ParseVolume(response);
            else if (cmd == CMD_READ_POWER)   ParsePower(response);
            else if (cmd == CMD_READ_SQUELCH) ParseSquelch(response);
            else if (cmd == CMD_READ_VFO1)    ParseVfo1(response);
            else if (cmd == CMD_READ_VFO2)    ParseVfo2(response);
            else if (cmd == CMD_READ_TUNER)   ParseTuner(response);

            string blok = "█";
            UpdateTextBox(BUSY_box, BUSY_box.Text == blok ? " " : blok);
        }

        private void SliderDebounceTimer_Tick(object sender, EventArgs e)
        {
            sliderDebounceTimer.Stop();
            foreach (var kvp in pendingSliderCommands)
                IssueCmd(kvp.Value);
            pendingSliderCommands.Clear();
        }

        private void ReadRadioStatus()
        {
            foreach (string cmd in pollCmds)
            {
                if (!Serial_Port.IsOpen) return;
                IssueCmd(cmd);
                Thread.Sleep(80);
            }
        }

        private void IssueCmd(string cmd)
        {
            try
            {
                lock (serialLock)
                {
                    Serial_Port.Write(cmd);
                    Thread.Sleep(6);
                }
            }
            catch (Exception ex)
            {
                string msg = $"Failed to send command: {ex.Message}";
                if (InvokeRequired)
                    BeginInvoke((Action)(() =>
                        MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                else
                    MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TuneButton_MouseDown(object sender, MouseEventArgs e)
        {
            IssueCmd(CMD_SET_TX);
        }
        private void TuneButton_MouseUp(object sender, MouseEventArgs e)
        {
            IssueCmd(CMD_SET_RX);
        }
        private void USB_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_MODE_USB); }
        private void LSB_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_MODE_LSB); }
        private void CW_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_MODE_CW); }
        private void FM_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_MODE_FM); }
        private void AM_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_MODE_AM); }
        private void DIG_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_MODE_DIG); }

        private void ANT1B_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_ANT1); }   //ANT1 on, ANT2 off
        private void ANT2B_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_ANT2); }   //ANT2 on, ANT1 off



        private void PREoff_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_PREAMP_OFF); } // AMP off

        private void PROon_click(object sender, MouseEventArgs e) { IssueCmd(CMD_SET_PREAMP_ON); } // AMP on


        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

        // --- External Tuner color change handlers ---
        private void TuneButton_MouseEnter(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.Blue; }
        private void TuneButton_MouseLeave(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.DarkGreen; }
        private void TuneButton_Paint(object sender, PaintEventArgs e)
        {
            var btn = sender as System.Windows.Forms.Button;
            if (btn == null) return;
            int thickness = 3;
            using (var pen = new Pen(Color.White, thickness))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, btn.Width - thickness, btn.Height - thickness));
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var cb = (ComboBox)sender;
            bool selected = (e.State & DrawItemState.Selected) != 0;
            using var bgBrush = new SolidBrush(selected ? Color.Green : Color.DarkGreen);
            using var fgBrush = new SolidBrush(cb.ForeColor);
            e.Graphics.FillRectangle(bgBrush, e.Bounds);
            e.Graphics.DrawString(cb.Items[e.Index]?.ToString(), e.Font, fgBrush, e.Bounds);
        }


        private void RfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = rfGainTrackBar.Value;
            UpdateTextBox(textBox1, v.ToString("D3"));
            pendingSliderCommands[rfGainTrackBar] = $"RG{(rfGainTrackBar.Maximum - v):D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void VolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = volumeGainTrackBar.Value;
            UpdateTextBox(textBox2, v.ToString("D3"));
            pendingSliderCommands[volumeGainTrackBar] = $"AG0{v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void PwrControlTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = pwrControlTrackBar.Value;
            UpdateTextBox(textBox3, v.ToString("D3"));
            pendingSliderCommands[pwrControlTrackBar] = $"PC{v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void SQLtrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = SQLtrackBar.Value;
            UpdateTextBox(SQLTextBox, v.ToString("D3"));
            pendingSliderCommands[SQLtrackBar] = $"SQ0{v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }


        private void IntTune_Click(object sender, EventArgs e)
        {
            IssueCmd(CMD_SET_TUNER_TUNE); // Start tuning

        }

        private void ItuneOn_Click(object sender, EventArgs e)
        {
            IssueCmd(CMD_SET_TUNER_ON); // Turn internal tuner ON
        }

        private void ItuneOff_Click(object sender, EventArgs e)
        {
            IssueCmd(CMD_SET_TUNER_OFF); // Turn internal tuner OFF
        }
        private string SelectSerialPort()
        {
            try
            {
                string[] allPorts = SerialPort.GetPortNames();
                
                // Filter to COM0-COM20
                string[] ports = allPorts
                    .Where(p => p.StartsWith("COM") && int.TryParse(p.Substring(3), out int portNum) && portNum >= 0 && portNum <= 20)
                    .OrderBy(p => int.Parse(p.Substring(3)))
                    .ToArray();
                
                if (ports.Length == 0)
                {
                    MessageBox.Show("No serial ports (COM0-COM20) found!", "The590Box - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "COM4";
                }
                
                if (ports.Length == 1)
                {
                    string selectedPort = ports[0];
                    Settings.Default.LastPort = selectedPort;
                    Settings.Default.Save();
                    MessageBox.Show($"Using port: {selectedPort}", "The590Box - Serial Port", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return selectedPort;
                }
                
                // Multiple ports - ALWAYS show selection dialog
                using (var form = new Form())
                {
                    form.Text = "The590Box - Select Serial Port";  // Changed this line
                    form.Width = 250;
                    form.Height = 150;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MaximizeBox = false;
                    form.MinimizeBox = false;
                    
                    var label = new Label 
                    { 
                        Text = "Available Ports (COM0-COM20):", 
                        Dock = DockStyle.Top, 
                        Height = 25, 
                        Padding = new Padding(10, 5, 10, 0)
                    };
                    
                    var combo = new ComboBox
                    {
                        Dock = DockStyle.Top,
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Height = 30,
                        DrawMode = DrawMode.OwnerDrawFixed,
                        BackColor = Color.DarkGreen,
                        ForeColor = Color.Yellow
                    };
                    combo.DrawItem += ComboBox_DrawItem;

                    // Add items directly instead of using DataSource
                    combo.Items.AddRange(ports);

                    // Pre-select the saved port
                    string savedPort = Settings.Default.LastPort;
                    int savedIndex = System.Array.IndexOf(ports, savedPort);
                    
                    if (savedIndex >= 0)
                    {
                        combo.SelectedIndex = savedIndex;
                    }
                    else
                    {
                        combo.SelectedIndex = 0;
                    }
                    
                    var btnOK = new Button 
                    { 
                        Text = "OK", 
                        Dock = DockStyle.Bottom,
                        Height = 40,
                        DialogResult = DialogResult.OK
                    };
                    
                    form.Controls.Add(btnOK);
                    form.Controls.Add(combo);
                    form.Controls.Add(label);
                    form.AcceptButton = btnOK;
                    
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPort = (string)combo.SelectedItem;
                        Settings.Default.LastPort = selectedPort;
                        Settings.Default.Save();
                        return selectedPort;
                    }
                    
                    return "COM4";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "The590Box - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "COM4";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowPosition();
            pollTimer.Stop();
            sliderDebounceTimer.Stop();
            if (Serial_Port?.IsOpen == true)
                Serial_Port.Close();
        }

        private void ANT3RXB_click(object sender, MouseEventArgs e)
        {
            rxAntennaOn = !rxAntennaOn;
            IssueCmd(rxAntennaOn ? CMD_SET_RXANT_ON : CMD_SET_RXANT_OFF);
            SetButtonActive(ANT3RXB, rxAntennaOn);
        }

        private void DIGB_click(object sender, MouseEventArgs e)
        {
            IssueCmd(dataOn ? CMD_SET_DATA_OFF : CMD_SET_DATA_ON);
            IssueCmd(CMD_READ_DATA); // ParseData() confirms and calls SetButtonActive
        }

        private void MENU_click(object sender, MouseEventArgs e)
        {
            if (menuA)
            {
                IssueCmd(CMD_SET_MENU_B); // Switch to Menu B
                menuA = false;
            }
            else
            {
                IssueCmd(CMD_SET_MENU_A); // Switch to Menu A
                menuA = true;
            }
            UpdateMenuButtonAppearance();
        }

        private void UpdateMenuButtonAppearance()
        {
            if (menuA)
            {
                MENU.Text = "MENU A";
                MENU.BackColor = Color.LimeGreen; // Light green
            }
            else
            {
                MENU.Text = "MENU B";
                MENU.BackColor = Color.FromArgb(255, 165, 0); // Amber color
            }
        }

        private void MuteButton_Click(object sender, EventArgs e)
        {
            if (muted)
            {
                int vol = savedVolume;
                Task.Run(() => { IssueCmd($"AG0{vol:D3};"); Thread.Sleep(60); });
                SetButtonActive(MUTE, false);
                muted = false;
            }
            else
            {
                savedVolume = volumeGainTrackBar.Value;
                Task.Run(() => { IssueCmd(CMD_SET_VOL_MUTE); Thread.Sleep(60); });
                SetButtonActive(MUTE, true);
                muted = true;
            }
        }

        // Add this method to save window position
        private void SaveWindowPosition()
        {
            // Only save position, not size (since form is now fixed-size)
            Settings.Default.WindowLeft = this.Left;
            Settings.Default.WindowTop = this.Top;
            Settings.Default.IsPositionSaved = true; // Mark that we have saved a position
            Settings.Default.Save();
        }

        // Add this method to restore window position
        private void RestoreWindowPosition()
        {
            // Check if a position has ever been saved. This is more reliable than checking coordinates.
            if (!Settings.Default.IsPositionSaved)
            {
                // If not, this is the first run, so center the form.
                this.StartPosition = FormStartPosition.CenterScreen;
                return;
            }

            // Create a rectangle with the saved position and current (fixed) size
            var savedBounds = new Rectangle(Settings.Default.WindowLeft, Settings.Default.WindowTop, this.Width, this.Height);

            // Check if the saved position is visible on any of the connected screens
            bool isVisible = Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(savedBounds));

            if (isVisible)
            {
                // If it's visible, move the form to the saved location
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(Settings.Default.WindowLeft, Settings.Default.WindowTop);
            }
            else
            {
                // If not (e.g., the monitor was disconnected), center the form to prevent it from opening off-screen
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }
    }
}