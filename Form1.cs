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

// Code : Kees van Engelen (keesvanengelen@gmail.com)
// 
// Version : 1.7  (25 apr 26); 
// Name    : The590Box 


namespace The590Box
{
    public partial class MainForm : Form
    {
        private const string AppTitle = "The590Box v 1.7 - by Kees, ON9KVE";

        #region Radio Commands — Kenwood TS-590SG
        private const string CMD_READ_MODE = "MD;";
        private const string CMD_READ_ANT = "AN;";
        private const string CMD_READ_PREAMP = "PA;";
        private const string CMD_READ_MENU = "MF;";
        private const string CMD_READ_DATA = "DA;";
        private const string CMD_READ_RFGAIN = "RG;";
        private const string CMD_READ_VOLUME = "AG0;";
        private const string CMD_READ_POWER = "PC;";
        private const string CMD_READ_SQUELCH = "SQ0;";
        private const string CMD_READ_NB = "NB;";
        private const string CMD_READ_NR = "NR;";
        private const string CMD_READ_BC = "BC;";
        private const string CMD_READ_VFO1 = "FA;";
        private const string CMD_READ_VFO2 = "FB;";
        private const string CMD_READ_TUNER = "AC;";

        private const string CMD_SET_TX = "TX2;";
        private const string CMD_SET_RX = "RX;";
        private const string CMD_SET_MODE_USB = "MD2;";
        private const string CMD_SET_MODE_LSB = "MD1;";
        private const string CMD_SET_MODE_CW = "MD3;";
        private const string CMD_SET_MODE_FM = "MD4;";
        private const string CMD_SET_MODE_AM = "MD5;";
        private const string CMD_SET_MODE_DIG = "MD0C;";
        private const string CMD_SET_ANT1 = "AN199;";
        private const string CMD_SET_ANT2 = "AN299;";
        private const string CMD_SET_RXANT_ON = "AN919;";
        private const string CMD_SET_RXANT_OFF = "AN909;";
        private const string CMD_SET_PREAMP_OFF = "PA0;";
        private const string CMD_SET_PREAMP_ON = "PA1;";
        private const string CMD_READ_ATT = "RA;";
        private const string CMD_SET_ATT_OFF = "RA00;";
        private const string CMD_SET_ATT_ON = "RA01;";
        private const string CMD_SET_TUNER_OFF = "AC000;";
        private const string CMD_SET_TUNER_ON = "AC110;";
        private const string CMD_SET_TUNER_TUNE = "AC111;";
        private const string CMD_SET_MENU_A = "MF0;";
        private const string CMD_SET_MENU_B = "MF1;";
        private const string CMD_SET_DATA_OFF = "DA0;";
        private const string CMD_SET_DATA_ON = "DA1;";
        private const string CMD_SET_VOL_MUTE = "AG0000;";
        private const string CMD_SET_BAND = "BD";   // append 2-digit band 00-10 + ;
        private const string CMD_READ_VFO_SEL = "FR;";
        private const string CMD_SET_VFO_A = "FR0;";
        private const string CMD_SET_VFO_B = "FR1;";
        private const string CMD_READ_EX028 = "EX0280000;";
        private const string CMD_READ_EX029 = "EX0290000;";
        private const string CMD_READ_SH    = "SH;";
        private const string CMD_READ_SL    = "SL;";
        private const string CMD_READ_FW    = "FW;";
        private const string CMD_READ_IS    = "IS;";
        private const string CMD_READ_SWR   = "RM;";
        #endregion

        public SerialPort? Serial_Port;
        private readonly object serialLock = new();

        private int currentBand = 10; // default GENE
        private static readonly string[] BandLabels =
            { "1.8 MHz", "3.5 MHz", "7 MHz", "10 MHz", "14 MHz",
              "18 MHz", "21 MHz", "24 MHz", "28 MHz", "50 MHz", "GENE" };

        // Poll timer
        private readonly System.Windows.Forms.Timer pollTimer = new();
        private int  pollIndex  = 0;
        private bool pollBusy   = false;  // prevents overlapping async poll ticks
        private readonly string[] pollCmds =
        {
            CMD_READ_MODE,
            CMD_READ_ANT,
            CMD_READ_PREAMP,
            CMD_READ_ATT,
            CMD_READ_MENU,
            CMD_READ_DATA,
            CMD_READ_RFGAIN,
            CMD_READ_VOLUME,
            CMD_READ_POWER,
            CMD_READ_SQUELCH,
            CMD_READ_NB,
            CMD_READ_NR,
            CMD_READ_BC,
            CMD_READ_VFO1,
            CMD_READ_VFO2,
            CMD_READ_TUNER,
            CMD_READ_VFO_SEL,
            CMD_READ_EX028,
            CMD_READ_EX029,
            CMD_READ_SH,
            CMD_READ_SL,
            CMD_READ_FW,
            CMD_READ_IS,
            CMD_READ_SWR,
        };

        // Slider debounce
        private readonly System.Windows.Forms.Timer sliderDebounceTimer = new();
        private readonly Dictionary<TrackBar, string> pendingSliderCommands = new();

        // Radio update flag
        private bool isUpdatingFromRadio = false;

        public string mode, temp, Data, DataB, DATABD, Dspant, DspantD,
             FColorB, Pstr, Mode, ModeD, Dspipo, DspipoD, SButton, DScopspan, Bar = "";
        public decimal Dsppodnum, SecondNum;

        private enum SliderMode { HLMode, WSMode }

