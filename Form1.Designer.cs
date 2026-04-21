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
            PREB = new Button();
            ATTB = new Button();
            rfGainTrackBar = new SilverKnobTrackBar();
            volumeGainTrackBar = new SilverKnobTrackBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            BUSY_box = new TextBox();
            pwrControlTrackBar = new SilverKnobTrackBar();
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
            SQLtrackBar = new SilverKnobTrackBar();
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
            LoWdTrackBar = new SilverKnobTrackBar();
            HiShTrackBar = new SilverKnobTrackBar();
            HiShLabel = new Label();
            LoWdLabel = new Label();
            HiShTextBox = new TextBox();
            LoWdTextBox = new TextBox();
            NB0B = new Button();
            NR0B = new Button();
            BC0B = new Button();
            NB1B = new Button();
            NB2B = new Button();
            NR1B = new Button();
            NR2B = new Button();
            BC1B = new Button();
            BC2B = new Button();
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SQLtrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LoWdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HiShTrackBar).BeginInit();
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
            ExtTuneButton.Location = new Point(426, 81);
            ExtTuneButton.Name = "ExtTuneButton";
            ExtTuneButton.Size = new Size(85, 40);
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
            USBB.Location = new Point(240, 120);
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
            LSBB.Location = new Point(284, 120);
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
            CWB.Location = new Point(240, 201);
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
            ANT1B.Location = new Point(329, 1);
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
            ANT2B.Location = new Point(329, 41);
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
            ANT3RXB.Location = new Point(329, 81);
            ANT3RXB.Name = "ANT3RXB";
            ANT3RXB.Size = new Size(88, 40);
            ANT3RXB.TabIndex = 27;
            ANT3RXB.Text = "RX ANT";
            ANT3RXB.UseVisualStyleBackColor = false;
            // 
            // PREB
            // 
            PREB.BackColor = Color.DarkGreen;
            PREB.FlatAppearance.BorderColor = Color.White;
            PREB.FlatAppearance.MouseDownBackColor = Color.Red;
            PREB.FlatAppearance.MouseOverBackColor = Color.Blue;
            PREB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PREB.ForeColor = Color.Yellow;
            PREB.Location = new Point(329, 121);
            PREB.Name = "PREB";
            PREB.Size = new Size(88, 40);
            PREB.TabIndex = 28;
            PREB.Text = "PRE";
            PREB.UseVisualStyleBackColor = false;
            // 
            // ATTB
            // 
            ATTB.BackColor = Color.DarkGreen;
            ATTB.FlatAppearance.BorderColor = Color.White;
            ATTB.FlatAppearance.MouseDownBackColor = Color.Red;
            ATTB.FlatAppearance.MouseOverBackColor = Color.Blue;
            ATTB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ATTB.ForeColor = Color.Yellow;
            ATTB.Location = new Point(329, 161);
            ATTB.Name = "ATTB";
            ATTB.Size = new Size(88, 40);
            ATTB.TabIndex = 29;
            ATTB.Text = "ATT";
            ATTB.UseVisualStyleBackColor = false;
            // 
            // rfGainTrackBar
            // 
            rfGainTrackBar.AutoSize = false;
            rfGainTrackBar.BackColor = Color.DarkGreen;
            rfGainTrackBar.KnobColor = Color.Silver;
            rfGainTrackBar.Location = new Point(1, 121);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = Orientation.Vertical;
            rfGainTrackBar.Size = new Size(45, 105);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = TickStyle.Both;
            rfGainTrackBar.Value = 255;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.AutoSize = false;
            volumeGainTrackBar.BackColor = Color.DarkGreen;
            volumeGainTrackBar.KnobColor = Color.Silver;
            volumeGainTrackBar.Location = new Point(48, 121);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = Orientation.Vertical;
            volumeGainTrackBar.Size = new Size(45, 105);
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
            textBox1.Location = new Point(3, 226);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(45, 16);
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
            textBox2.Location = new Point(49, 226);
            textBox2.Margin = new Padding(0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(45, 16);
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
            pwrControlTrackBar.AutoSize = false;
            pwrControlTrackBar.BackColor = Color.Maroon;
            pwrControlTrackBar.KnobColor = Color.Red;
            pwrControlTrackBar.Location = new Point(534, 12);
            pwrControlTrackBar.Maximum = 100;
            pwrControlTrackBar.Minimum = 5;
            pwrControlTrackBar.Name = "pwrControlTrackBar";
            pwrControlTrackBar.Orientation = Orientation.Vertical;
            pwrControlTrackBar.Size = new Size(40, 102);
            pwrControlTrackBar.TabIndex = 44;
            pwrControlTrackBar.TickFrequency = 6;
            pwrControlTrackBar.TickStyle = TickStyle.Both;
            pwrControlTrackBar.Value = 100;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Black;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox3.ForeColor = Color.Gold;
            textBox3.Location = new Point(534, 111);
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
            AMB.Location = new Point(240, 161);
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
            FMB.Location = new Point(284, 161);
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
            DIGB.Location = new Point(284, 201);
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
            IntTune.Location = new Point(423, 1);
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
            ItuneOn.Location = new Point(423, 41);
            ItuneOn.Name = "ItuneOn";
            ItuneOn.Size = new Size(45, 40);
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
            ItuneOff.Location = new Point(464, 41);
            ItuneOff.Name = "ItuneOff";
            ItuneOff.Size = new Size(44, 40);
            ItuneOff.TabIndex = 57;
            ItuneOff.Text = "Off";
            ItuneOff.UseVisualStyleBackColor = false;
            // 
            // rfGainLabel
            // 
            rfGainLabel.BackColor = Color.DarkGreen;
            rfGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rfGainLabel.ForeColor = Color.Yellow;
            rfGainLabel.Location = new Point(1, 111);
            rfGainLabel.Name = "rfGainLabel";
            rfGainLabel.Size = new Size(45, 12);
            rfGainLabel.TabIndex = 0;
            rfGainLabel.Text = "RF";
            rfGainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // volumeGainLabel
            // 
            volumeGainLabel.BackColor = Color.DarkGreen;
            volumeGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            volumeGainLabel.ForeColor = Color.Yellow;
            volumeGainLabel.Location = new Point(48, 111);
            volumeGainLabel.Name = "volumeGainLabel";
            volumeGainLabel.Size = new Size(44, 10);
            volumeGainLabel.TabIndex = 0;
            volumeGainLabel.Text = "VOL";
            volumeGainLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pwrControlLabel
            // 
            pwrControlLabel.BackColor = Color.Maroon;
            pwrControlLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pwrControlLabel.ForeColor = Color.Yellow;
            pwrControlLabel.Location = new Point(534, 1);
            pwrControlLabel.Name = "pwrControlLabel";
            pwrControlLabel.Size = new Size(40, 10);
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
            VFOA_box.Size = new Size(197, 50);
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
            VFOB_box.Location = new Point(36, 52);
            VFOB_box.Multiline = true;
            VFOB_box.Name = "VFOB_box";
            VFOB_box.Size = new Size(197, 50);
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
            MENU.Location = new Point(577, 213);
            MENU.Name = "MENU";
            MENU.Size = new Size(88, 22);
            MENU.TabIndex = 59;
            MENU.Text = "MENU A";
            MENU.UseVisualStyleBackColor = false;
            // 
            // SQLtrackBar
            // 
            SQLtrackBar.AutoSize = false;
            SQLtrackBar.BackColor = Color.DarkGreen;
            SQLtrackBar.KnobColor = Color.Silver;
            SQLtrackBar.Location = new Point(95, 121);
            SQLtrackBar.Maximum = 255;
            SQLtrackBar.Name = "SQLtrackBar";
            SQLtrackBar.Orientation = Orientation.Vertical;
            SQLtrackBar.Size = new Size(45, 105);
            SQLtrackBar.TabIndex = 61;
            SQLtrackBar.TickFrequency = 16;
            SQLtrackBar.TickStyle = TickStyle.Both;
            // 
            // SQLTextBox
            // 
            SQLTextBox.BackColor = Color.Black;
            SQLTextBox.BorderStyle = BorderStyle.None;
            SQLTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SQLTextBox.ForeColor = Color.Gold;
            SQLTextBox.Location = new Point(95, 226);
            SQLTextBox.Margin = new Padding(0);
            SQLTextBox.Multiline = true;
            SQLTextBox.Name = "SQLTextBox";
            SQLTextBox.Size = new Size(45, 16);
            SQLTextBox.TabIndex = 62;
            SQLTextBox.TabStop = false;
            SQLTextBox.Text = "00";
            SQLTextBox.TextAlign = HorizontalAlignment.Center;
            SQLTextBox.WordWrap = false;
            // 
            // SQLLabel
            // 
            SQLLabel.BackColor = Color.DarkGreen;
            SQLLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SQLLabel.ForeColor = Color.Yellow;
            SQLLabel.Location = new Point(95, 111);
            SQLLabel.Name = "SQLLabel";
            SQLLabel.Size = new Size(44, 10);
            SQLLabel.TabIndex = 0;
            SQLLabel.Text = "SQL";
            SQLLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MUTE
            // 
            MUTE.BackColor = Color.DarkGreen;
            MUTE.FlatAppearance.BorderColor = Color.White;
            MUTE.FlatAppearance.MouseDownBackColor = Color.Red;
            MUTE.FlatAppearance.MouseOverBackColor = Color.Blue;
            MUTE.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MUTE.ForeColor = Color.Yellow;
            MUTE.Location = new Point(329, 201);
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
            comPortComboBox.Location = new Point(577, 157);
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
            connectButton.Location = new Point(577, 129);
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
            MINB.Location = new Point(240, 41);
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
            PLUSB.Location = new Point(284, 41);
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
            BANDB.Location = new Point(240, 1);
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
            ABB.Location = new Point(240, 81);
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
            STEP_combobox.Location = new Point(577, 185);
            STEP_combobox.Name = "STEP_combobox";
            STEP_combobox.Size = new Size(88, 22);
            STEP_combobox.TabIndex = 71;
            // 
            // LoWdTrackBar
            // 
            LoWdTrackBar.AutoSize = false;
            LoWdTrackBar.BackColor = Color.DarkGreen;
            LoWdTrackBar.KnobColor = Color.Silver;
            LoWdTrackBar.Location = new Point(189, 121);
            LoWdTrackBar.Maximum = 255;
            LoWdTrackBar.Name = "LoWdTrackBar";
            LoWdTrackBar.Orientation = Orientation.Vertical;
            LoWdTrackBar.Size = new Size(45, 105);
            LoWdTrackBar.TabIndex = 72;
            LoWdTrackBar.TickFrequency = 16;
            LoWdTrackBar.TickStyle = TickStyle.Both;
            // 
            // HiShTrackBar
            // 
            HiShTrackBar.AutoSize = false;
            HiShTrackBar.BackColor = Color.DarkGreen;
            HiShTrackBar.KnobColor = Color.Silver;
            HiShTrackBar.Location = new Point(142, 121);
            HiShTrackBar.Maximum = 255;
            HiShTrackBar.Name = "HiShTrackBar";
            HiShTrackBar.Orientation = Orientation.Vertical;
            HiShTrackBar.Size = new Size(45, 105);
            HiShTrackBar.TabIndex = 73;
            HiShTrackBar.TickFrequency = 16;
            HiShTrackBar.TickStyle = TickStyle.Both;
            // 
            // HiShLabel
            // 
            HiShLabel.BackColor = Color.DarkGreen;
            HiShLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HiShLabel.ForeColor = Color.Yellow;
            HiShLabel.Location = new Point(142, 111);
            HiShLabel.Name = "HiShLabel";
            HiShLabel.Size = new Size(44, 10);
            HiShLabel.TabIndex = 74;
            HiShLabel.Text = "Hi/Shift";
            HiShLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoWdLabel
            // 
            LoWdLabel.BackColor = Color.DarkGreen;
            LoWdLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoWdLabel.ForeColor = Color.Yellow;
            LoWdLabel.Location = new Point(189, 111);
            LoWdLabel.Name = "LoWdLabel";
            LoWdLabel.Size = new Size(44, 10);
            LoWdLabel.TabIndex = 75;
            LoWdLabel.Text = "Lo/Width";
            LoWdLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HiShTextBox
            // 
            HiShTextBox.BackColor = Color.Black;
            HiShTextBox.BorderStyle = BorderStyle.None;
            HiShTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HiShTextBox.ForeColor = Color.Gold;
            HiShTextBox.Location = new Point(143, 226);
            HiShTextBox.Margin = new Padding(0);
            HiShTextBox.Multiline = true;
            HiShTextBox.Name = "HiShTextBox";
            HiShTextBox.Size = new Size(45, 16);
            HiShTextBox.TabIndex = 76;
            HiShTextBox.TabStop = false;
            HiShTextBox.Text = "00";
            HiShTextBox.TextAlign = HorizontalAlignment.Center;
            HiShTextBox.WordWrap = false;
            // 
            // LoWdTextBox
            // 
            LoWdTextBox.BackColor = Color.Black;
            LoWdTextBox.BorderStyle = BorderStyle.None;
            LoWdTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoWdTextBox.ForeColor = Color.Gold;
            LoWdTextBox.Location = new Point(188, 226);
            LoWdTextBox.Margin = new Padding(0);
            LoWdTextBox.Multiline = true;
            LoWdTextBox.Name = "LoWdTextBox";
            LoWdTextBox.Size = new Size(45, 16);
            LoWdTextBox.TabIndex = 77;
            LoWdTextBox.TabStop = false;
            LoWdTextBox.Text = "00";
            LoWdTextBox.TextAlign = HorizontalAlignment.Center;
            LoWdTextBox.WordWrap = false;
            // 
            // NB0B
            // 
            NB0B.BackColor = Color.DarkGreen;
            NB0B.FlatAppearance.BorderColor = Color.White;
            NB0B.FlatAppearance.MouseDownBackColor = Color.Red;
            NB0B.FlatAppearance.MouseOverBackColor = Color.Blue;
            NB0B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NB0B.ForeColor = Color.Yellow;
            NB0B.Location = new Point(423, 120);
            NB0B.Name = "NB0B";
            NB0B.Size = new Size(44, 40);
            NB0B.TabIndex = 78;
            NB0B.Text = "NB off";
            NB0B.UseVisualStyleBackColor = false;
            // 
            // NR0B
            // 
            NR0B.BackColor = Color.DarkGreen;
            NR0B.FlatAppearance.BorderColor = Color.White;
            NR0B.FlatAppearance.MouseDownBackColor = Color.Red;
            NR0B.FlatAppearance.MouseOverBackColor = Color.Blue;
            NR0B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NR0B.ForeColor = Color.Yellow;
            NR0B.Location = new Point(423, 161);
            NR0B.Name = "NR0B";
            NR0B.Size = new Size(44, 40);
            NR0B.TabIndex = 79;
            NR0B.Text = "NR off";
            NR0B.UseVisualStyleBackColor = false;
            // 
            // BC0B
            // 
            BC0B.BackColor = Color.DarkGreen;
            BC0B.FlatAppearance.BorderColor = Color.White;
            BC0B.FlatAppearance.MouseDownBackColor = Color.Red;
            BC0B.FlatAppearance.MouseOverBackColor = Color.Blue;
            BC0B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BC0B.ForeColor = Color.Yellow;
            BC0B.Location = new Point(423, 202);
            BC0B.Name = "BC0B";
            BC0B.Size = new Size(44, 40);
            BC0B.TabIndex = 80;
            BC0B.Text = "BC off";
            BC0B.UseVisualStyleBackColor = false;
            // 
            // NB1B
            // 
            NB1B.BackColor = Color.DarkGreen;
            NB1B.FlatAppearance.BorderColor = Color.White;
            NB1B.FlatAppearance.MouseDownBackColor = Color.Red;
            NB1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            NB1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NB1B.ForeColor = Color.Yellow;
            NB1B.Location = new Point(464, 120);
            NB1B.Name = "NB1B";
            NB1B.Size = new Size(44, 40);
            NB1B.TabIndex = 81;
            NB1B.Text = "NB\r\n1";
            NB1B.UseVisualStyleBackColor = false;
            // 
            // NB2B
            // 
            NB2B.BackColor = Color.DarkGreen;
            NB2B.FlatAppearance.BorderColor = Color.White;
            NB2B.FlatAppearance.MouseDownBackColor = Color.Red;
            NB2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            NB2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NB2B.ForeColor = Color.Yellow;
            NB2B.Location = new Point(504, 121);
            NB2B.Name = "NB2B";
            NB2B.Size = new Size(44, 40);
            NB2B.TabIndex = 82;
            NB2B.Text = "NB\r\n2";
            NB2B.UseVisualStyleBackColor = false;
            // 
            // NR1B
            // 
            NR1B.BackColor = Color.DarkGreen;
            NR1B.FlatAppearance.BorderColor = Color.White;
            NR1B.FlatAppearance.MouseDownBackColor = Color.Red;
            NR1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            NR1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NR1B.ForeColor = Color.Yellow;
            NR1B.Location = new Point(464, 161);
            NR1B.Name = "NR1B";
            NR1B.Size = new Size(44, 40);
            NR1B.TabIndex = 83;
            NR1B.Text = "NR\r\n1";
            NR1B.UseVisualStyleBackColor = false;
            // 
            // NR2B
            // 
            NR2B.BackColor = Color.DarkGreen;
            NR2B.FlatAppearance.BorderColor = Color.White;
            NR2B.FlatAppearance.MouseDownBackColor = Color.Red;
            NR2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            NR2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NR2B.ForeColor = Color.Yellow;
            NR2B.Location = new Point(504, 163);
            NR2B.Name = "NR2B";
            NR2B.Size = new Size(44, 40);
            NR2B.TabIndex = 84;
            NR2B.Text = "NR\r\n2";
            NR2B.UseVisualStyleBackColor = false;
            // 
            // BC1B
            // 
            BC1B.BackColor = Color.DarkGreen;
            BC1B.FlatAppearance.BorderColor = Color.White;
            BC1B.FlatAppearance.MouseDownBackColor = Color.Red;
            BC1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            BC1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BC1B.ForeColor = Color.Yellow;
            BC1B.Location = new Point(464, 201);
            BC1B.Name = "BC1B";
            BC1B.Size = new Size(44, 40);
            BC1B.TabIndex = 85;
            BC1B.Text = "BC\r\n1";
            BC1B.UseVisualStyleBackColor = false;
            // 
            // BC2B
            // 
            BC2B.BackColor = Color.DarkGreen;
            BC2B.FlatAppearance.BorderColor = Color.White;
            BC2B.FlatAppearance.MouseDownBackColor = Color.Red;
            BC2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            BC2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BC2B.ForeColor = Color.Yellow;
            BC2B.Location = new Point(504, 202);
            BC2B.Name = "BC2B";
            BC2B.Size = new Size(44, 40);
            BC2B.TabIndex = 86;
            BC2B.Text = "BC\r\n2";
            BC2B.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(961, 241);
            Controls.Add(BC2B);
            Controls.Add(BC1B);
            Controls.Add(NR2B);
            Controls.Add(NR1B);
            Controls.Add(NB2B);
            Controls.Add(NB1B);
            Controls.Add(BC0B);
            Controls.Add(NR0B);
            Controls.Add(NB0B);
            Controls.Add(LoWdTextBox);
            Controls.Add(HiShTextBox);
            Controls.Add(LoWdLabel);
            Controls.Add(HiShLabel);
            Controls.Add(HiShTrackBar);
            Controls.Add(LoWdTrackBar);
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
            Controls.Add(ATTB);
            Controls.Add(PREB);
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
            ((System.ComponentModel.ISupportInitialize)LoWdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)HiShTrackBar).EndInit();
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
        private System.Windows.Forms.Button PREB;
        private System.Windows.Forms.Button ATTB;
        private SilverKnobTrackBar rfGainTrackBar;
        private SilverKnobTrackBar volumeGainTrackBar;
        private SilverKnobTrackBar pwrControlTrackBar;
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
        private SilverKnobTrackBar SQLtrackBar;
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
        private SilverKnobTrackBar LoWdTrackBar;
        private SilverKnobTrackBar HiShTrackBar;
        private Label HiShLabel;
        private Label LoWdLabel;
        private TextBox HiShTextBox;
        private TextBox LoWdTextBox;
        private Button NB0B;
        private Button NR0B;
        private Button BC0B;
        private Button NB1B;
        private Button NB2B;
        private Button NR1B;
        private Button NR2B;
        private Button BC1B;
        private Button BC2B;
    }
}

