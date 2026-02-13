using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using The590Box.Properties;

// Code : Kees van Engelen (keesvanengelen@gmail.com)
// 
// Version : 16-x (09 feb 26); 
// Name    : The101Box Yaesu FTDX101 @ COMx


namespace The590Box
{
    public partial class MainForm : Form
    {
        public readonly SerialPort Serial_Port;
        public string mode, temp, Data,DataB, DATABD, Dspant, DspantD,
             FColorB, Pstr, Mode, ModeD,Dspipo, DspipoD, SButton, DScopspan, Bar = "";
        public decimal  Dsppodnum, SecondNum;

        private CancellationTokenSource cts = new();

        // Add a field to track the RX antenna state
        private bool isRxAntennaOn = false;
        private bool isDataOn = false; // Tracks the current DATA state
  //      private bool isRxAntennaOff = false;
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

            Serial_Port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
            {
                Handshake = Handshake.None,
                RtsEnable = true,
                DtrEnable = true,
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



                    // Read Mode ("MD;")
                    IssueCmd("MD;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 3) // Ensure the response is at least 3 characters long
                    {
                        Mode = temp.Substring(2, 1); // Extract the mode value
                        ModeD = Mode switch
                        {
                            "1" => "LSB",
                            "2" => "USB",
                            "3" => "CW",
                            "4" => "FM",
                            "5" => "AM",
                            _ => "???", // Unknown mode
                        };
                    }
                    else
                    {
                        ModeD = "???"; // Invalid response
                    }

                    // Read Data ("DA;")
                    //                 IssueCmd("DA;");
                    //                 temp = Serial_Port.ReadTo(";");
                    //                 if (temp.Length >= 3) // Ensure the response is at least 3 characters long
                    //                 {
                    //                     DataB = temp.Substring(2, 1); // Extract the data flag
                    //                     DATABD = DataB switch
                    //                     {
                    //                         "0" => " ",    // Data off
                    //                         "1" => "DATA", // Data on
                    //                         _ => "???",    // Unknown data state
                    //                     };
                    //                 }
                    //                 else
                    //                {
                    //                     DATABD = "???"; // Invalid response
                    //                 }
                    //
                    //                 // Update the MODEDATA_box with the combined Mode and Data
                    MODE_box.Text = ModeD;


                    IssueCmd("AN;"); // Send command to read antenna status
                    temp = Serial_Port.ReadTo(";"); // Read response from the serial port

                    if (temp.Length >= 4) // Ensure the response is at least 4 characters long (ANxyz)
                    {
                        string x = temp.Substring(2, 1); // Extract the value of x
                        string y = temp.Substring(3, 1); // Extract the value of y

                        DspantD = y switch
                        {
                            "0" => x switch
                            {
                                "1" => "ANT 1", // ANT 1 is connected, RX not used
                                "2" => "ANT 2", // ANT 2 is connected, RX not used
                                _ => "???",     // Unknown antenna
                            },
                            "1" => "RX ANT",    // RX antenna is used
                            _ => "???",         // Unknown RX state
                        };
                    }
                    else
                    {
                        DspantD = "???"; // Invalid response
                    }

                    IssueCmd("PA;");
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 4)
                    {
                        Dspipo = temp.Substring(2, 1);
                        DspipoD = Dspipo switch
                        {
                            "0" => "AMP off",
                            "1" => "AMP on",
                        };
                    }
                    else
                    {
                        DspipoD = "???";
                    }


                    string Blokje = "█";
                    Bar = (Bar == Blokje) ? " " : Blokje;

                    // Update UI
                    UpdateTextBox(MODE_box, ModeD);
                    UpdateTextBox(ANT_box, DspantD);
                    UpdateTextBox(IPO_box, DspipoD); //IPO = preamp
                    UpdateTextBox(BUSY_box, Bar);


                    // Sync sliders with radio values
                    // Detach event handlers to prevent sending commands when setting values
                    rfGainTrackBar.ValueChanged -= RfGainTrackBar_ValueChanged;
                    volumeGainTrackBar.ValueChanged -= VolumeGainTrackBar_ValueChanged;
                    pwrControlTrackBar.ValueChanged -= PwrControlTrackBar_ValueChanged;

                    // Read and set RF gain slider
                    IssueCmd("RG;");
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

                    // Read and set squelch slider
                    IssueCmd("SQ;"); // Command to read squelch value
                    temp = Serial_Port.ReadTo(";");
                    if (temp.Length >= 5)
                    {
                        string sqValueStr = temp.Substring(2, 3); // Extract the squelch value
                        if (int.TryParse(sqValueStr, out int sqValue))
                        {
                            SQLtrackBar.Value = Math.Max(SQLtrackBar.Minimum, Math.Min(SQLtrackBar.Maximum, sqValue));
                            UpdateTextBox(SQLTextBox, sqValueStr); // Display the squelch value in SQLTextBox
                        }
                    }

                    // Reattach event handlers
                    rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
                    volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;
                    pwrControlTrackBar.ValueChanged += PwrControlTrackBar_ValueChanged;


                    IssueCmd("FA;");
                    temp = Serial_Port.ReadTo(";");
                    string vfo1Freq = "???";
                    if (temp.Length >= 4) // FA + at least 1 digit + ;
                    {
                        string freqStr = temp.Substring(2, temp.Length - 3); // Extract digits between FA and ;
                        if (long.TryParse(freqStr, out long freqHz))
                        {
                            double freqMHz = freqHz / 100000.0; // Correct divisor for this radio
                            vfo1Freq = $"{freqMHz,9:F3}"; // Right-align in 9 characters with 3 decimals
                        }
                    }

                    IssueCmd("FB;");
                    temp = Serial_Port.ReadTo(";");
                    string vfo2Freq = "???";
                    if (temp.Length >= 4) // FB + at least 1 digit + ;
                    {
                        string freqStr = temp.Substring(2, temp.Length - 3); // Extract digits between FB and ;
                        if (long.TryParse(freqStr, out long freqHz))
                        {
                            double freqMHz = freqHz / 100000.0; // Correct divisor for this radio
                            vfo2Freq = $"{freqMHz,9:F3}"; // Right-align in 9 characters with 3 decimals
                        }
                    }

                    UpdateTextBox(VFO1_box, $"VFO1:{vfo1Freq} MHz");
                    UpdateTextBox(VFO2_box, $"VFO2:{vfo2Freq} MHz");

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

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void RX_box_TextChanged(object sender, EventArgs e) { }

        private void IssueCmd(string cmd)
        {
            try
            {
                Serial_Port.Write(cmd);
                Thread.Sleep(6); // Increased to 60 ms to match other working programs' timing
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void USB_click(object sender, MouseEventArgs e) { IssueCmd("MD2;"); }
        private void LSB_click(object sender, MouseEventArgs e) { IssueCmd("MD1;"); }
        private void CW_click(object sender, MouseEventArgs e) { IssueCmd("MD3;"); }
        private void FM_click(object sender, MouseEventArgs e) { IssueCmd("MD4;"); }
        private void AM_click(object sender, MouseEventArgs e) { IssueCmd("MD5;"); }
        private void DIG_click(object sender, MouseEventArgs e) { IssueCmd("MD0C;"); }

        private void ANT1B_click(object sender, MouseEventArgs e) { IssueCmd("AN199;"); }   //ANT1 on, ANT2 off
        private void ANT2B_click(object sender, MouseEventArgs e) { IssueCmd("AN299;"); }   //ANT2 on, ANT1 off  



        private void PREoff_click(object sender, MouseEventArgs e) { IssueCmd("PA0;"); } // AMP off

        private void PROon_click(object sender, MouseEventArgs e) { IssueCmd("PA1;"); } // AMP on


        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

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


        private void RfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int displayedValue = rfGainTrackBar.Value; // Directly use the slider value for display
            string value = displayedValue.ToString("D3");
            UpdateTextBox(textBox1, value); // Display the value in textBox1
            IssueCmd($"RG{(rfGainTrackBar.Maximum - displayedValue):D3};"); // Send inverted value to the radio
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

        private void SQLtrackBar_ValueChanged(object sender, EventArgs e)
        {
            int displayedValue = SQLtrackBar.Value; // Get the slider value
            string value = displayedValue.ToString("D3"); // Format as 3 digits
            UpdateTextBox(SQLTextBox, value); // Update the display in the TextBox
            IssueCmd($"SQ{value};"); // Send the squelch control command
        }


        private void rfGainTrackBar_Scroll(object sender, EventArgs e)
        {

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
                    Settings.Default.SerialPort = selectedPort;
                    Settings.Default.Save();
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
                    string savedPort = Settings.Default.SerialPort;
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
                        Settings.Default.SerialPort = selectedPort;
                        Settings.Default.Save();
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

        private void ANT3RXB_click(object sender, MouseEventArgs e)
        {
            if (isRxAntennaOn)
            {
                IssueCmd("AN909;"); // RX ANT OFF
                isRxAntennaOn = false;
            }
            else
            {
                IssueCmd("AN919;"); // RX ANT ON
                isRxAntennaOn = true;
            }
        }

        private void DIGB_click(object sender, MouseEventArgs e)
        {
            if (isDataOn)
            {
                IssueCmd("DA0;"); // Turn DATA off
                isDataOn = false;
                DIGB.BackColor = Color.DarkGreen; // Set button color to Dark Green when DATA is off
            }
            else
            {
                IssueCmd("DA1;"); // Turn DATA on
                isDataOn = true;
                DIGB.BackColor = Color.Red; // Set button color to Red when DATA is on
            }
        }

        private void DIGB_Click_1(object sender, EventArgs e)
        {
            // Read the current DATA state
            IssueCmd("DA;");
            temp = Serial_Port.ReadTo(";");
            if (temp.Length >= 3)
            {
                string dataState = temp.Substring(2, 1); // Extract the DATA state
                isDataOn = dataState == "1"; // Set the state based on the response

                // Update the button appearance based on the current state
                if (isDataOn)
                {
                    DIGB.BackColor = Color.Green; // DATA is on
                }
                else
                {
                    DIGB.BackColor = Color.DarkGray; // DATA is off
                }
            }
        }
    }
}