        // Add a field to track the RX antenna state
        private bool rxAntennaOn = false;
        private bool dataOn = false; // Tracks the current DATA state
        private bool preampOn = false;
        private bool attOn = false;
        private bool menuA = true; // Tracks the current MENU state
        private bool vfoB = false;   // false = VFO-A active, true = VFO-B active
        private long currentVfoAHz = 0; // Current VFO-A frequency in 10 Hz units
        private long currentVfoBHz = 0; // Current VFO-B frequency in 10 Hz units
        private static readonly long[] StepValues = { 10, 50, 100, 500, 900 }; // 100 Hz, 500 Hz, 1 kHz, 5 kHz, 9 kHz
                                                                               //      private bool isRxAntennaOff = false;
        private bool muted = false;
        private int savedVolume = 0;
        private bool internalTunerOn = false;
        // SWR blink state
        private readonly System.Windows.Forms.Timer swrBlinkTimer = new() { Interval = 300 };
        private int    swrBlinkCount    = 0;
        private string swrMuteText      = "";
        private Color  swrMuteBackColor = Color.DarkGreen;
        private Color  swrMuteForeColor = Color.Yellow;
        private int nbState = 0;
        private int nrState = 0;
        private int bcState = 0;
        private SliderMode currentSliderMode = SliderMode.HLMode;
        private char currentModeChar = '0'; // last received mode character from MD;
        private int ex028 = 0;              // SSB filter menu: 0=normal(HLMode), 1=WSMode
        private int ex029 = 0;              // DIG filter menu: 0=normal(HLMode), 1=WSMode
        public MainForm()
        {
            InitializeComponent();
            this.Text = $"{AppTitle} - Disconnected";
            InitializeTrackBarEvents();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            RestoreWindowPosition();

            PopulateComPorts();
            UpdateConnectButtonState(false);
            ExtTuneButton.Enabled = false;
        }

