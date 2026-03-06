using System.Drawing;
using System.Windows.Forms;

namespace The590Box
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExtTuneButton = new Button();
            USBB = new Button();
            LSBB = new Button();
            CWB = new Button();
            ANT1B = new Button();
            ANT2B = new Button();
            ANT3RXB = new Button();
            PREoff = new Button();
            PROon = new Button();
            rfGainTrackBar = new TrackBar();
            volumeGainTrackBar = new TrackBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            BUSY_box = new TextBox();
            pwrControlTrackBar = new TrackBar();
            textBox3 = new TextBox();
            AMB = new Button();
            FMB = new Button();
            DIGB = new Button();
            IntTune = new Button();
            ItuneOn = new Button();
            ItuneOff = new Button();
            rfGainLabel = new Label();
            volumeGainLabel = new Label();
            pwrControlLabel = new Label();
            VFOA_box = new TextBox();
            VFOB_box = new TextBox();
            vfoALabel = new Label();
            vfoBLabel = new Label();
            MENU = new Button();
            SQLtrackBar = new TrackBar();
            SQLTextBox = new TextBox();
            SQLLabel = new Label();
            MUTE = new Button();
            comPortComboBox = new ComboBox();
            connectButton = new Button();
            MINB = new Button();
            PLUSB = new Button();
            BANDB = new Button();
            ABB = new Button();
            STEP_combobox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SQLtrackBar).BeginInit();
            SuspendLayout();
            // 
            // ExtTuneButton
            // 
            ExtTuneButton.BackColor = Color.DarkGreen;
            ExtTuneButton.FlatAppearance.BorderColor = Color.White;
            ExtTuneButton.FlatAppearance.BorderSize = 3;
            ExtTuneButton.FlatAppearance.MouseDownBackColor = Color.Red;
            ExtTuneButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            ExtTuneButton.Font = new Font("Verdana", 8.25F, FontStyle.Bold);
            ExtTuneButton.ForeColor = Color.Yellow;
            ExtTuneButton.Location = new Point(762, 83);
            ExtTuneButton.Name = "ExtTuneButton";
            ExtTuneButton.Size = new Size(88, 40);
            ExtTuneButton.TabIndex = 8;
            ExtTuneButton.Text = "Ext Tuner";
            ExtTuneButton.UseVisualStyleBackColor = false;
            // 
            // USBB
            // 
            USBB.BackColor = Color.DarkGreen;
            USBB.FlatAppearance.BorderColor = Color.White;
            USBB.FlatAppearance.MouseDownBackColor = Color.Red;
            USBB.FlatAppearance.MouseOverBackColor = Color.Blue;
            USBB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            USBB.ForeColor = Color.Yellow;
            USBB.Location = new Point(469, 1);
            USBB.Name = "USBB";
            USBB.Size = new Size(44, 40);
            USBB.TabIndex = 11;
            USBB.Text = "USB";
            USBB.UseVisualStyleBackColor = false;
            // 
            // LSBB
            // 
            LSBB.BackColor = Color.DarkGreen;
            LSBB.FlatAppearance.BorderColor = Color.White;
            LSBB.FlatAppearance.MouseDownBackColor = Color.Red;
            LSBB.FlatAppearance.MouseOverBackColor = Color.Blue;
            LSBB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LSBB.ForeColor = Color.Yellow;
            LSBB.Location = new Point(513, 1);
            LSBB.Name = "LSBB";
            LSBB.Size = new Size(44, 40);
            LSBB.TabIndex = 12;
            LSBB.Text = "LSB";
            LSBB.UseVisualStyleBackColor = false;
            // 
            // CWB
            // 
            CWB.BackColor = Color.DarkGreen;
            CWB.FlatAppearance.BorderColor = Color.White;
            CWB.FlatAppearance.MouseDownBackColor = Color.Red;
            CWB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CWB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CWB.ForeColor = Color.Yellow;
            CWB.Location = new Point(469, 83);
            CWB.Name = "CWB";
            CWB.Size = new Size(44, 40);
            CWB.TabIndex = 13;
            CWB.Text = "CW";
            CWB.UseVisualStyleBackColor = false;
            // 
            // ANT1B
            // 
            ANT1B.BackColor = Color.DarkGreen;
            ANT1B.FlatAppearance.BorderColor = Color.White;
            ANT1B.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT1B.ForeColor = Color.Yellow;
            ANT1B.Location = new Point(288, 1);
            ANT1B.Name = "ANT1B";
            ANT1B.Size = new Size(88, 40);
            ANT1B.TabIndex = 25;
            ANT1B.Text = "ANT 1";
            ANT1B.UseVisualStyleBackColor = false;
            // 
            // ANT2B
            // 
            ANT2B.BackColor = Color.DarkGreen;
            ANT2B.FlatAppearance.BorderColor = Color.White;
            ANT2B.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT2B.ForeColor = Color.Yellow;
            ANT2B.Location = new Point(288, 42);
            ANT2B.Name = "ANT2B";
            ANT2B.Size = new Size(88, 40);
            ANT2B.TabIndex = 26;
            ANT2B.Text = "ANT 2";
            ANT2B.UseVisualStyleBackColor = false;
            // 
            // ANT3RXB
            // 
            ANT3RXB.BackColor = Color.DarkGreen;
            ANT3RXB.FlatAppearance.BorderColor = Color.White;
            ANT3RXB.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT3RXB.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT3RXB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT3RXB.ForeColor = Color.Yellow;
            ANT3RXB.Location = new Point(288, 83);
            ANT3RXB.Name = "ANT3RXB";
            ANT3RXB.Size = new Size(88, 40);
            ANT3RXB.TabIndex = 27;
            ANT3RXB.Text = "RX ANT";
            ANT3RXB.UseVisualStyleBackColor = false;
            // 
            // PREoff
            // 
            PREoff.BackColor = Color.DarkGreen;
            PREoff.FlatAppearance.BorderColor = Color.White;
            PREoff.FlatAppearance.MouseDownBackColor = Color.Red;
            PREoff.FlatAppearance.MouseOverBackColor = Color.Blue;
            PREoff.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PREoff.ForeColor = Color.Yellow;
            PREoff.Location = new Point(376, 42);
            PREoff.Name = "PREoff";
            PREoff.Size = new Size(88, 40);
            PREoff.TabIndex = 28;
            PREoff.Text = "PRE off";
            PREoff.UseVisualStyleBackColor = false;
            // 
            // PROon
            // 
            PROon.BackColor = Color.DarkGreen;
            PROon.FlatAppearance.BorderColor = Color.White;
            PROon.FlatAppearance.MouseDownBackColor = Color.Red;
            PROon.FlatAppearance.MouseOverBackColor = Color.Blue;
            PROon.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PROon.ForeColor = Color.Yellow;
            PROon.Location = new Point(376, 83);
            PROon.Name = "PROon";
            PROon.Size = new Size(88, 40);
            PROon.TabIndex = 29;
            PROon.Text = "PRE on";
            PROon.UseVisualStyleBackColor = false;
            // 
            // rfGainTrackBar
            // 
            rfGainTrackBar.BackColor = Color.DarkGreen;
            rfGainTrackBar.Location = new Point(562, 1);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = Orientation.Vertical;
            rfGainTrackBar.Size = new Size(45, 110);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = TickStyle.Both;
            rfGainTrackBar.Value = 255;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.BackColor = Color.DarkGreen;
            volumeGainTrackBar.Location = new Point(612, 1);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = Orientation.Vertical;
            volumeGainTrackBar.Size = new Size(45, 110);
            volumeGainTrackBar.TabIndex = 43;
            volumeGainTrackBar.TickFrequency = 16;
            volumeGainTrackBar.TickStyle = TickStyle.Both;
            volumeGainTrackBar.Value = 60;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Gold;
            textBox1.Location = new Point(562, 110);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(40, 15);
            textBox1.TabIndex = 46;
            textBox1.TabStop = false;
            textBox1.Text = "00";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.WordWrap = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.Gold;
            textBox2.Location = new Point(612, 110);
            textBox2.Margin = new Padding(0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(40, 15);
            textBox2.TabIndex = 47;
            textBox2.TabStop = false;
            textBox2.Text = "00";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.WordWrap = false;
            // 
            // BUSY_box
            // 
            BUSY_box.BackColor = Color.Black;
            BUSY_box.BorderStyle = BorderStyle.None;
            BUSY_box.ForeColor = Color.FromArgb(64, 64, 64);
            BUSY_box.Location = new Point(160, 107);
            BUSY_box.Margin = new Padding(1);
            BUSY_box.Multiline = true;
            BUSY_box.Name = "BUSY_box";
            BUSY_box.Size = new Size(8, 8);
            BUSY_box.TabIndex = 48;
            BUSY_box.Text = "█";
            BUSY_box.TextAlign = HorizontalAlignment.Center;
            BUSY_box.WordWrap = false;
            // 
            // pwrControlTrackBar
            // 
            pwrControlTrackBar.BackColor = Color.DarkGreen;
            pwrControlTrackBar.Location = new Point(712, 1);
            pwrControlTrackBar.Maximum = 100;
            pwrControlTrackBar.Minimum = 5;
            pwrControlTrackBar.Name = "pwrControlTrackBar";
            pwrControlTrackBar.Orientation = Orientation.Vertical;
            pwrControlTrackBar.Size = new Size(45, 110);
            pwrControlTrackBar.TabIndex = 44;
            pwrControlTrackBar.TickFrequency = 5;
            pwrControlTrackBar.TickStyle = TickStyle.Both;
            pwrControlTrackBar.Value = 100;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Black;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox3.ForeColor = Color.Gold;
            textBox3.Location = new Point(712, 110);
            textBox3.Margin = new Padding(0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(40, 15);
            textBox3.TabIndex = 45;
            textBox3.TabStop = false;
            textBox3.Text = "00";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.WordWrap = false;
            // 
            // AMB
            // 
            AMB.BackColor = Color.DarkGreen;
            AMB.FlatAppearance.BorderColor = Color.White;
            AMB.FlatAppearance.MouseDownBackColor = Color.Red;
            AMB.FlatAppearance.MouseOverBackColor = Color.Blue;
            AMB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AMB.ForeColor = Color.Yellow;
            AMB.Location = new Point(469, 42);
            AMB.Name = "AMB";
            AMB.Size = new Size(44, 40);
            AMB.TabIndex = 49;
            AMB.Text = "AM";
            AMB.UseVisualStyleBackColor = false;
            // 
            // FMB
            // 
            FMB.BackColor = Color.DarkGreen;
            FMB.FlatAppearance.BorderColor = Color.White;
            FMB.FlatAppearance.MouseDownBackColor = Color.Red;
            FMB.FlatAppearance.MouseOverBackColor = Color.Blue;
            FMB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FMB.ForeColor = Color.Yellow;
            FMB.Location = new Point(513, 42);
            FMB.Name = "FMB";
            FMB.Size = new Size(44, 40);
            FMB.TabIndex = 50;
            FMB.Text = "FM";
            FMB.UseVisualStyleBackColor = false;
            // 
            // DIGB
            // 
            DIGB.BackColor = Color.DarkGreen;
            DIGB.FlatAppearance.BorderColor = Color.White;
            DIGB.FlatAppearance.MouseDownBackColor = Color.Red;
            DIGB.FlatAppearance.MouseOverBackColor = Color.Blue;
            DIGB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DIGB.ForeColor = Color.Yellow;
            DIGB.Location = new Point(513, 83);
            DIGB.Name = "DIGB";
            DIGB.Size = new Size(44, 40);
            DIGB.TabIndex = 51;
            DIGB.Text = "DIG";
            DIGB.UseVisualStyleBackColor = false;
            // 
            // IntTune
            // 
            IntTune.BackColor = Color.DarkGreen;
            IntTune.FlatAppearance.BorderColor = Color.White;
            IntTune.FlatAppearance.MouseDownBackColor = Color.Red;
            IntTune.FlatAppearance.MouseOverBackColor = Color.Blue;
            IntTune.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IntTune.ForeColor = Color.Yellow;
            IntTune.Location = new Point(762, 1);
            IntTune.Name = "IntTune";
            IntTune.Size = new Size(88, 40);
            IntTune.TabIndex = 55;
            IntTune.Text = "Int Tuner";
            IntTune.UseVisualStyleBackColor = false;
            // 
            // ItuneOn
            // 
            ItuneOn.BackColor = Color.DarkGreen;
            ItuneOn.FlatAppearance.BorderColor = Color.White;
            ItuneOn.FlatAppearance.MouseDownBackColor = Color.Red;
            ItuneOn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ItuneOn.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItuneOn.ForeColor = Color.Yellow;
            ItuneOn.Location = new Point(762, 42);
            ItuneOn.Name = "ItuneOn";
            ItuneOn.Size = new Size(44, 40);
            ItuneOn.TabIndex = 56;
            ItuneOn.Text = "On";
            ItuneOn.UseVisualStyleBackColor = false;
            // 
            // ItuneOff
            // 
            ItuneOff.BackColor = Color.DarkGreen;
            ItuneOff.FlatAppearance.BorderColor = Color.White;
            ItuneOff.FlatAppearance.MouseDownBackColor = Color.Red;
            ItuneOff.FlatAppearance.MouseOverBackColor = Color.Blue;
            ItuneOff.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItuneOff.ForeColor = Color.Yellow;
            ItuneOff.Location = new Point(806, 42);
            ItuneOff.Name = "ItuneOff";
            ItuneOff.Size = new Size(44, 40);
            ItuneOff.TabIndex = 57;
            ItuneOff.Text = "Off";
            ItuneOff.UseVisualStyleBackColor = false;
            // 
            // rfGainLabel
            // 
            rfGainLabel.AutoSize = true;
            rfGainLabel.BackColor = Color.DarkGreen;
            rfGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rfGainLabel.ForeColor = Color.Yellow;
            rfGainLabel.Location = new Point(562, 1);
            rfGainLabel.Name = "rfGainLabel";
            rfGainLabel.Size = new Size(44, 10);
            rfGainLabel.TabIndex = 0;
            rfGainLabel.Text = "MAIN RF";
            // 
            // volumeGainLabel
            // 
            volumeGainLabel.AutoSize = true;
            volumeGainLabel.BackColor = Color.DarkGreen;
            volumeGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            volumeGainLabel.ForeColor = Color.Yellow;
            volumeGainLabel.Location = new Point(612, 1);
            volumeGainLabel.Name = "volumeGainLabel";
            volumeGainLabel.Size = new Size(51, 10);
            volumeGainLabel.TabIndex = 0;
            volumeGainLabel.Text = "MAIN VOL";
            // 
            // pwrControlLabel
            // 
            pwrControlLabel.AutoSize = true;
            pwrControlLabel.BackColor = Color.DarkGreen;
            pwrControlLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pwrControlLabel.ForeColor = Color.Yellow;
            pwrControlLabel.Location = new Point(716, 1);
            pwrControlLabel.Name = "pwrControlLabel";
            pwrControlLabel.Size = new Size(38, 10);
            pwrControlLabel.TabIndex = 0;
            pwrControlLabel.Text = "POWER";
            pwrControlLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VFOA_box
            // 
            VFOA_box.BackColor = Color.DarkGreen;
            VFOA_box.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VFOA_box.ForeColor = Color.Yellow;
            VFOA_box.Location = new Point(36, 1);
            VFOA_box.Multiline = true;
            VFOA_box.Name = "VFOA_box";
            VFOA_box.Size = new Size(154, 33);
            VFOA_box.TabIndex = 44;
            VFOA_box.TabStop = false;
            VFOA_box.Text = "VFO-A";
            VFOA_box.TextAlign = HorizontalAlignment.Center;
            VFOA_box.WordWrap = false;
            // 
            // VFOB_box
            // 
            VFOB_box.BackColor = Color.DarkBlue;
            VFOB_box.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VFOB_box.ForeColor = Color.Yellow;
            VFOB_box.Location = new Point(36, 36);
            VFOB_box.Multiline = true;
            VFOB_box.Name = "VFOB_box";
            VFOB_box.Size = new Size(154, 33);
            VFOB_box.TabIndex = 45;
            VFOB_box.TabStop = false;
            VFOB_box.Text = "VFO-B";
            VFOB_box.TextAlign = HorizontalAlignment.Center;
            VFOB_box.WordWrap = false;
            // 
            // vfoALabel
            // 
            vfoALabel.BackColor = Color.DarkGreen;
            vfoALabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vfoALabel.ForeColor = Color.Yellow;
            vfoALabel.Location = new Point(2, 1);
            vfoALabel.Name = "vfoALabel";
            vfoALabel.Size = new Size(34, 33);
            vfoALabel.TabIndex = 0;
            vfoALabel.Text = "VFO-A";
            vfoALabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // vfoBLabel
            // 
            vfoBLabel.BackColor = Color.DarkBlue;
            vfoBLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            vfoBLabel.ForeColor = Color.Yellow;
            vfoBLabel.Location = new Point(2, 36);
            vfoBLabel.Name = "vfoBLabel";
            vfoBLabel.Size = new Size(34, 33);
            vfoBLabel.TabIndex = 0;
            vfoBLabel.Text = "VFO-B";
            vfoBLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MENU
            // 
            MENU.BackColor = Color.LimeGreen;
            MENU.FlatAppearance.BorderColor = Color.White;
            MENU.FlatAppearance.MouseDownBackColor = Color.Red;
            MENU.FlatAppearance.MouseOverBackColor = Color.Blue;
            MENU.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MENU.ForeColor = Color.Yellow;
            MENU.Location = new Point(102, 72);
            MENU.Name = "MENU";
            MENU.Size = new Size(88, 22);
            MENU.TabIndex = 59;
            MENU.Text = "MENU A";
            MENU.UseVisualStyleBackColor = false;
            // 
            // SQLtrackBar
            // 
            SQLtrackBar.BackColor = Color.DarkGreen;
            SQLtrackBar.Location = new Point(662, 1);
            SQLtrackBar.Maximum = 255;
            SQLtrackBar.Name = "SQLtrackBar";
            SQLtrackBar.Orientation = Orientation.Vertical;
            SQLtrackBar.Size = new Size(45, 110);
            SQLtrackBar.TabIndex = 61;
            SQLtrackBar.TickFrequency = 25;
            SQLtrackBar.TickStyle = TickStyle.Both;
            // 
            // SQLTextBox
            // 
            SQLTextBox.BackColor = Color.Black;
            SQLTextBox.BorderStyle = BorderStyle.None;
            SQLTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SQLTextBox.ForeColor = Color.Gold;
            SQLTextBox.Location = new Point(662, 110);
            SQLTextBox.Margin = new Padding(0);
            SQLTextBox.Multiline = true;
            SQLTextBox.Name = "SQLTextBox";
            SQLTextBox.Size = new Size(40, 15);
            SQLTextBox.TabIndex = 62;
            SQLTextBox.TabStop = false;
            SQLTextBox.Text = "00";
            SQLTextBox.TextAlign = HorizontalAlignment.Center;
            SQLTextBox.WordWrap = false;
            // 
            // SQLLabel
            // 
            SQLLabel.AutoSize = true;
            SQLLabel.BackColor = Color.DarkGreen;
            SQLLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SQLLabel.ForeColor = Color.Yellow;
            SQLLabel.Location = new Point(662, 1);
            SQLLabel.Name = "SQLLabel";
            SQLLabel.Size = new Size(48, 10);
            SQLLabel.TabIndex = 0;
            SQLLabel.Text = "SQUELCH";
            // 
            // MUTE
            // 
            MUTE.BackColor = Color.DarkGreen;
            MUTE.FlatAppearance.BorderColor = Color.White;
            MUTE.FlatAppearance.MouseDownBackColor = Color.Red;
            MUTE.FlatAppearance.MouseOverBackColor = Color.Blue;
            MUTE.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MUTE.ForeColor = Color.Yellow;
            MUTE.Location = new Point(376, 1);
            MUTE.Name = "MUTE";
            MUTE.Size = new Size(88, 40);
            MUTE.TabIndex = 63;
            MUTE.Text = "MUTE";
            MUTE.UseVisualStyleBackColor = false;
            // 
            // comPortComboBox
            // 
            comPortComboBox.BackColor = Color.DarkGreen;
            comPortComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comPortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comPortComboBox.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comPortComboBox.ForeColor = Color.Yellow;
            comPortComboBox.ItemHeight = 16;
            comPortComboBox.Location = new Point(1, 98);
            comPortComboBox.Name = "comPortComboBox";
            comPortComboBox.Size = new Size(88, 22);
            comPortComboBox.TabIndex = 64;
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.DarkGreen;
            connectButton.FlatAppearance.BorderColor = Color.White;
            connectButton.FlatAppearance.MouseDownBackColor = Color.Red;
            connectButton.FlatAppearance.MouseOverBackColor = Color.Blue;
            connectButton.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectButton.ForeColor = Color.Yellow;
            connectButton.Location = new Point(1, 72);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(88, 22);
            connectButton.TabIndex = 65;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = false;
            // 
            // MINB
            // 
            MINB.BackColor = Color.DarkGreen;
            MINB.FlatAppearance.BorderColor = Color.White;
            MINB.FlatAppearance.MouseDownBackColor = Color.Red;
            MINB.FlatAppearance.MouseOverBackColor = Color.Blue;
            MINB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MINB.ForeColor = Color.Yellow;
            MINB.Location = new Point(195, 42);
            MINB.Name = "MINB";
            MINB.Size = new Size(44, 40);
            MINB.TabIndex = 67;
            MINB.Text = "[-]";
            MINB.UseVisualStyleBackColor = false;
            // 
            // PLUSB
            // 
            PLUSB.BackColor = Color.DarkGreen;
            PLUSB.FlatAppearance.BorderColor = Color.White;
            PLUSB.FlatAppearance.MouseDownBackColor = Color.Red;
            PLUSB.FlatAppearance.MouseOverBackColor = Color.Blue;
            PLUSB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PLUSB.ForeColor = Color.Yellow;
            PLUSB.Location = new Point(237, 42);
            PLUSB.Name = "PLUSB";
            PLUSB.Size = new Size(45, 40);
            PLUSB.TabIndex = 68;
            PLUSB.Text = "[+]";
            PLUSB.UseVisualStyleBackColor = false;
            // 
            // BANDB
            // 
            BANDB.BackColor = Color.DarkGreen;
            BANDB.FlatAppearance.BorderColor = Color.White;
            BANDB.FlatAppearance.MouseDownBackColor = Color.Red;
            BANDB.FlatAppearance.MouseOverBackColor = Color.Blue;
            BANDB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BANDB.ForeColor = Color.Yellow;
            BANDB.Location = new Point(195, 1);
            BANDB.Name = "BANDB";
            BANDB.Size = new Size(88, 40);
            BANDB.TabIndex = 69;
            BANDB.Text = "BAND";
            BANDB.UseVisualStyleBackColor = false;
            // 
            // ABB
            // 
            ABB.BackColor = Color.DarkGreen;
            ABB.FlatAppearance.BorderColor = Color.White;
            ABB.FlatAppearance.MouseDownBackColor = Color.Red;
            ABB.FlatAppearance.MouseOverBackColor = Color.Blue;
            ABB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ABB.ForeColor = Color.Yellow;
            ABB.Location = new Point(195, 83);
            ABB.Name = "ABB";
            ABB.Size = new Size(88, 40);
            ABB.TabIndex = 70;
            ABB.Text = "A/B";
            ABB.UseVisualStyleBackColor = false;
            // 
            // STEP_combobox
            // 
            STEP_combobox.BackColor = Color.DarkGreen;
            STEP_combobox.DrawMode = DrawMode.OwnerDrawFixed;
            STEP_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            STEP_combobox.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            STEP_combobox.ForeColor = Color.Yellow;
            STEP_combobox.IntegralHeight = false;
            STEP_combobox.ItemHeight = 16;
            STEP_combobox.Location = new Point(101, 98);
            STEP_combobox.Name = "STEP_combobox";
            STEP_combobox.Size = new Size(88, 22);
            STEP_combobox.TabIndex = 71;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(850, 125);
            Controls.Add(STEP_combobox);
            Controls.Add(ABB);
            Controls.Add(BANDB);
            Controls.Add(PLUSB);
            Controls.Add(MINB);
            Controls.Add(connectButton);
            Controls.Add(comPortComboBox);
            Controls.Add(MUTE);
            Controls.Add(SQLLabel);
            Controls.Add(SQLTextBox);
            Controls.Add(SQLtrackBar);
            Controls.Add(MENU);
            Controls.Add(rfGainLabel);
            Controls.Add(volumeGainLabel);
            Controls.Add(pwrControlLabel);
            Controls.Add(ItuneOff);
            Controls.Add(ItuneOn);
            Controls.Add(IntTune);
            Controls.Add(DIGB);
            Controls.Add(FMB);
            Controls.Add(AMB);
            Controls.Add(BUSY_box);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(vfoBLabel);
            Controls.Add(vfoALabel);
            Controls.Add(VFOB_box);
            Controls.Add(VFOA_box);
            Controls.Add(volumeGainTrackBar);
            Controls.Add(rfGainTrackBar);
            Controls.Add(PROon);
            Controls.Add(PREoff);
            Controls.Add(ANT3RXB);
            Controls.Add(ANT2B);
            Controls.Add(ANT1B);
            Controls.Add(CWB);
            Controls.Add(LSBB);
            Controls.Add(USBB);
            Controls.Add(ExtTuneButton);
            Controls.Add(pwrControlTrackBar);
            Controls.Add(textBox3);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Yellow;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.Disable;
            Location = new Point(1, 1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            TransparencyKey = Color.Fuchsia;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SQLtrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ExtTuneButton;
        private System.Windows.Forms.Button USBB;
        private System.Windows.Forms.Button LSBB;
        private System.Windows.Forms.Button CWB;
        private System.Windows.Forms.Button ANT1B;
        private System.Windows.Forms.Button ANT2B;
        private System.Windows.Forms.Button ANT3RXB;
        private System.Windows.Forms.Button PREoff;
        private System.Windows.Forms.Button PROon;
        private System.Windows.Forms.TrackBar rfGainTrackBar;
        private System.Windows.Forms.TrackBar volumeGainTrackBar;
        private System.Windows.Forms.TrackBar pwrControlTrackBar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox BUSY_box;
        private System.Windows.Forms.Button AMB;
        private System.Windows.Forms.Button FMB;
        private System.Windows.Forms.Button DIGB;
        private System.Windows.Forms.Button IntTune;
        private System.Windows.Forms.Button ItuneOn;
        private System.Windows.Forms.Button ItuneOff;
        private System.Windows.Forms.Label rfGainLabel;
        private System.Windows.Forms.Label volumeGainLabel;
        private System.Windows.Forms.Label pwrControlLabel;
        private System.Windows.Forms.TextBox VFOA_box;
        private System.Windows.Forms.TextBox VFOB_box;
        private System.Windows.Forms.Label vfoALabel;
        private System.Windows.Forms.Label vfoBLabel;
        private System.Windows.Forms.Button MENU;
        private System.Windows.Forms.TrackBar SQLtrackBar;
        private System.Windows.Forms.TextBox SQLTextBox;
        private System.Windows.Forms.Label SQLLabel;
        private System.Windows.Forms.Button MUTE;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.Button connectButton;
        private Button MINB;
        private Button PLUSB;
        private Button BANDB;
        private Button ABB;
        private ComboBox STEP_combobox;
    }
}

