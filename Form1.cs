using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// Code : Kees van Engelen (keesvanengelen@gmail.com)
// 
// Version : 16-x (09 feb 26); 
// Name    : The101Box Yaesu FTDX101 @ COMx


namespace The590Box
{
    public partial class MainForm : Form
    {
        public readonly SerialPort Serial_Port;
        public string temp, mode, Rfsql, Dspmod, Dspspan, RfsqlD,
            DspmodD, DspspanD, FColorB, Ptemp, Pstr, Mode, ModeD, Dspant, DspantD, Dspipo, DspipoD, DspRx, DspRxD, SButton, DScopspan, Bar = "";
        public decimal TempD, tempnum, Rfsqlnum, Dsppodnum, SecondNum;

        private CancellationTokenSource cts = new();
        private bool rfSqlOn = false; // false for RF, true for Squelch

        public MainForm()
        {
            InitializeComponent();

            // Wire up the FormClosing event handler
            this.FormClosing += MainForm_FormClosing;

            // Attach event handlers for sliders
            rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
            volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;

            // Ensure External Tuner button uses Flat style for color changes
            ExtTuneButton.FlatStyle = FlatStyle.Flat;
            ExtTuneButton.BackColor = Color.DarkGreen;
            ExtTuneButton.ForeColor = Color.Yellow;
            ExtTuneButton.FlatAppearance.BorderSize = 0;
            ExtTuneButton.FlatAppearance.MouseDownBackColor = Color.Red;
            ExtTuneButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.Paint += TuneButton_Paint;

            string portName = SelectSerialPort();
            
            // Update form title with selected COM port
            this.Text = $"The101Box v 16 - by Kees, ON9KVE - {portName}";
            
            Serial_Port = new SerialPort(portName, 38400, Parity.None, 8, StopBits.Two)
            {
                Handshake = Handshake.None,
                RtsEnable = true,
                ReadTimeout = 5000
            };

            // Open the serial port on a background thread so UI initialization isn't blocked.
            // Enable UI controls only after the port is opened successfully.
            ExtTuneButton.Enabled = false;

            Task.Run(async () =>
            {
                try
                {
                    Serial_Port.Open();

                    // enable UI controls on the UI thread after port opens
                    if (IsHandleCreated)
                    {
                        Invoke((Action)(() =>
                        {
                            ExtTuneButton.Enabled = true;
                            ExtTuneButton.ForeColor = Color.Yellow;
                        }));
                    }

                    // start the main loop after the port is open
                    await DoThisLoopAsync();
                }
                catch (Exception ex)
                {
                    if (IsHandleCreated)
                    {
                        Invoke((Action)(() => MessageBox.Show(this, "Failed to open serial port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    }
                }
            });
        }

        private async Task DoThisLoopAsync()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    // Discard buffers at the start of each loop to prevent stale data
                    Serial_Port.DiscardInBuffer();
                    Serial_Port.DiscardOutBuffer();

                    IssueCmd("RM9;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 6)
                    {
                        Ptemp = temp.Substring(3, 3);
                        tempnum = Convert.ToDecimal(Ptemp);
                        TempD = Decimal.Floor((tempnum / 2.3M) - 6);
                    }
                    else
                    {
                        TempD = 0;
                    }

                    if (TempD > 40)
                    {
                        FColorB = "Red";
                        Console.Beep(3000, 1000);
                    }
                    else if (TempD > 33)
                    {
                        FColorB = "Orange";
                    }
                    else
                    {
                        FColorB = "Cyan";
                    }

                    IssueCmd("EX030107;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 9)
                    {
                        Rfsql = temp.Substring(8, 1);
                        RfsqlD = Rfsql == "0" ? "RF" : "Squelch";
                    }
                    else
                    {
                        RfsqlD = "RF";
                    }


                    IssueCmd("SS06;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        Dspmod = temp.Substring(4, 1);
                        DspmodD = Dspmod switch
                        {
                            "8" => "CURSOR",
                            "5" => "CENTER",
                            _ => "FIX"
                        };
                    }
                    else
                    {
                        DspmodD = "FIX";
                    }

                    IssueCmd("SS05;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        Dspspan = temp.Substring(4, 1);
                        DspspanD = Dspspan switch
                        {
                            "9" => "1 M",
                            "4" => "20k",
                            "5" => "50k", 
                            "6" => "100k",
                            "7" => "200k",
                            "8" => "500k",
                            _ => "*OTHER*"
                        };
                    }
                    else
                    {
                        DspspanD = "*OTHER*";
                    }

                    IssueCmd("MD0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Mode = temp.Substring(3, 1);
                        ModeD = Mode switch
                        {
                            "1" => "LSB",
                            "2" => "USB",
                            "3" => "CW",
                            "4" => "FM",
                            "5" => "AM",
                            "C" => "DIG-U",
                            _ => "???",
                        };
                    }
                    else
                    {
                        ModeD = "???";
                    }

                    IssueCmd("AN0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Dspant = temp.Substring(3, 1);
                        DspantD = Dspant switch
                        {
                            "1" => "ANT1",
                            "2" => "ANT2",
                            "3" => "ANT3/RX",
                            _ => "???"
                        };
                    }
                    else
                    {
                        DspantD = "???";
                    }

                    IssueCmd("PA0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Dspipo = temp.Substring(3, 1);
                        DspipoD = Dspipo switch
                        {
                            "0" => "IPO",
                            "1" => "AMP1",
                            "2" => "AMP2",
                            _ => "???"
                        };
                    }
                    else
                    {
                        DspipoD = "???";
                    }

                    IssueCmd("FR;");
                    temp = Serial_Port.ReadTo(";");
                    DspRx = temp;
                    DspRxD = DspRx switch
                    {
                        "FR01" => "RX 1",
                        "FR10" => "RX 2",
                        "FR00" => "RX 1 + 2",
                        "FR11" => "RXs off",
                        _ => "???"
                    };

                    string Blokje = "█";
                    Bar = (Bar == Blokje) ? " " : Blokje;

                    // Update UI
                    UpdateTextBox(TEMP_box, $"{TempD:00}°C", Color.FromName(FColorB));
                    UpdateTextBox(RFSQL_box, RfsqlD);
                    UpdateTextBox(DSPMOD_box, DspmodD);
                    UpdateTextBox(DSPSPAN_box, DspspanD);
                    UpdateTextBox(MODE_box, ModeD);
                    UpdateTextBox(ANT_box, DspantD);
                    UpdateTextBox(IPO_box, DspipoD);
                    UpdateTextBox(RX_box, DspRxD);
                    UpdateTextBox(BUSY_box, Bar);


                    // Sync sliders with radio values
                    // Detach event handlers to prevent sending commands when setting values
                    rfGainTrackBar.ValueChanged -= RfGainTrackBar_ValueChanged;
                    volumeGainTrackBar.ValueChanged -= VolumeGainTrackBar_ValueChanged;
                    pwrControlTrackBar.ValueChanged -= PwrControlTrackBar_ValueChanged;

                    // Read and set RF gain slider
                    IssueCmd("RG0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string rgValueStr = temp.Substring(3, 3); // Extract the RF gain value
                        if (int.TryParse(rgValueStr, out int rgValue))
                        {
                            int sliderValue = rfGainTrackBar.Maximum - rgValue; // Invert the value for the slider
                            rfGainTrackBar.Value = Math.Max(rfGainTrackBar.Minimum, Math.Min(rfGainTrackBar.Maximum, sliderValue));
                            UpdateTextBox(textBox1, sliderValue.ToString("D3")); // Display the slider value in textBox1
                        }
                    }

                    // Read and set volume slider
                    IssueCmd("AG0;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string agValueStr = temp.Substring(3, 3);
                        if (int.TryParse(agValueStr, out int agValue))
                        {
                            volumeGainTrackBar.Value = Math.Max(volumeGainTrackBar.Minimum, Math.Min(volumeGainTrackBar.Maximum, agValue));
                            UpdateTextBox(textBox2, agValueStr); // Display the Volume gain value in TextBox2
                        }
                    }

                    // Read and set power slider
                    IssueCmd("PC;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string pcValueStr = temp.Substring(2, 3); // Extract the power value
                        if (int.TryParse(pcValueStr, out int pcValue))
                        {
                            pwrControlTrackBar.Value = Math.Max(pwrControlTrackBar.Minimum, Math.Min(pwrControlTrackBar.Maximum, pcValue));
                            UpdateTextBox(textBox3, pcValue.ToString("D3")); // Display the power value in textBox3
                        }
                    }

                    // Reattach event handlers
                    rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
                    volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;
                    pwrControlTrackBar.ValueChanged += PwrControlTrackBar_ValueChanged;

                    // Read and set Sub RF gain slider
                    IssueCmd("RG1;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string rgValueStr = temp.Substring(3, 3); // Extract the Sub RF gain value
                        if (int.TryParse(rgValueStr, out int rgValue))
                        {
                            int sliderValue = SubrfGainTrackBar.Maximum - rgValue; // Invert the value for the slider
                            SubrfGainTrackBar.Value = Math.Max(SubrfGainTrackBar.Minimum, Math.Min(SubrfGainTrackBar.Maximum, sliderValue));
                            UpdateTextBox(textBox5, sliderValue.ToString("D3")); // Display the slider value in textBox5
                        }
                    }

                    // Read and set Sub volume slider
                    IssueCmd("AG1;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string agValueStr = temp.Substring(3, 3);
                        if (int.TryParse(agValueStr, out int agValue))
                        {
                            SubvolumeGainTrackBar.Value = Math.Max(SubvolumeGainTrackBar.Minimum, Math.Min(SubvolumeGainTrackBar.Maximum, agValue));
                            UpdateTextBox(textBox6, agValueStr); // Display the Sub volume value in textBox6
                        }
                    }

                    IssueCmd("FA;");
                    temp = Serial_Port.ReadTo(";");
                    string mainFreq = "???";
                    if (temp.Length >= 4) // FA + at least 1 digit + ;
                    {
                        string freqStr = temp.Substring(2, temp.Length - 3); // Extract digits between FA and ;
                        if (long.TryParse(freqStr, out long freqHz))
                        {
                            double freqMHz = freqHz / 100000.0; // Correct divisor for this radio
                            mainFreq = $"{freqMHz,9:F3}"; // Right-align in 9 characters with 3 decimals
                        }
                    }

                    IssueCmd("FB;");
                    temp = Serial_Port.ReadTo(";");
                    string subFreq = "???";
                    if (temp.Length >= 4) // FB + at least 1 digit + ;
                    {
                        string freqStr = temp.Substring(2, temp.Length - 3); // Extract digits between FB and ;
                        if (long.TryParse(freqStr, out long freqHz))
                        {
                            double freqMHz = freqHz / 100000.0; // Correct divisor for this radio
                            subFreq = $"{freqMHz,9:F3}"; // Right-align in 9 characters with 3 decimals
                        }
                    }

                    UpdateTextBox(FreqM_box, $"MAIN:{mainFreq} MHz");
                    UpdateTextBox(FreqS_box, $"SUB :{subFreq} MHz");

                    await Task.Delay(100, cts.Token);
                }
                catch (Exception ex)
                {
                    string errorMsg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Loop error: {ex.Message}";
                    try
                    {
                        File.AppendAllText(logFilePath, errorMsg + Environment.NewLine);
                    }
                    catch
                    {
                        // If logging fails, silently ignore to avoid cascading errors
                    }
                    await Task.Delay(100, cts.Token); // Reduced delay on error to retry faster
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UpdateTextBox(TEMP_box, " ");
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

        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void TextBox2_TextChanged(object sender, EventArgs e) { }

        private void IssueCmd(string cmd)
        {
            Serial_Port.Write(cmd);
            Thread.Sleep(6); // Increased to 60 ms to match other working programs' timing
        }

        private void RFB_click(object sender, MouseEventArgs e)
        {
            rfSqlOn = !rfSqlOn;
            if (rfSqlOn)
            {
                IssueCmd("EX0301071;"); // Squelch
                RFSQL_box.Text = "Squelch";
            }
            else
            {
                IssueCmd("EX0301070;"); // RF
                RFSQL_box.Text = "RF";
            }
        }
        private void TuneButton_MouseDown(object sender, MouseEventArgs e)
        {
            IssueCmd("MD0;");
            mode = Serial_Port.ReadTo(";");
            IssueCmd("PC;");
            string resp = Serial_Port.ReadTo(";");
            Pstr = resp[2..];
            IssueCmd("PC010;");
            IssueCmd("MD05;");
            IssueCmd("MX1;");
        }
        private void TuneButton_MouseUp(object sender, MouseEventArgs e)
        {
            IssueCmd("MX0;");
            string cmd = mode + ";";
            IssueCmd(cmd);
            cmd = "PC" + Pstr + ";";
            IssueCmd(cmd);
        }
        private void Center_Click(object sender, MouseEventArgs e) { IssueCmd("SS0650000;"); }
        private void Cursor_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");
            IssueCmd("SS0680000;");
        }
        private void Fix_Click(object sender, MouseEventArgs e)
        {
            IssueCmd("SS0650000;");
            IssueCmd("SS06B0000;");
        }
        private void USB_click(object sender, MouseEventArgs e) { IssueCmd("MD02;"); }
        private void LSB_click(object sender, MouseEventArgs e) { IssueCmd("MD01;"); }
        private void CW_click(object sender, MouseEventArgs e) { IssueCmd("MD03;"); }
        private void FM_click(object sender, MouseEventArgs e) { IssueCmd("MD04;"); }
        private void AM_click(object sender, MouseEventArgs e) { IssueCmd("MD05;"); }
        private void DIG_click(object sender, MouseEventArgs e) { IssueCmd("MD0C;"); }



        private void ANT1B_click(object sender, MouseEventArgs e) { IssueCmd("AN01;"); }
        private void ANT2B_click(object sender, MouseEventArgs e) { IssueCmd("AN02;"); }
        private void ANT3RXB_click(object sender, MouseEventArgs e) { IssueCmd("AN03;"); }
        private void IPOB_click(object sender, MouseEventArgs e) { IssueCmd("PA00;"); }
        private void AMP1B_click(object sender, MouseEventArgs e) { IssueCmd("PA01;"); }
        private void AMP2B_click(object sender, MouseEventArgs e) { IssueCmd("PA02;"); }
        private void RX1B_click(object sender, MouseEventArgs e) { IssueCmd("FR01;"); }
        private void RX2B_click(object sender, MouseEventArgs e) { IssueCmd("FR10;"); }
        private void RX12B_click(object sender, MouseEventArgs e) { IssueCmd("FR00;"); }
        private void RX12B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) IssueCmd("FR11;");
        }
        private void RX12off_click(object sender, MouseEventArgs e) { IssueCmd("FR11;"); }
        private void SSB1_click(object sender, EventArgs e) { IssueCmd("SS0560000;"); }
        private void SSB2_click(object sender, EventArgs e) { IssueCmd("SS0570000;"); }
        private void SSB3_click(object sender, EventArgs e) { IssueCmd("SS0580000;"); }
        private void SSB4_click(object sender, EventArgs e) { IssueCmd("SS0590000;"); }
        private void SSB5_click(object sender, EventArgs e) { IssueCmd("SS0540000;"); }
        private void SSB6_click(object sender, EventArgs e) { IssueCmd("SS0550000;"); }


        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void RX_box_TextChanged(object sender, EventArgs e) { }
        private void FixB_Click(object sender, EventArgs e) { }

        // --- External Tuner color change handlers ---
        private void TuneButton_MouseEnter(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.Blue; }
        private void TuneButton_MouseLeave(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.DarkGreen; }
        private void TuneButton_MouseDown_Color(object sender, MouseEventArgs e) { ExtTuneButton.BackColor = Color.Red; }
        private void TuneButton_MouseUp_Color(object sender, MouseEventArgs e)
        {
            if (ExtTuneButton.ClientRectangle.Contains(ExtTuneButton.PointToClient(Cursor.Position)))
                ExtTuneButton.BackColor = Color.Blue;
            else
                ExtTuneButton.BackColor = Color.DarkGreen;
        }
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

        private void RFB_click_1(object sender, MouseEventArgs e)
        {
            rfSqlOn = !rfSqlOn;
            if (rfSqlOn)
            {
                IssueCmd("EX0301071;"); // Squelch
                RFSQL_box.Text = "Squelch";
            }
            else
            {
                IssueCmd("EX0301070;"); // RF
                RFSQL_box.Text = "RF";
            }
        }

        private void RfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int displayedValue = rfGainTrackBar.Value; // Directly use the slider value for display
            string value = displayedValue.ToString("D3");
            UpdateTextBox(textBox1, value); // Display the value in textBox1
            IssueCmd($"RG0{(rfGainTrackBar.Maximum - displayedValue):D3};"); // Send inverted value to the radio
        }

        private void VolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            string value = ((TrackBar)sender).Value.ToString("D3");
            IssueCmd($"AG0{value};");
        }

        private void PwrControlTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int displayedValue = pwrControlTrackBar.Value; // Get slider value
            string value = displayedValue.ToString("D3"); // Format as 3 digits
            UpdateTextBox(textBox3, value); // Update the display
            IssueCmd($"PC{value};"); // Send the power control command
        }