        private void InitializeTrackBarEvents()
        {
            // Timers
            pollTimer.Interval = 15;
            pollTimer.Tick += PollTimer_Tick;
            sliderDebounceTimer.Interval = 150;
            sliderDebounceTimer.Tick += SliderDebounceTimer_Tick;

            // Form
            this.FormClosing += MainForm_FormClosing;

            // ExtTuner button appearance + events
            ExtTuneButton.FlatStyle = FlatStyle.Flat;
            ExtTuneButton.BackColor = Color.DarkGreen;
            ExtTuneButton.ForeColor = Color.Yellow;
            ExtTuneButton.FlatAppearance.BorderSize = 2;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.FlatAppearance.MouseDownBackColor = Color.Red;
            ExtTuneButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            ExtTuneButton.MouseDown += TuneButton_MouseDown;
            ExtTuneButton.MouseUp += TuneButton_MouseUp;
            ExtTuneButton.MouseEnter += TuneButton_MouseEnter;
            ExtTuneButton.MouseLeave += TuneButton_MouseLeave;
            ExtTuneButton.Paint += (s, pe) =>
            {
                var btn = (Button)s!;
                TextRenderer.DrawText(pe.Graphics, btn.Text, btn.Font,
                    new Rectangle(0, 0, btn.Width, btn.Height), Color.Yellow,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
            };

            // Mode buttons
            USBB.MouseClick += USB_click;
            LSBB.MouseClick += LSB_click;
            CWB.MouseClick += CW_click;
            AMB.MouseClick += AM_click;
            FMB.MouseClick += FM_click;
            DIGB.MouseClick += DIGB_click;

            // Antenna buttons
            ANT1B.MouseClick += ANT1B_click;
            ANT2B.MouseClick += ANT2B_click;
            ANT3RXB.MouseClick += ANT3RXB_click;

            // Preamp / Attenuator buttons
            PREB.MouseClick += PREB_click;
            ATTB.MouseClick += ATTB_click;

            // Tuner buttons
            IntTune.Click += IntTune_Click;
            ItuneOn.Click += ItuneOn_Click;
            ItuneOff.Click += ItuneOff_Click;

            // Menu + Mute
            MENU.MouseClick += MENU_click;
            MUTE.Click += MuteButton_Click;

            // Sliders
            rfGainTrackBar.ValueChanged    += RfGainTrackBar_ValueChanged;
            volumeGainTrackBar.ValueChanged += VolumeGainTrackBar_ValueChanged;
            pwrControlTrackBar.ValueChanged += PwrControlTrackBar_ValueChanged;
            SQLtrackBar.ValueChanged        += SQLtrackBar_ValueChanged;
            HiShTrackBar.ValueChanged       += HiShTrackBar_ValueChanged;
            LoWdTrackBar.ValueChanged       += LoWdTrackBar_ValueChanged;
            HiShTrackBar.MouseDown          += (s, e) => { if (e.Button == MouseButtons.Right) ResetSliderToDefault(HiShTrackBar, isHiSh: true); };
            LoWdTrackBar.MouseDown          += (s, e) => { if (e.Button == MouseButtons.Right) ResetSliderToDefault(LoWdTrackBar, isHiSh: false); };

            // VFO frequency entry on double-click
            VFOA_box.MouseDoubleClick += (s, e) => OpenFreqEntry(vfoA: true);
            VFOB_box.MouseDoubleClick += (s, e) => OpenFreqEntry(vfoA: false);

            // COM port selector + connect button
            comPortComboBox.DrawItem += ComboBox_DrawItem;
            comPortComboBox.DropDown += (s, e) => PopulateComPorts();
            connectButton.Click += ConnectButton_Click;

            // Band button
            BANDB.MouseDown += BandButton_MouseClick;

            // Step combobox
            STEP_combobox.Items.AddRange(new object[] { "100 Hz", "500 Hz", "1 kHz", "5 kHz", "9 kHz" });
            STEP_combobox.SelectedIndex = Math.Clamp(UserConfig.Default.StepIndexA, 0, 4);
            STEP_combobox.DrawItem += ComboBox_DrawItem;
            STEP_combobox.SelectedIndexChanged += StepCombobox_SelectedIndexChanged;

            // PLUSB / MINB
            PLUSB.Click += PLUSB_Click;
            MINB.Click += MINB_Click;

            // A/B VFO swap
            ABB.Click += ABB_Click;

            // SWR blink timer
            swrBlinkTimer.Tick += SwrBlinkTimer_Tick;

            // NB / NR / BC buttons
            NB0B.MouseClick += NB0B_MouseClick;
            NB1B.MouseDown  += NB1B_MouseDown;
            NB2B.MouseDown  += NB2B_MouseDown;
            NR0B.MouseClick += NR0B_MouseClick;
            NR1B.MouseClick += NR1B_MouseClick;
            NR2B.MouseClick += NR2B_MouseClick;
            BC0B.MouseClick += BC0B_MouseClick;
            BC1B.MouseClick += BC1B_MouseClick;
            BC2B.MouseClick += BC2B_MouseClick;
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
            if (r.Length < 3) return;
            // DIG mode returns "MD0C" — map to internal char 'D'
            currentModeChar = (r.Length >= 4 && r[2] == '0' && r[3] == 'C') ? 'D' : r[2];
            Button? active = currentModeChar switch
            {
                '1' => LSBB, '2' => USBB, '3' => CWB,
                '4' => FMB,  '5' => AMB,  'D' => DIGB, _ => null
            };
            SetButtonGroup(new[] { USBB, LSBB, CWB, AMB, FMB, DIGB }, active);
            UpdateSliderMode();
        }

        // WSMode: CW always; DIG + EX029=1; SSB(LSB/USB) + EX028=1 — everything else is HLMode
        private void UpdateSliderMode()
        {
            bool ws = currentModeChar == '3'                         // CW
                   || (currentModeChar == 'D' && ex029 == 1)         // DIG + EX029=1
                   || (currentModeChar == '1' && ex028 == 1)         // LSB + EX028=1
                   || (currentModeChar == '2' && ex028 == 1);        // USB + EX028=1

            currentSliderMode = ws ? SliderMode.WSMode : SliderMode.HLMode;

            if (currentSliderMode == SliderMode.WSMode)
            {
                HiShLabel.Text = "SHIFT";
                LoWdLabel.Text = "WIDTH";
            }
            else
            {
                HiShLabel.Text = "HIGH";
                LoWdLabel.Text = "LOW";
            }

            ApplySliderConfig(GetCurrentSliderConfig());
        }

        // --- Slider step configurations ---
        private record SliderConfig(int[] HiSteps, int HiDefault, int[] LoSteps, int LoDefault);

        private static readonly SliderConfig CfgAmHL = new(
            HiSteps:   new[] { 2500, 3000, 4000, 5000 },
            HiDefault: 5000,
            LoSteps:   new[] { 0, 100, 200, 300 },
            LoDefault: 100);

        private static readonly SliderConfig CfgSsbFmHL = new(
            HiSteps:   new[] { 1000, 1200, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 2800, 3000, 3400, 4000, 5000 },
            HiDefault: 2600,
            LoSteps:   new[] { 0, 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 },
            LoDefault: 300);

        private static readonly SliderConfig CfgCwWS = new(
            HiSteps:   new[] { 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000 },
            HiDefault: 800,
            LoSteps:   new[] { 50, 80, 100, 150, 200, 250, 300, 400, 500, 600, 1000, 1500, 2000, 2500 },
            LoDefault: 500);

        private static readonly SliderConfig CfgDigWS = new(
            HiSteps:   new[] { 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1750, 1800, 1900, 2000, 2100, 2210 },
            HiDefault: 1500,
            LoSteps:   new[] { 50, 80, 100, 150, 200, 250, 300, 400, 500, 600, 1000, 1500, 2000, 2500 },
            LoDefault: 2500);

        private SliderConfig GetCurrentSliderConfig() =>
            (currentModeChar, currentSliderMode) switch
            {
                ('5', SliderMode.HLMode) => CfgAmHL,    // AM HLMode
                ('3', SliderMode.WSMode) => CfgCwWS,    // CW WSMode
                (_, SliderMode.WSMode)   => CfgDigWS,   // SSB WSMode + DIG WSMode
                _                        => CfgSsbFmHL  // SSB/FM/DIG HLMode
            };

        private void ApplySliderConfig(SliderConfig cfg)
        {
            bool connected = Serial_Port?.IsOpen == true;
            isUpdatingFromRadio = true;
            try
            {
                HiShTrackBar.Minimum       = 0;
                HiShTrackBar.Maximum       = cfg.HiSteps.Length - 1;
                HiShTrackBar.TickFrequency = 1;
                if (!connected)
                {
                    int hiIdx = Array.IndexOf(cfg.HiSteps, cfg.HiDefault);
                    HiShTrackBar.Value = hiIdx >= 0 ? hiIdx : 0;
                    HiShTextBox.Text   = cfg.HiSteps[HiShTrackBar.Value].ToString();
                }

                LoWdTrackBar.Minimum       = 0;
                LoWdTrackBar.Maximum       = cfg.LoSteps.Length - 1;
                LoWdTrackBar.TickFrequency = 1;
                if (!connected)
                {
                    int loIdx = Array.IndexOf(cfg.LoSteps, cfg.LoDefault);
                    LoWdTrackBar.Value = loIdx >= 0 ? loIdx : 0;
                    LoWdTextBox.Text   = cfg.LoSteps[LoWdTrackBar.Value].ToString();
                }
            }
            finally { isUpdatingFromRadio = false; }
        }

        private void ParseEx028(string r)
        {
            // Response: EX0280000a  (a = '0' or '1', last char)
            if (r.Length < 9) return;
            int val = r[r.Length - 1] - '0';
            if (val != ex028) { ex028 = val; UpdateSliderMode(); }
        }

        private void ParseEx029(string r)
        {
            // Response: EX0290000a  (a = '0' or '1', last char)
            if (r.Length < 9) return;
            int val = r[r.Length - 1] - '0';
            if (val != ex029) { ex029 = val; UpdateSliderMode(); }
        }

        private void ParseSH(string r)
        {
            // Response: SHxx  (xx = 2-digit index)
            if (r.Length < 4 || currentSliderMode != SliderMode.HLMode) return;
            if (!int.TryParse(r.Substring(2, 2), out int idx)) return;
            var cfg = GetCurrentSliderConfig();
            if (idx < 0 || idx >= cfg.HiSteps.Length) return;
            isUpdatingFromRadio = true;
            HiShTrackBar.Value = idx;
            HiShTextBox.Text   = cfg.HiSteps[idx].ToString();
            isUpdatingFromRadio = false;
        }

        private void ParseSL(string r)
        {
            // Response: SLxx  (xx = 2-digit index)
            if (r.Length < 4 || currentSliderMode != SliderMode.HLMode) return;
            if (!int.TryParse(r.Substring(2, 2), out int idx)) return;
            var cfg = GetCurrentSliderConfig();
            if (idx < 0 || idx >= cfg.LoSteps.Length) return;
            isUpdatingFromRadio = true;
            LoWdTrackBar.Value = idx;
            LoWdTextBox.Text   = cfg.LoSteps[idx].ToString();
            isUpdatingFromRadio = false;
        }

        private void ParseFW(string r)
        {
            // Response: FWxxxx  (xxxx = 4-digit Hz value)
            if (r.Length < 6 || currentSliderMode != SliderMode.WSMode) return;
            if (!int.TryParse(r.Substring(2, 4), out int hz)) return;
            var cfg = GetCurrentSliderConfig();
            int idx = Array.IndexOf(cfg.LoSteps, hz);
            if (idx < 0) idx = FindClosestIndex(cfg.LoSteps, hz);
            isUpdatingFromRadio = true;
            LoWdTrackBar.Value = Math.Clamp(idx, 0, cfg.LoSteps.Length - 1);
            LoWdTextBox.Text   = hz.ToString();
            isUpdatingFromRadio = false;
        }

        private void ParseIS(string r)
        {
            // Response: IS0xxxx  (x=always 0, xxxx = 4-digit Hz value)
            if (r.Length < 7 || currentSliderMode != SliderMode.WSMode) return;
            if (!int.TryParse(r.Substring(3, 4), out int hz)) return;
            var cfg = GetCurrentSliderConfig();
            int idx = Array.IndexOf(cfg.HiSteps, hz);
            if (idx < 0) idx = FindClosestIndex(cfg.HiSteps, hz);
            isUpdatingFromRadio = true;
            HiShTrackBar.Value = Math.Clamp(idx, 0, cfg.HiSteps.Length - 1);
            HiShTextBox.Text   = hz.ToString();
            isUpdatingFromRadio = false;
        }

        private static int FindClosestIndex(int[] steps, int value)
        {
            int bestIdx = 0, bestDist = int.MaxValue;
            for (int i = 0; i < steps.Length; i++)
            {
                int dist = Math.Abs(steps[i] - value);
                if (dist < bestDist) { bestDist = dist; bestIdx = i; }
            }
            return bestIdx;
        }

        private void ParseAnt(string r)
        {
            if (r.Length < 4) return;
            string x = r.Substring(2, 1), y = r.Substring(3, 1);
            bool rxOn = y == "1";
            Button? txBtn = x switch { "1" => ANT1B, "2" => ANT2B, _ => null };

            rxAntennaOn = rxOn;

            void Apply()
            {
                ANT1B.BackColor   = Color.DarkGreen;
                ANT2B.BackColor   = Color.DarkGreen;
                ANT3RXB.BackColor = Color.DarkGreen;

                if (rxOn)
                {
                    ANT3RXB.BackColor = Color.DarkRed;              // RX ant active
                    if (txBtn != null)
                        txBtn.BackColor = Color.Orange;             // TX antenna shown in orange
                }
                else
                {
                    if (txBtn != null)
                        txBtn.BackColor = Color.DarkRed;            // normal active antenna
                }
            }

            if (ANT1B.InvokeRequired) ANT1B.BeginInvoke((Action)Apply);
            else Apply();
        }

        private void ParsePreamp(string r)
        {
            if (r.Length < 3) return;
            preampOn = r[2] == '1';
            SetButtonActive(PREB, preampOn);
        }

        private void ParseAttenuator(string r)
        {
            if (r.Length < 4) return;
            attOn = r[3] == '1';
            SetButtonActive(ATTB, attOn);
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
                UpdateTextBox(RFTextBox, ToDisplayPercent(slider));
            }
        }

