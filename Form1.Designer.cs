using System.Drawing;

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
            ExtTuneButton = new System.Windows.Forms.Button();
            USBB = new System.Windows.Forms.Button();
            LSBB = new System.Windows.Forms.Button();
            CWB = new System.Windows.Forms.Button();
            MODE_box = new System.Windows.Forms.TextBox();
            ANT1B = new System.Windows.Forms.Button();
            ANT2B = new System.Windows.Forms.Button();
            ANT3RXB = new System.Windows.Forms.Button();
            PREoff = new System.Windows.Forms.Button();
            PROon = new System.Windows.Forms.Button();
            ANT_box = new System.Windows.Forms.TextBox();
            IPO_box = new System.Windows.Forms.TextBox();
            rfGainTrackBar = new System.Windows.Forms.TrackBar();
            volumeGainTrackBar = new System.Windows.Forms.TrackBar();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            BUSY_box = new System.Windows.Forms.TextBox();
            pwrControlTrackBar = new System.Windows.Forms.TrackBar();
            textBox3 = new System.Windows.Forms.TextBox();
            AMB = new System.Windows.Forms.Button();
            FMB = new System.Windows.Forms.Button();
            DIGB = new System.Windows.Forms.Button();
            IntTune = new System.Windows.Forms.Button();
            ItuneOn = new System.Windows.Forms.Button();
            ItuneOff = new System.Windows.Forms.Button();
            textBox4 = new System.Windows.Forms.TextBox();
            rfGainLabel = new System.Windows.Forms.Label();
            volumeGainLabel = new System.Windows.Forms.Label();
            pwrControlLabel = new System.Windows.Forms.Label();
            VFO1_box = new System.Windows.Forms.TextBox();
            VFO2_box = new System.Windows.Forms.TextBox();
            MENU = new System.Windows.Forms.Button();
            SQLtrackBar = new System.Windows.Forms.TrackBar();
            SQLTextBox = new System.Windows.Forms.TextBox();
            SQLLabel = new System.Windows.Forms.Label();
            MUTE = new System.Windows.Forms.Button();
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
            ExtTuneButton.Location = new Point(650, 68);
            ExtTuneButton.Name = "ExtTuneButton";
            ExtTuneButton.Size = new Size(110, 33);
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
            USBB.Location = new Point(336, 0);
            USBB.Name = "USBB";
            USBB.Size = new Size(56, 35);
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
            LSBB.Location = new Point(391, 0);
            LSBB.Name = "LSBB";
            LSBB.Size = new Size(56, 35);
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
            CWB.Location = new Point(336, 68);
            CWB.Name = "CWB";
            CWB.Size = new Size(56, 35);
            CWB.TabIndex = 13;
            CWB.Text = "CW";
            CWB.UseVisualStyleBackColor = false;
            // 
            // MODE_box
            // 
            MODE_box.BackColor = Color.Black;
            MODE_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MODE_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MODE_box.ForeColor = Color.Cyan;
            MODE_box.Location = new Point(336, 103);
            MODE_box.Margin = new System.Windows.Forms.Padding(0);
            MODE_box.Name = "MODE_box";
            MODE_box.Size = new Size(111, 18);
            MODE_box.TabIndex = 23;
            MODE_box.TabStop = false;
            MODE_box.Text = "<MODE>";
            MODE_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ANT1B
            // 
            ANT1B.BackColor = Color.DarkGreen;
            ANT1B.FlatAppearance.BorderColor = Color.White;
            ANT1B.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT1B.ForeColor = Color.Yellow;
            ANT1B.Location = new Point(168, 0);
            ANT1B.Name = "ANT1B";
            ANT1B.Size = new Size(85, 35);
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
            ANT2B.Location = new Point(168, 34);
            ANT2B.Name = "ANT2B";
            ANT2B.Size = new Size(85, 35);
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
            ANT3RXB.Location = new Point(168, 68);
            ANT3RXB.Name = "ANT3RXB";
            ANT3RXB.Size = new Size(85, 35);
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
            PREoff.Location = new Point(252, 34);
            PREoff.Name = "PREoff";
            PREoff.Size = new Size(85, 35);
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
            PROon.Location = new Point(252, 68);
            PROon.Name = "PROon";
            PROon.Size = new Size(85, 35);
            PROon.TabIndex = 29;
            PROon.Text = "PRE on";
            PROon.UseVisualStyleBackColor = false;
            // 
            // ANT_box
            // 
            ANT_box.BackColor = Color.Black;
            ANT_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ANT_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT_box.ForeColor = Color.Cyan;
            ANT_box.Location = new Point(168, 103);
            ANT_box.Margin = new System.Windows.Forms.Padding(0);
            ANT_box.Name = "ANT_box";
            ANT_box.Size = new Size(84, 18);
            ANT_box.TabIndex = 31;
            ANT_box.TabStop = false;
            ANT_box.Text = "<ANT>";
            ANT_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPO_box
            // 
            IPO_box.BackColor = Color.Black;
            IPO_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            IPO_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IPO_box.ForeColor = Color.Cyan;
            IPO_box.Location = new Point(252, 103);
            IPO_box.Margin = new System.Windows.Forms.Padding(0);
            IPO_box.Name = "IPO_box";
            IPO_box.Size = new Size(84, 18);
            IPO_box.TabIndex = 32;
            IPO_box.TabStop = false;
            IPO_box.Text = "<PRE>";
            IPO_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rfGainTrackBar
            // 
            rfGainTrackBar.BackColor = Color.DarkGreen;
            rfGainTrackBar.Location = new Point(450, 1);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            rfGainTrackBar.Size = new Size(45, 102);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            rfGainTrackBar.Value = 255;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.BackColor = Color.DarkGreen;
            volumeGainTrackBar.Location = new Point(501, 1);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            volumeGainTrackBar.Size = new Size(45, 102);
            volumeGainTrackBar.TabIndex = 43;
            volumeGainTrackBar.TickFrequency = 16;
            volumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            volumeGainTrackBar.Value = 60;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox1.ForeColor = Color.Cyan;
            textBox1.Location = new Point(452, 106);
            textBox1.Margin = new System.Windows.Forms.Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(40, 15);
            textBox1.TabIndex = 46;
            textBox1.TabStop = false;
            textBox1.Text = "00";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox1.WordWrap = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox2.ForeColor = Color.Cyan;
            textBox2.Location = new Point(503, 106);
            textBox2.Margin = new System.Windows.Forms.Padding(0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(40, 15);
            textBox2.TabIndex = 47;
            textBox2.TabStop = false;
            textBox2.Text = "00";
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox2.WordWrap = false;
            // 
            // BUSY_box
            // 
            BUSY_box.BackColor = Color.Black;
            BUSY_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            BUSY_box.ForeColor = Color.FromArgb(64, 64, 64);
            BUSY_box.Location = new Point(160, 107);
            BUSY_box.Margin = new System.Windows.Forms.Padding(1);
            BUSY_box.Multiline = true;
            BUSY_box.Name = "BUSY_box";
            BUSY_box.Size = new Size(8, 8);
            BUSY_box.TabIndex = 48;
            BUSY_box.Text = "█";
            BUSY_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            BUSY_box.WordWrap = false;
            // 
            // pwrControlTrackBar
            // 
            pwrControlTrackBar.BackColor = Color.DarkGreen;
            pwrControlTrackBar.Location = new Point(603, 1);
            pwrControlTrackBar.Maximum = 100;
            pwrControlTrackBar.Minimum = 5;
            pwrControlTrackBar.Name = "pwrControlTrackBar";
            pwrControlTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            pwrControlTrackBar.Size = new Size(45, 102);
            pwrControlTrackBar.TabIndex = 44;
            pwrControlTrackBar.TickFrequency = 5;
            pwrControlTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            pwrControlTrackBar.Value = 100;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Black;
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox3.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox3.ForeColor = Color.Cyan;
            textBox3.Location = new Point(605, 106);
            textBox3.Margin = new System.Windows.Forms.Padding(0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(40, 15);
            textBox3.TabIndex = 45;
            textBox3.TabStop = false;
            textBox3.Text = "100";
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            AMB.Location = new Point(336, 34);
            AMB.Name = "AMB";
            AMB.Size = new Size(56, 35);
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
            FMB.Location = new Point(391, 34);
            FMB.Name = "FMB";
            FMB.Size = new Size(56, 35);
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
            DIGB.Location = new Point(391, 68);
            DIGB.Name = "DIGB";
            DIGB.Size = new Size(56, 35);
            DIGB.TabIndex = 51;
            DIGB.Text = "DATA";
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
            IntTune.Location = new Point(650, 0);
            IntTune.Name = "IntTune";
            IntTune.Size = new Size(110, 35);
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
            ItuneOn.Location = new Point(650, 34);
            ItuneOn.Name = "ItuneOn";
            ItuneOn.Size = new Size(56, 35);
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
            ItuneOff.Location = new Point(704, 34);
            ItuneOff.Name = "ItuneOff";
            ItuneOff.Size = new Size(56, 35);
            ItuneOff.TabIndex = 57;
            ItuneOff.Text = "Off";
            ItuneOff.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.Black;
            textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.ForeColor = Color.Cyan;
            textBox4.Location = new Point(654, 103);
            textBox4.Margin = new System.Windows.Forms.Padding(0);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(105, 18);
            textBox4.TabIndex = 58;
            textBox4.TabStop = false;
            textBox4.Text = "<INT TUN>";
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rfGainLabel
            // 
            rfGainLabel.AutoSize = true;
            rfGainLabel.BackColor = Color.DarkGreen;
            rfGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rfGainLabel.ForeColor = Color.Yellow;
            rfGainLabel.Location = new Point(451, 0);
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
            volumeGainLabel.Location = new Point(501, 0);
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
            pwrControlLabel.Location = new Point(603, 1);
            pwrControlLabel.Name = "pwrControlLabel";
            pwrControlLabel.Size = new Size(38, 10);
            pwrControlLabel.TabIndex = 0;
            pwrControlLabel.Text = "POWER";
            // 
            // VFO1_box
            // 
            VFO1_box.BackColor = Color.DarkGreen;
            VFO1_box.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VFO1_box.ForeColor = Color.Yellow;
            VFO1_box.Location = new Point(2, 1);
            VFO1_box.Multiline = true;
            VFO1_box.Name = "VFO1_box";
            VFO1_box.Size = new Size(166, 33);
            VFO1_box.TabIndex = 44;
            VFO1_box.TabStop = false;
            VFO1_box.Text = "VFO1";
            VFO1_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            VFO1_box.WordWrap = false;
            // 
            // VFO2_box
            // 
            VFO2_box.BackColor = Color.DarkBlue;
            VFO2_box.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VFO2_box.ForeColor = Color.Yellow;
            VFO2_box.Location = new Point(2, 36);
            VFO2_box.Multiline = true;
            VFO2_box.Name = "VFO2_box";
            VFO2_box.Size = new Size(166, 33);
            VFO2_box.TabIndex = 45;
            VFO2_box.TabStop = false;
            VFO2_box.Text = "VFO2";
            VFO2_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            VFO2_box.WordWrap = false;
            // 
            // MENU
            // 
            MENU.BackColor = Color.LimeGreen;
            MENU.FlatAppearance.BorderColor = Color.White;
            MENU.FlatAppearance.MouseDownBackColor = Color.Red;
            MENU.FlatAppearance.MouseOverBackColor = Color.Blue;
            MENU.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MENU.ForeColor = Color.Yellow;
            MENU.Location = new Point(1, 68);
            MENU.Name = "MENU";
            MENU.Size = new Size(168, 35);
            MENU.TabIndex = 59;
            MENU.Text = "MENU A";
            MENU.UseVisualStyleBackColor = false;
            // 
            // SQLtrackBar
            // 
            SQLtrackBar.BackColor = Color.DarkGreen;
            SQLtrackBar.Location = new Point(552, 1);
            SQLtrackBar.Maximum = 255;
            SQLtrackBar.Name = "SQLtrackBar";
            SQLtrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SQLtrackBar.Size = new Size(45, 102);
            SQLtrackBar.TabIndex = 61;
            SQLtrackBar.TickFrequency = 25;
            SQLtrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // SQLTextBox
            // 
            SQLTextBox.BackColor = Color.Black;
            SQLTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SQLTextBox.Font = new Font("Verdana", 8F, FontStyle.Bold);
            SQLTextBox.ForeColor = Color.Cyan;
            SQLTextBox.Location = new Point(554, 106);
            SQLTextBox.Margin = new System.Windows.Forms.Padding(0);
            SQLTextBox.Multiline = true;
            SQLTextBox.Name = "SQLTextBox";
            SQLTextBox.Size = new Size(40, 15);
            SQLTextBox.TabIndex = 62;
            SQLTextBox.TabStop = false;
            SQLTextBox.Text = "000";
            SQLTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            SQLTextBox.WordWrap = false;
            // 
            // SQLLabel
            // 
            SQLLabel.AutoSize = true;
            SQLLabel.BackColor = Color.DarkGreen;
            SQLLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SQLLabel.ForeColor = Color.Yellow;
            SQLLabel.Location = new Point(552, 1);
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
            MUTE.Location = new Point(252, 0);
            MUTE.Name = "MUTE";
            MUTE.Size = new Size(85, 35);
            MUTE.TabIndex = 63;
            MUTE.Text = "MUTE";
            MUTE.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(761, 125);
            Controls.Add(MUTE);
            Controls.Add(SQLLabel);
            Controls.Add(SQLTextBox);
            Controls.Add(SQLtrackBar);
            Controls.Add(MENU);
            Controls.Add(rfGainLabel);
            Controls.Add(volumeGainLabel);
            Controls.Add(pwrControlLabel);
            Controls.Add(textBox4);
            Controls.Add(ItuneOff);
            Controls.Add(ItuneOn);
            Controls.Add(IntTune);
            Controls.Add(DIGB);
            Controls.Add(FMB);
            Controls.Add(AMB);
            Controls.Add(BUSY_box);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(VFO2_box);
            Controls.Add(VFO1_box);
            Controls.Add(volumeGainTrackBar);
            Controls.Add(rfGainTrackBar);
            Controls.Add(IPO_box);
            Controls.Add(ANT_box);
            Controls.Add(PROon);
            Controls.Add(PREoff);
            Controls.Add(ANT3RXB);
            Controls.Add(ANT2B);
            Controls.Add(ANT1B);
            Controls.Add(MODE_box);
            Controls.Add(CWB);
            Controls.Add(LSBB);
            Controls.Add(USBB);
            Controls.Add(ExtTuneButton);
            Controls.Add(pwrControlTrackBar);
            Controls.Add(textBox3);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.Yellow;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ImeMode = System.Windows.Forms.ImeMode.Disable;
            Location = new Point(1, 1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            TransparencyKey = Color.Fuchsia;
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
        private System.Windows.Forms.TextBox MODE_box;
        private System.Windows.Forms.Button ANT1B;
        private System.Windows.Forms.Button ANT2B;
        private System.Windows.Forms.Button ANT3RXB;
        private System.Windows.Forms.Button PREoff;
        private System.Windows.Forms.Button PROon;
        private System.Windows.Forms.TextBox ANT_box;
        private System.Windows.Forms.TextBox IPO_box;
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
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label rfGainLabel;
        private System.Windows.Forms.Label volumeGainLabel;
        private System.Windows.Forms.Label pwrControlLabel;
        private System.Windows.Forms.TextBox VFO1_box;
        private System.Windows.Forms.TextBox VFO2_box;
        private System.Windows.Forms.Button MENU;
        private System.Windows.Forms.TrackBar SQLtrackBar;
        private System.Windows.Forms.TextBox SQLTextBox;
        private System.Windows.Forms.Label SQLLabel;
        private System.Windows.Forms.Button MUTE;
    }
}