        private void rfGainTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void SubrfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int displayedValue = SubrfGainTrackBar.Value; // Directly use the slider value for display
            string value = displayedValue.ToString("D3");
            UpdateTextBox(textBox5, value); // Display the value in textBox5
            IssueCmd($"RG1{(SubrfGainTrackBar.Maximum - displayedValue):D3};"); // Send inverted value to the radio
        }

        private void SubvolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            string value = ((TrackBar)sender).Value.ToString("D3");
            UpdateTextBox(textBox5, value); // Display the value in textBox5
            IssueCmd($"AG1{value};"); // Send the command with '1' as the third character
        }

        private void IntTune_Click(object sender, EventArgs e)
        {
            IssueCmd("AC002;"); // Start tuning
            IssueCmd("AC001;"); // Set tuning on 

        }

        private void ItuneOn_Click(object sender, EventArgs e)
        {
            IssueCmd("AC001;"); // Turn internal tuner ON
        }

        private void ItuneOff_Click(object sender, EventArgs e)
        {
            IssueCmd("AC000;"); // Turn internal tuner OFF
        }
        private void SWAP_Click(object sender, EventArgs e)
        {
            IssueCmd("SV;");
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
                    MessageBox.Show("No serial ports (COM0-COM20) found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "COM4";
                }
                
                if (ports.Length == 1)
                {
                    string selectedPort = ports[0];
                    Properties.Settings.Default.SerialPort = selectedPort;
                    Properties.Settings.Default.Save();
                    MessageBox.Show($"Using port: {selectedPort}", "Serial Port", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return selectedPort;
                }
                
                // Multiple ports - ALWAYS show selection dialog
                using (var form = new Form())
                {
                    form.Text = "Select Serial Port";
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
                        Height = 30
                    };
                    
                    // Add items directly instead of using DataSource
                    combo.Items.AddRange(ports);
                    
                    // Pre-select the saved port
                    string savedPort = Properties.Settings.Default.SerialPort;
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
                        Properties.Settings.Default.SerialPort = selectedPort;
                        Properties.Settings.Default.Save();
                        return selectedPort;
                    }
                    
                    return "COM4";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "COM4";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
            if (Serial_Port?.IsOpen == true)
                Serial_Port.Close();
        }
    }
}