        private void ParseVolume(string r)
        {
            if (r.Length >= 6 && int.TryParse(r.Substring(3, 3), out int v))
            {
                isUpdatingFromRadio = true;
                volumeGainTrackBar.Value = Math.Clamp(v, volumeGainTrackBar.Minimum, volumeGainTrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(VOLTextBox, ToDisplayPercent(v));
            }
        }

        private void ParsePower(string r)
        {
            if (r.Length >= 5 && int.TryParse(r.Substring(2, 3), out int v))
            {
                isUpdatingFromRadio = true;
                pwrControlTrackBar.Value = Math.Clamp(v, pwrControlTrackBar.Minimum, pwrControlTrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(POWERTextBox, v.ToString("D3"));
            }
        }


        private void ParseSquelch(string r)
        {
            if (r.Length >= 6 && int.TryParse(r.Substring(3, 3), out int v))
            {
                isUpdatingFromRadio = true;
                SQLtrackBar.Value = Math.Clamp(v, SQLtrackBar.Minimum, SQLtrackBar.Maximum);
                isUpdatingFromRadio = false;
                UpdateTextBox(SQLTextBox, ToDisplayPercent(v));
            }
        }

        private void ParseVfoA(string r)
        {
            if (!long.TryParse(r.Substring(2, r.Length - 3), out long hz)) return;
            currentVfoAHz = hz;
            UpdateTextBox(VFOA_box, FormatFrequency(hz));
            if (!vfoB)
            {
                int band = GetBandFromHz(hz);
                if (band != currentBand) { currentBand = band; UpdateBandButton(); }
            }
        }

        private void ParseVfoB(string r)
        {
            if (r.Length >= 3 && long.TryParse(r.Substring(2, r.Length - 3), out long hz))
            {
                currentVfoBHz = hz;
                UpdateTextBox(VFOB_box, FormatFrequency(hz));
                if (vfoB)
                {
                    int band = GetBandFromHz(hz);
                    if (band != currentBand) { currentBand = band; UpdateBandButton(); }
                }
            }
        }

        private static string FormatFrequency(long hz)
        {
            long mhz = hz / 100000;
            long khz = (hz % 100000) / 100;
            long hh = hz % 100;
            string b = mhz >= 10 ? (mhz / 10).ToString() : " ";
            return $"{b}{mhz % 10}.{khz:D3}.{hh:D2}";
        }

        private static string ToDisplayPercent(int value, int max = 255) =>
            ((int)Math.Round(value / (double)max * 100)).ToString("D3");

        private static int GetBandFromHz(long hz)
        {
            // IARU Region 1 (Europe) band boundaries
            if (hz >= 181000 && hz <= 190000) return 0;  // 1.8 MHz  (1.810 – 1.900)
            if (hz >= 350000 && hz <= 380000) return 1;  // 3.5 MHz  (3.500 – 3.800)
            if (hz >= 700000 && hz <= 720000) return 2;  // 7 MHz    (7.000 – 7.200)
            if (hz >= 1010000 && hz <= 1015000) return 3;  // 10 MHz   (10.100 – 10.150)
            if (hz >= 1400000 && hz <= 1435000) return 4;  // 14 MHz   (14.000 – 14.350)
            if (hz >= 1806800 && hz <= 1816800) return 5;  // 18 MHz   (18.068 – 18.168)
            if (hz >= 2100000 && hz <= 2145000) return 6;  // 21 MHz   (21.000 – 21.450)
            if (hz >= 2489000 && hz <= 2499000) return 7;  // 24 MHz   (24.890 – 24.990)
            if (hz >= 2800000 && hz <= 2970000) return 8;  // 28 MHz   (28.000 – 29.700)
            if (hz >= 5000000 && hz <= 5200000) return 9;  // 50 MHz   (50.000 – 52.000)
            return 10; // GENE
        }

        private void UpdateBandButton()
        {
            if (BANDB.InvokeRequired) { BANDB.BeginInvoke((Action)UpdateBandButton); return; }
            BANDB.Text = BandLabels[currentBand];
            BANDB.BackColor = vfoB ? Color.DarkBlue : Color.DarkGreen;
        }

        private void BandButton_MouseClick(object sender, MouseEventArgs e)
        {
            int newBand;
            if (e.Button == MouseButtons.Left) newBand = (currentBand + 1) % 11;
            else if (e.Button == MouseButtons.Right) newBand = (currentBand + 10) % 11;
            else return;
            currentBand = newBand;
            IssueCmd($"{CMD_SET_BAND}{newBand:D2};");
            UpdateBandButton();
        }

        private void ParseTuner(string r)
        {
            if (r.Length < 4) { internalTunerOn = false; SetButtonGroup(new[] { ItuneOn, ItuneOff }, ItuneOff); return; }
            string x = r.Substring(2, 1), y = r.Substring(3, 1);
            internalTunerOn = x == "1" || y == "1";
            SetButtonGroup(new[] { ItuneOn, ItuneOff }, internalTunerOn ? ItuneOn : ItuneOff);
        }

        private void ParseVfoSel(string r)
        {
            if (r.Length < 3) return;
            vfoB = r[2] == '1';
            if (ABB.InvokeRequired) ABB.BeginInvoke((Action)UpdateABBButton);
            else UpdateABBButton();
        }

        private void UpdateABBButton()
        {
            ABB.Text = vfoB ? "VFO-B" : "VFO-A";
            ABB.BackColor = vfoB ? Color.DarkBlue : Color.DarkGreen;
            MINB.BackColor = vfoB ? Color.DarkBlue : Color.DarkGreen;
            PLUSB.BackColor = vfoB ? Color.DarkBlue : Color.DarkGreen;
            UpdateBandButton();
        }
        #endregion

        // ── NB / NR / BC ────────────────────────────────────────────────────
        private void UpdateNBButtons()
        {
            if (NB0B.InvokeRequired) { NB0B.BeginInvoke((Action)UpdateNBButtons); return; }
            NB0B.BackColor = nbState == 0 ? Color.DarkRed : Color.DarkGreen;
            NB1B.BackColor = (nbState == 1 || nbState == 3) ? Color.DarkRed : Color.DarkGreen;
            NB2B.BackColor = (nbState == 2 || nbState == 3) ? Color.DarkRed : Color.DarkGreen;
        }

        private void UpdateNRButtons()
        {
            if (NR0B.InvokeRequired) { NR0B.BeginInvoke((Action)UpdateNRButtons); return; }
            NR0B.BackColor = nrState == 0 ? Color.DarkRed : Color.DarkGreen;
            NR1B.BackColor = nrState == 1 ? Color.DarkRed : Color.DarkGreen;
            NR2B.BackColor = nrState == 2 ? Color.DarkRed : Color.DarkGreen;
        }

        private void UpdateBCButtons()
        {
            if (BC0B.InvokeRequired) { BC0B.BeginInvoke((Action)UpdateBCButtons); return; }
            BC0B.BackColor = bcState == 0 ? Color.DarkRed : Color.DarkGreen;
            BC1B.BackColor = bcState == 1 ? Color.DarkRed : Color.DarkGreen;
            BC2B.BackColor = bcState == 2 ? Color.DarkRed : Color.DarkGreen;
        }

        private void ParseNB(string r)
        {
            if (r.Length >= 3 && int.TryParse(r.Substring(2, 1), out int v))
            { nbState = v; UpdateNBButtons(); }
        }

        private void ParseNR(string r)
        {
            if (r.Length >= 3 && int.TryParse(r.Substring(2, 1), out int v))
            { nrState = v; UpdateNRButtons(); }
        }

        private void ParseBC(string r)
        {
            if (r.Length >= 3 && int.TryParse(r.Substring(2, 1), out int v))
            { bcState = v; UpdateBCButtons(); }
        }

        private void NB0B_MouseClick(object sender, MouseEventArgs e)
        { nbState = 0; IssueCmd("NB0;"); UpdateNBButtons(); }

        private void NB1B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { nbState = 3; IssueCmd("NB3;"); }
            else { nbState = 1; IssueCmd("NB1;"); }
            UpdateNBButtons();
        }

        private void NB2B_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { nbState = 3; IssueCmd("NB3;"); }
            else { nbState = 2; IssueCmd("NB2;"); }
            UpdateNBButtons();
        }

        private void NR0B_MouseClick(object sender, MouseEventArgs e)
        { nrState = 0; IssueCmd("NR0;"); UpdateNRButtons(); }

        private void NR1B_MouseClick(object sender, MouseEventArgs e)
        { nrState = 1; IssueCmd("NR1;"); UpdateNRButtons(); }

        private void NR2B_MouseClick(object sender, MouseEventArgs e)
        { nrState = 2; IssueCmd("NR2;"); UpdateNRButtons(); }

        private void BC0B_MouseClick(object sender, MouseEventArgs e)
        { bcState = 0; IssueCmd("BC0;"); UpdateBCButtons(); }

        private void BC1B_MouseClick(object sender, MouseEventArgs e)
        { bcState = 1; IssueCmd("BC1;"); UpdateBCButtons(); }

        private void BC2B_MouseClick(object sender, MouseEventArgs e)
        { bcState = 2; IssueCmd("BC2;"); UpdateBCButtons(); }
        // ─────────────────────────────────────────────────────────────────────

        // ── SWR ───────────────────────────────────────────────────────────────
        private void ParseSWR(string r)
        {
            // Response: "RM" + x(1) + yyyy(4) = 7 chars, x='1' means SWR meter
            if (r.Length < 7 || r[2] != '1') return;
            if (int.TryParse(r.Substring(3, 4), out int val) && val >= 11)
                StartSwrBlink();
        }

        private void StartSwrBlink()
        {
            if (MUTE.InvokeRequired) { MUTE.BeginInvoke((Action)StartSwrBlink); return; }
            if (swrBlinkTimer.Enabled) return;          // already blinking
            swrMuteText      = MUTE.Text;
            swrMuteBackColor = MUTE.BackColor;
            swrMuteForeColor = MUTE.ForeColor;
            swrBlinkCount    = 0;
            swrBlinkTimer.Start();
        }

        private void SwrBlinkTimer_Tick(object sender, EventArgs e)
        {
            swrBlinkCount++;
            if (swrBlinkCount > 10)                     // 10 half-cycles = 5 full blinks
            {
                swrBlinkTimer.Stop();
                swrBlinkCount    = 0;
                MUTE.Text        = swrMuteText;
                MUTE.BackColor   = swrMuteBackColor;
                MUTE.ForeColor   = swrMuteForeColor;
                return;
            }
            bool on = swrBlinkCount % 2 == 1;           // odd ticks = blink ON
            MUTE.Text      = on ? "HI SWR"       : swrMuteText;
            MUTE.BackColor = on ? Color.Yellow    : swrMuteBackColor;
            MUTE.ForeColor = on ? Color.Red       : swrMuteForeColor;
        }
        // ─────────────────────────────────────────────────────────────────────

        private void SetButtonActive(Button btn, bool active)
        {
            if (btn.InvokeRequired) { btn.BeginInvoke((Action)(() => SetButtonActive(btn, active))); return; }
            btn.BackColor = active ? Color.DarkRed : Color.DarkGreen;
        }

        private void SetButtonGroup(Button[] group, Button? active)
        {
            if (group[0].InvokeRequired) { group[0].BeginInvoke((Action)(() => SetButtonGroup(group, active))); return; }
            foreach (var btn in group)
                btn.BackColor = btn == active ? Color.DarkRed : Color.DarkGreen;
        }

        private async void PollTimer_Tick(object sender, EventArgs e)
        {
            if (Serial_Port == null || !Serial_Port.IsOpen) return;
            if (pollBusy) return;        // previous tick still running — skip this one
            pollBusy = true;

            string cmd = pollCmds[pollIndex];
            pollIndex = (pollIndex + 1) % pollCmds.Length;

            string? response = await Task.Run(() =>
            {
                try
                {
                    lock (serialLock)
                    {
                        Serial_Port.DiscardInBuffer();
                        Serial_Port.Write(cmd);
                        Thread.Sleep(6);
                        return Serial_Port.ReadTo(";");
                    }
                }
                catch { return null; }
            });

            pollBusy = false;
            if (response == null) return;

            if (cmd == CMD_READ_MODE) ParseMode(response);
            else if (cmd == CMD_READ_ANT) ParseAnt(response);
            else if (cmd == CMD_READ_PREAMP) ParsePreamp(response);
            else if (cmd == CMD_READ_ATT) ParseAttenuator(response);
            else if (cmd == CMD_READ_MENU) ParseMenu(response);
            else if (cmd == CMD_READ_DATA) ParseData(response);
            else if (cmd == CMD_READ_RFGAIN) ParseRfGain(response);
            else if (cmd == CMD_READ_VOLUME) ParseVolume(response);
            else if (cmd == CMD_READ_POWER) ParsePower(response);
            else if (cmd == CMD_READ_SQUELCH) ParseSquelch(response);
            else if (cmd == CMD_READ_NB) ParseNB(response);
            else if (cmd == CMD_READ_NR) ParseNR(response);
            else if (cmd == CMD_READ_BC) ParseBC(response);
            else if (cmd == CMD_READ_VFO1) ParseVfoA(response);
            else if (cmd == CMD_READ_VFO2) ParseVfoB(response);
            else if (cmd == CMD_READ_TUNER) ParseTuner(response);
            else if (cmd == CMD_READ_VFO_SEL) ParseVfoSel(response);
            else if (cmd == CMD_READ_EX028) ParseEx028(response);
            else if (cmd == CMD_READ_EX029) ParseEx029(response);
            else if (cmd == CMD_READ_SH) ParseSH(response);
            else if (cmd == CMD_READ_SL) ParseSL(response);
            else if (cmd == CMD_READ_FW) ParseFW(response);
            else if (cmd == CMD_READ_IS) ParseIS(response);
            else if (cmd == CMD_READ_SWR) ParseSWR(response);

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
                if (Serial_Port == null || !Serial_Port.IsOpen) return;
                IssueCmd(cmd);
            }
        }

        private void IssueCmd(string cmd)
        {
            if (Serial_Port == null || !Serial_Port.IsOpen) return;
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
            if (internalTunerOn)
            {
                FlashExtTuneBlocked();
                return;
            }
            IssueCmd(CMD_SET_TX);
        }

        private async void FlashExtTuneBlocked()
        {
            for (int i = 0; i < 3; i++)
            {
                ExtTuneButton.BackColor = Color.Red;
                ExtTuneButton.Text = "Blocked";
                await Task.Delay(200);
                ExtTuneButton.BackColor = Color.DarkGreen;
                ExtTuneButton.Text = "Ext Tuner";
                await Task.Delay(150);
            }
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

        private long GetSelectedStep()
        {
            int idx = STEP_combobox.SelectedIndex;
            return (idx >= 0 && idx < StepValues.Length) ? StepValues[idx] : StepValues[2];
        }

        private void PLUSB_Click(object sender, EventArgs e) => StepActiveVfo(+1);
        private void MINB_Click(object sender, EventArgs e) => StepActiveVfo(-1);

        private void ABB_Click(object sender, EventArgs e)
        {
            vfoB = !vfoB;
            IssueCmd(vfoB ? CMD_SET_VFO_B : CMD_SET_VFO_A);
            STEP_combobox.SelectedIndex = Math.Clamp(
                vfoB ? UserConfig.Default.StepIndexB : UserConfig.Default.StepIndexA, 0, 4);
            UpdateABBButton();
        }

        private void StepCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vfoB) UserConfig.Default.StepIndexB = STEP_combobox.SelectedIndex;
            else UserConfig.Default.StepIndexA = STEP_combobox.SelectedIndex;
            UserConfig.Default.Save();
        }

        private void StepActiveVfo(int direction)
        {
            if (Serial_Port == null || !Serial_Port.IsOpen) return;
            if (vfoB)
            {
                if (currentVfoBHz == 0) return;
                currentVfoBHz = Math.Max(0, currentVfoBHz + direction * GetSelectedStep());
                IssueCmd($"FB{currentVfoBHz * 10L:D11};");
                UpdateTextBox(VFOB_box, FormatFrequency(currentVfoBHz));
                pollIndex = Array.IndexOf(pollCmds, CMD_READ_VFO2);
            }
            else
            {
                if (currentVfoAHz == 0) return;
                currentVfoAHz = Math.Max(0, currentVfoAHz + direction * GetSelectedStep());
                IssueCmd($"FA{currentVfoAHz * 10L:D11};");
                UpdateTextBox(VFOA_box, FormatFrequency(currentVfoAHz));
                pollIndex = Array.IndexOf(pollCmds, CMD_READ_VFO1);
            }
        }

        private void OpenFreqEntry(bool vfoA)
        {
            if (Serial_Port?.IsOpen != true) return;
            long currentHz = vfoA ? currentVfoAHz : currentVfoBHz;
            double currentKhz = currentHz / 100.0;

            // Position popup just below the clicked VFO box
            var box = vfoA ? VFOA_box : VFOB_box;
            var loc = box.PointToScreen(new Point(0, box.Height + 2));

            using var popup = new FreqEntryForm(currentKhz, loc);
            if (popup.ShowDialog(this) != DialogResult.OK) return;

            // Convert kHz input to 10 Hz units
            long newHz = (long)Math.Round(popup.EnteredKhz * 100);
            newHz = Math.Max(1, newHz);

            if (vfoA)
            {
                currentVfoAHz = newHz;
                IssueCmd($"FA{newHz * 10L:D11};");
                UpdateTextBox(VFOA_box, FormatFrequency(newHz));
                int band = GetBandFromHz(newHz);
                if (band != currentBand) { currentBand = band; UpdateBandButton(); }
                pollIndex = Array.IndexOf(pollCmds, CMD_READ_VFO1);
            }
            else
            {
                currentVfoBHz = newHz;
                IssueCmd($"FB{newHz * 10L:D11};");
                UpdateTextBox(VFOB_box, FormatFrequency(newHz));
                pollIndex = Array.IndexOf(pollCmds, CMD_READ_VFO2);
            }
        }



        private void PREB_click(object sender, MouseEventArgs e)
        {
            preampOn = !preampOn;
            IssueCmd(preampOn ? CMD_SET_PREAMP_ON : CMD_SET_PREAMP_OFF);
            SetButtonActive(PREB, preampOn);
        }

        private void ATTB_click(object sender, MouseEventArgs e)
        {
            attOn = !attOn;
            IssueCmd(attOn ? CMD_SET_ATT_ON : CMD_SET_ATT_OFF);
            SetButtonActive(ATTB, attOn);
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

        // --- External Tuner color change handlers ---
        private void TuneButton_MouseEnter(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.Blue; }
        private void TuneButton_MouseLeave(object sender, EventArgs e) { ExtTuneButton.BackColor = Color.DarkGreen; }
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            var cb = (ComboBox)sender;
            bool selected = (e.State & DrawItemState.Selected) != 0;
            using var bgBrush = new SolidBrush(selected ? Color.Green : Color.DarkGreen);
            using var fgBrush = new SolidBrush(cb.ForeColor);
            e.Graphics.FillRectangle(bgBrush, e.Bounds);
            if (e.Index >= 0)
                e.Graphics.DrawString(cb.Items[e.Index]?.ToString(), e.Font, fgBrush, e.Bounds);
        }


        private void RfGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = rfGainTrackBar.Value;
            UpdateTextBox(RFTextBox, ToDisplayPercent(v));
            pendingSliderCommands[rfGainTrackBar] = $"RG{255 - v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void VolumeGainTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = volumeGainTrackBar.Value;
            UpdateTextBox(VOLTextBox, ToDisplayPercent(v));
            pendingSliderCommands[volumeGainTrackBar] = $"AG0{v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void PwrControlTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = pwrControlTrackBar.Value;
            UpdateTextBox(POWERTextBox, v.ToString("D3"));
            pendingSliderCommands[pwrControlTrackBar] = $"PC{v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void SQLtrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            int v = SQLtrackBar.Value;
            UpdateTextBox(SQLTextBox, ToDisplayPercent(v));
            pendingSliderCommands[SQLtrackBar] = $"SQ0{v:D3};";
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void ResetSliderToDefault(SilverKnobTrackBar slider, bool isHiSh)
        {
            var cfg = GetCurrentSliderConfig();
            if (isHiSh)
            {
                int idx = Array.IndexOf(cfg.HiSteps, cfg.HiDefault);
                if (idx < 0) idx = 0;
                slider.Value     = idx;
                HiShTextBox.Text = cfg.HiSteps[idx].ToString();
                string cmd = currentSliderMode == SliderMode.HLMode
                    ? $"SH{idx:D2};"
                    : $"IS0{cfg.HiDefault:D4};";
                IssueCmd(cmd);
            }
            else
            {
                int idx = Array.IndexOf(cfg.LoSteps, cfg.LoDefault);
                if (idx < 0) idx = 0;
                slider.Value     = idx;
                LoWdTextBox.Text = cfg.LoSteps[idx].ToString();
                string cmd = currentSliderMode == SliderMode.HLMode
                    ? $"SL{idx:D2};"
                    : $"FW{cfg.LoDefault:D4};";
                IssueCmd(cmd);
            }
        }

        private void HiShTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            var cfg = GetCurrentSliderConfig();
            int freq = cfg.HiSteps[HiShTrackBar.Value];
            HiShTextBox.Text = freq.ToString();
            string cmd = currentSliderMode == SliderMode.HLMode
                ? $"SH{HiShTrackBar.Value:D2};"
                : $"IS0{freq:D4};";
            pendingSliderCommands[HiShTrackBar] = cmd;
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }

        private void LoWdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingFromRadio) return;
            var cfg = GetCurrentSliderConfig();
            int freq = cfg.LoSteps[LoWdTrackBar.Value];
            LoWdTextBox.Text = freq.ToString();
            string cmd = currentSliderMode == SliderMode.HLMode
                ? $"SL{LoWdTrackBar.Value:D2};"
                : $"FW{freq:D4};";
            pendingSliderCommands[LoWdTrackBar] = cmd;
            sliderDebounceTimer.Stop();
            sliderDebounceTimer.Start();
        }


        private void IntTune_Click(object sender, EventArgs e)
        {
            IssueCmd(CMD_SET_TUNER_TUNE); // Start tuning

        }

        private void ItuneOn_Click(object sender, EventArgs e)
        {
            internalTunerOn = true;
            IssueCmd(CMD_SET_TUNER_ON); // Turn internal tuner ON
        }

        private void ItuneOff_Click(object sender, EventArgs e)
        {
            internalTunerOn = false;
            IssueCmd(CMD_SET_TUNER_OFF); // Turn internal tuner OFF
        }
        private void PopulateComPorts()
        {
            string? current = comPortComboBox.SelectedItem as string;

            string[] ports = SerialPort.GetPortNames()
                .Where(p => p.StartsWith("COM") && int.TryParse(p.Substring(3), out int n) && n >= 0 && n <= 20)
                .OrderBy(p => int.Parse(p.Substring(3)))
                .ToArray();

            comPortComboBox.Items.Clear();
            if (ports.Length > 0)
                comPortComboBox.Items.AddRange(ports);

            string preferred = current ?? UserConfig.Default.LastPort;
            int idx = Array.IndexOf(ports, preferred);
            comPortComboBox.SelectedIndex = idx >= 0 ? idx : (ports.Length > 0 ? 0 : -1);
        }

        private void UpdateConnectButtonState(bool connected)
        {
            connectButton.Text = connected ? "Disconnect" : "Connect";
            connectButton.BackColor = connected ? Color.DarkRed : Color.DarkGreen;
            comPortComboBox.Enabled = !connected;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (Serial_Port?.IsOpen == true)
            {
                pollTimer.Stop();
                try { Serial_Port.Close(); } catch { }
                UpdateConnectButtonState(false);
                ExtTuneButton.Enabled = false;
                this.Text = $"{AppTitle} - Disconnected";
            }
            else
            {
                if (comPortComboBox.SelectedItem is not string portName) return;

                Serial_Port?.Dispose();
                Serial_Port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
                {
                    Handshake = Handshake.None,
                    RtsEnable = true,
                    DtrEnable = true,
                    ReadTimeout = 500,
                    WriteTimeout = 500
                };

                connectButton.Enabled = false;
                Task.Run(() =>
                {
                    try
                    {
                        Serial_Port.Open();
                        ReadRadioStatus();
                        if (IsHandleCreated)
                            Invoke((Action)(() =>
                            {
                                UserConfig.Default.LastPort = portName;
                                UserConfig.Default.Save();
                                this.Text = $"{AppTitle} - {portName}";
                                UpdateConnectButtonState(true);
                                ExtTuneButton.Enabled = true;
                                connectButton.Enabled = true;
                                pollTimer.Start();
                            }));
                    }
                    catch (Exception ex)
                    {
                        if (IsHandleCreated)
                            Invoke((Action)(() =>
                            {
                                connectButton.Enabled = true;
                                MessageBox.Show(this, "Failed to open serial port: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                    }
                });
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
                Task.Run(() => { IssueCmd($"AG0{vol:D3};"); Thread.Sleep(6); });
                SetButtonActive(MUTE, false);
                muted = false;
            }
            else
            {
                savedVolume = volumeGainTrackBar.Value;
                Task.Run(() => { IssueCmd(CMD_SET_VOL_MUTE); Thread.Sleep(6); });
                SetButtonActive(MUTE, true);
                muted = true;
            }
        }

        // Add this method to save window position
        private void SaveWindowPosition()
        {
            UserConfig.Default.WindowLeft = this.Left;
            UserConfig.Default.WindowTop = this.Top;
            UserConfig.Default.IsPositionSaved = true;
            UserConfig.Default.Save();
        }

        private void RestoreWindowPosition()
        {
            if (!UserConfig.Default.IsPositionSaved)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                return;
            }

            var savedBounds = new Rectangle(UserConfig.Default.WindowLeft, UserConfig.Default.WindowTop, this.Width, this.Height);
            bool isVisible = Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(savedBounds));

            if (isVisible)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(UserConfig.Default.WindowLeft, UserConfig.Default.WindowTop);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pwrControlLabel_Click(object sender, EventArgs e)
        {

        }
    }
}