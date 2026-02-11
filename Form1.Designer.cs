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
            RFSQL_box = new System.Windows.Forms.TextBox();
            TEMP_box = new System.Windows.Forms.TextBox();
            ExtTuneButton = new System.Windows.Forms.Button();
            CursorB = new System.Windows.Forms.Button();
            CenterB = new System.Windows.Forms.Button();
            USBB = new System.Windows.Forms.Button();
            LSBB = new System.Windows.Forms.Button();
            CWB = new System.Windows.Forms.Button();
            RFTOGGLE = new System.Windows.Forms.Button();
            DSPMOD_box = new System.Windows.Forms.TextBox();
            MODE_box = new System.Windows.Forms.TextBox();
            ANT1B = new System.Windows.Forms.Button();
            ANT2B = new System.Windows.Forms.Button();
            ANT3RXB = new System.Windows.Forms.Button();
            IPOB = new System.Windows.Forms.Button();
            AMP1B = new System.Windows.Forms.Button();
            AMP2B = new System.Windows.Forms.Button();
            ANT_box = new System.Windows.Forms.TextBox();
            IPO_box = new System.Windows.Forms.TextBox();
            RX1B = new System.Windows.Forms.Button();
            RX2 = new System.Windows.Forms.Button();
            RX12B = new System.Windows.Forms.Button();
            RX_box = new System.Windows.Forms.TextBox();
            SSB1 = new System.Windows.Forms.Button();
            SSB2 = new System.Windows.Forms.Button();
            SSB3 = new System.Windows.Forms.Button();
            DSPSPAN_box = new System.Windows.Forms.TextBox();
            FixB = new System.Windows.Forms.Button();
            rfGainTrackBar = new System.Windows.Forms.TrackBar();
            volumeGainTrackBar = new System.Windows.Forms.TrackBar();
            FreqM_box = new System.Windows.Forms.TextBox();
            FreqS_box = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            BUSY_box = new System.Windows.Forms.TextBox();
            pwrControlTrackBar = new System.Windows.Forms.TrackBar();
            textBox3 = new System.Windows.Forms.TextBox();
            AMB = new System.Windows.Forms.Button();
            FMB = new System.Windows.Forms.Button();
            DIGB = new System.Windows.Forms.Button();
            SSB4 = new System.Windows.Forms.Button();
            SSB5 = new System.Windows.Forms.Button();
            SSB6 = new System.Windows.Forms.Button();
            IntTune = new System.Windows.Forms.Button();
            ItuneOn = new System.Windows.Forms.Button();
            ItuneOff = new System.Windows.Forms.Button();
            textBox4 = new System.Windows.Forms.TextBox();
            SubrfGainTrackBar = new System.Windows.Forms.TrackBar();
            SubvolumeGainTrackBar = new System.Windows.Forms.TrackBar();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox6 = new System.Windows.Forms.TextBox();
            SWAP = new System.Windows.Forms.Button();
            rfGainLabel = new System.Windows.Forms.Label();
            volumeGainLabel = new System.Windows.Forms.Label();
            pwrControlLabel = new System.Windows.Forms.Label();
            SubrfGainLabel = new System.Windows.Forms.Label();
            SubvolumeGainLabel = new System.Windows.Forms.Label();
            RX12off = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubrfGainTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SubvolumeGainTrackBar).BeginInit();
            SuspendLayout();
            // 
            // RFSQL_box
            // 
            RFSQL_box.BackColor = Color.Black;
            RFSQL_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            RFSQL_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RFSQL_box.ForeColor = Color.Cyan;
            RFSQL_box.Location = new Point(84, 103);
            RFSQL_box.Margin = new System.Windows.Forms.Padding(0);
            RFSQL_box.Name = "RFSQL_box";
            RFSQL_box.Size = new Size(84, 18);
            RFSQL_box.TabIndex = 4;
            RFSQL_box.TabStop = false;
            RFSQL_box.Text = "<RF/SQL>";
            RFSQL_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            RFSQL_box.TextChanged += TextBox2_TextChanged;
            // 
            // TEMP_box
            // 
            TEMP_box.BackColor = Color.Black;
            TEMP_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TEMP_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TEMP_box.ForeColor = Color.Cyan;
            TEMP_box.Location = new Point(20, 103);
            TEMP_box.Margin = new System.Windows.Forms.Padding(0);
            TEMP_box.Multiline = true;
            TEMP_box.Name = "TEMP_box";
            TEMP_box.Size = new Size(54, 20);
            TEMP_box.TabIndex = 5;
            TEMP_box.TabStop = false;
            TEMP_box.Text = "00°C";
            TEMP_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            TEMP_box.WordWrap = false;
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
            ExtTuneButton.Location = new Point(824, 70);
            ExtTuneButton.Name = "ExtTuneButton";
            ExtTuneButton.Size = new Size(86, 33);
            ExtTuneButton.TabIndex = 8;
            ExtTuneButton.Text = "Ext Tuner";
            ExtTuneButton.UseVisualStyleBackColor = false;
            ExtTuneButton.MouseDown += TuneButton_MouseDown;
            ExtTuneButton.MouseUp += TuneButton_MouseUp;
            // 
            // CursorB
            // 
            CursorB.BackColor = Color.DarkGreen;
            CursorB.FlatAppearance.BorderColor = Color.White;
            CursorB.FlatAppearance.MouseDownBackColor = Color.Red;
            CursorB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CursorB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CursorB.ForeColor = Color.Yellow;
            CursorB.Location = new Point(506, 0);
            CursorB.Name = "CursorB";
            CursorB.Size = new Size(85, 35);
            CursorB.TabIndex = 9;
            CursorB.Text = "CURSOR";
            CursorB.UseVisualStyleBackColor = false;
            CursorB.MouseClick += Cursor_Click;
            // 
            // CenterB
            // 
            CenterB.BackColor = Color.DarkGreen;
            CenterB.FlatAppearance.BorderColor = Color.White;
            CenterB.FlatAppearance.MouseDownBackColor = Color.Red;
            CenterB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CenterB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CenterB.ForeColor = Color.Yellow;
            CenterB.Location = new Point(506, 34);
            CenterB.Name = "CenterB";
            CenterB.Size = new Size(85, 35);
            CenterB.TabIndex = 10;
            CenterB.Text = "CENTER";
            CenterB.UseVisualStyleBackColor = false;
            CenterB.MouseClick += Center_Click;
            // 
            // USBB
            // 
            USBB.BackColor = Color.DarkGreen;
            USBB.FlatAppearance.BorderColor = Color.White;
            USBB.FlatAppearance.MouseDownBackColor = Color.Red;
            USBB.FlatAppearance.MouseOverBackColor = Color.Blue;
            USBB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            USBB.ForeColor = Color.Yellow;
            USBB.Location = new Point(421, 0);
            USBB.Name = "USBB";
            USBB.Size = new Size(44, 35);
            USBB.TabIndex = 11;
            USBB.Text = "USB";
            USBB.UseVisualStyleBackColor = false;
            USBB.MouseClick += USB_click;
            // 
            // LSBB
            // 
            LSBB.BackColor = Color.DarkGreen;
            LSBB.FlatAppearance.BorderColor = Color.White;
            LSBB.FlatAppearance.MouseDownBackColor = Color.Red;
            LSBB.FlatAppearance.MouseOverBackColor = Color.Blue;
            LSBB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LSBB.ForeColor = Color.Yellow;
            LSBB.Location = new Point(464, 0);
            LSBB.Name = "LSBB";
            LSBB.Size = new Size(44, 35);
            LSBB.TabIndex = 12;
            LSBB.Text = "LSB";
            LSBB.UseVisualStyleBackColor = false;
            LSBB.MouseClick += LSB_click;
            // 
            // CWB
            // 
            CWB.BackColor = Color.DarkGreen;
            CWB.FlatAppearance.BorderColor = Color.White;
            CWB.FlatAppearance.MouseDownBackColor = Color.Red;
            CWB.FlatAppearance.MouseOverBackColor = Color.Blue;
            CWB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CWB.ForeColor = Color.Yellow;
            CWB.Location = new Point(421, 68);
            CWB.Name = "CWB";
            CWB.Size = new Size(44, 35);
            CWB.TabIndex = 13;
            CWB.Text = "CW";
            CWB.UseVisualStyleBackColor = false;
            CWB.MouseClick += CW_click;
            // 
            // RFTOGGLE
            // 
            RFTOGGLE.BackColor = Color.DarkGreen;
            RFTOGGLE.FlatAppearance.BorderColor = Color.White;
            RFTOGGLE.FlatAppearance.MouseDownBackColor = Color.Red;
            RFTOGGLE.FlatAppearance.MouseOverBackColor = Color.Blue;
            RFTOGGLE.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RFTOGGLE.ForeColor = Color.Yellow;
            RFTOGGLE.Location = new Point(84, 68);
            RFTOGGLE.Name = "RFTOGGLE";
            RFTOGGLE.Size = new Size(86, 35);
            RFTOGGLE.TabIndex = 20;
            RFTOGGLE.Text = "RF / SQL";
            RFTOGGLE.UseVisualStyleBackColor = false;
            RFTOGGLE.MouseClick += RFB_click;
            // 
            // DSPMOD_box
            // 
            DSPMOD_box.BackColor = Color.Black;
            DSPMOD_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DSPMOD_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DSPMOD_box.ForeColor = Color.Cyan;
            DSPMOD_box.Location = new Point(506, 103);
            DSPMOD_box.Margin = new System.Windows.Forms.Padding(0);
            DSPMOD_box.Name = "DSPMOD_box";
            DSPMOD_box.Size = new Size(84, 18);
            DSPMOD_box.TabIndex = 22;
            DSPMOD_box.TabStop = false;
            DSPMOD_box.Text = "<DSPMOD>";
            DSPMOD_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MODE_box
            // 
            MODE_box.BackColor = Color.Black;
            MODE_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MODE_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MODE_box.ForeColor = Color.Cyan;
            MODE_box.Location = new Point(425, 103);
            MODE_box.Margin = new System.Windows.Forms.Padding(0);
            MODE_box.Name = "MODE_box";
            MODE_box.Size = new Size(84, 18);
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
            ANT1B.Location = new Point(253, 0);
            ANT1B.Name = "ANT1B";
            ANT1B.Size = new Size(85, 35);
            ANT1B.TabIndex = 25;
            ANT1B.Text = "ANT1";
            ANT1B.UseVisualStyleBackColor = false;
            ANT1B.MouseClick += ANT1B_click;
            // 
            // ANT2B
            // 
            ANT2B.BackColor = Color.DarkGreen;
            ANT2B.FlatAppearance.BorderColor = Color.White;
            ANT2B.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT2B.ForeColor = Color.Yellow;
            ANT2B.Location = new Point(253, 34);
            ANT2B.Name = "ANT2B";
            ANT2B.Size = new Size(85, 35);
            ANT2B.TabIndex = 26;
            ANT2B.Text = "ANT2";
            ANT2B.UseVisualStyleBackColor = false;
            ANT2B.MouseClick += ANT2B_click;
            // 
            // ANT3RXB
            // 
            ANT3RXB.BackColor = Color.DarkGreen;
            ANT3RXB.FlatAppearance.BorderColor = Color.White;
            ANT3RXB.FlatAppearance.MouseDownBackColor = Color.Red;
            ANT3RXB.FlatAppearance.MouseOverBackColor = Color.Blue;
            ANT3RXB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT3RXB.ForeColor = Color.Yellow;
            ANT3RXB.Location = new Point(253, 68);
            ANT3RXB.Name = "ANT3RXB";
            ANT3RXB.Size = new Size(85, 35);
            ANT3RXB.TabIndex = 27;
            ANT3RXB.Text = "ANT3/RX";
            ANT3RXB.UseVisualStyleBackColor = false;
            ANT3RXB.MouseClick += ANT3RXB_click;
            // 
            // IPOB
            // 
            IPOB.BackColor = Color.DarkGreen;
            IPOB.FlatAppearance.BorderColor = Color.White;
            IPOB.FlatAppearance.MouseDownBackColor = Color.Red;
            IPOB.FlatAppearance.MouseOverBackColor = Color.Blue;
            IPOB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IPOB.ForeColor = Color.Yellow;
            IPOB.Location = new Point(337, 0);
            IPOB.Name = "IPOB";
            IPOB.Size = new Size(85, 35);
            IPOB.TabIndex = 28;
            IPOB.Text = "IPO";
            IPOB.UseVisualStyleBackColor = false;
            IPOB.MouseClick += IPOB_click;
            // 
            // AMP1B
            // 
            AMP1B.BackColor = Color.DarkGreen;
            AMP1B.FlatAppearance.BorderColor = Color.White;
            AMP1B.FlatAppearance.MouseDownBackColor = Color.Red;
            AMP1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            AMP1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AMP1B.ForeColor = Color.Yellow;
            AMP1B.Location = new Point(337, 34);
            AMP1B.Name = "AMP1B";
            AMP1B.Size = new Size(85, 35);
            AMP1B.TabIndex = 29;
            AMP1B.Text = "AMP1";
            AMP1B.UseVisualStyleBackColor = false;
            AMP1B.MouseClick += AMP1B_click;
            // 
            // AMP2B
            // 
            AMP2B.BackColor = Color.DarkGreen;
            AMP2B.FlatAppearance.BorderColor = Color.White;
            AMP2B.FlatAppearance.MouseDownBackColor = Color.Red;
            AMP2B.FlatAppearance.MouseOverBackColor = Color.Blue;
            AMP2B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AMP2B.ForeColor = Color.Yellow;
            AMP2B.Location = new Point(337, 68);
            AMP2B.Name = "AMP2B";
            AMP2B.Size = new Size(85, 35);
            AMP2B.TabIndex = 30;
            AMP2B.Text = "AMP2";
            AMP2B.UseVisualStyleBackColor = false;
            AMP2B.MouseClick += AMP2B_click;
            // 
            // ANT_box
            // 
            ANT_box.BackColor = Color.Black;
            ANT_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ANT_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ANT_box.ForeColor = Color.Cyan;
            ANT_box.Location = new Point(253, 103);
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
            IPO_box.Location = new Point(337, 103);
            IPO_box.Margin = new System.Windows.Forms.Padding(0);
            IPO_box.Name = "IPO_box";
            IPO_box.Size = new Size(84, 18);
            IPO_box.TabIndex = 32;
            IPO_box.TabStop = false;
            IPO_box.Text = "<IPO>";
            IPO_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RX1B
            // 
            RX1B.BackColor = Color.DarkGreen;
            RX1B.FlatAppearance.BorderColor = Color.White;
            RX1B.FlatAppearance.MouseDownBackColor = Color.Red;
            RX1B.FlatAppearance.MouseOverBackColor = Color.Blue;
            RX1B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RX1B.ForeColor = Color.Yellow;
            RX1B.Location = new Point(168, 0);
            RX1B.Name = "RX1B";
            RX1B.Size = new Size(44, 35);
            RX1B.TabIndex = 33;
            RX1B.Text = "RX 1";
            RX1B.UseVisualStyleBackColor = false;
            RX1B.MouseClick += RX1B_click;
            // 
            // RX2
            // 
            RX2.BackColor = Color.DarkGreen;
            RX2.FlatAppearance.BorderColor = Color.White;
            RX2.FlatAppearance.MouseDownBackColor = Color.Red;
            RX2.FlatAppearance.MouseOverBackColor = Color.Blue;
            RX2.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RX2.ForeColor = Color.Yellow;
            RX2.Location = new Point(210, 0);
            RX2.Name = "RX2";
            RX2.Size = new Size(44, 35);
            RX2.TabIndex = 34;
            RX2.Text = "RX 2";
            RX2.UseVisualStyleBackColor = false;
            RX2.MouseClick += RX2B_click;
            // 
            // RX12B
            // 
            RX12B.BackColor = Color.DarkGreen;
            RX12B.FlatAppearance.BorderColor = Color.White;
            RX12B.FlatAppearance.MouseDownBackColor = Color.Red;
            RX12B.FlatAppearance.MouseOverBackColor = Color.Blue;
            RX12B.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RX12B.ForeColor = Color.Yellow;
            RX12B.Location = new Point(168, 34);
            RX12B.Name = "RX12B";
            RX12B.Size = new Size(86, 35);
            RX12B.TabIndex = 35;
            RX12B.Text = "RX 1 + 2";
            RX12B.UseVisualStyleBackColor = false;
            RX12B.MouseClick += RX12B_click;
            RX12B.MouseDown += RX12B_MouseDown;
            // 
            // RX_box
            // 
            RX_box.BackColor = Color.Black;
            RX_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            RX_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RX_box.ForeColor = Color.Cyan;
            RX_box.Location = new Point(168, 103);
            RX_box.Margin = new System.Windows.Forms.Padding(0);
            RX_box.Name = "RX_box";
            RX_box.Size = new Size(84, 18);
            RX_box.TabIndex = 36;
            RX_box.TabStop = false;
            RX_box.Text = "<RX>";
            RX_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            RX_box.TextChanged += RX_box_TextChanged;
            // 
            // SSB1
            // 
            SSB1.BackColor = Color.DarkGreen;
            SSB1.FlatAppearance.BorderColor = Color.White;
            SSB1.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB1.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB1.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB1.ForeColor = Color.Yellow;
            SSB1.Location = new Point(589, 34);
            SSB1.Name = "SSB1";
            SSB1.Size = new Size(44, 35);
            SSB1.TabIndex = 37;
            SSB1.Text = "100";
            SSB1.UseVisualStyleBackColor = false;
            SSB1.MouseClick += SSB1_click;
            // 
            // SSB2
            // 
            SSB2.BackColor = Color.DarkGreen;
            SSB2.FlatAppearance.BorderColor = Color.White;
            SSB2.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB2.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB2.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB2.ForeColor = Color.Yellow;
            SSB2.Location = new Point(631, 34);
            SSB2.Name = "SSB2";
            SSB2.Size = new Size(44, 35);
            SSB2.TabIndex = 38;
            SSB2.Text = "200";
            SSB2.UseVisualStyleBackColor = false;
            SSB2.MouseClick += SSB2_click;
            // 
            // SSB3
            // 
            SSB3.BackColor = Color.DarkGreen;
            SSB3.FlatAppearance.BorderColor = Color.White;
            SSB3.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB3.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB3.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB3.ForeColor = Color.Yellow;
            SSB3.Location = new Point(589, 68);
            SSB3.Name = "SSB3";
            SSB3.Size = new Size(44, 35);
            SSB3.TabIndex = 39;
            SSB3.Text = "500";
            SSB3.UseVisualStyleBackColor = false;
            SSB3.MouseClick += SSB3_click;
            // 
            // DSPSPAN_box
            // 
            DSPSPAN_box.BackColor = Color.Black;
            DSPSPAN_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DSPSPAN_box.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DSPSPAN_box.ForeColor = Color.Cyan;
            DSPSPAN_box.Location = new Point(588, 103);
            DSPSPAN_box.Margin = new System.Windows.Forms.Padding(0);
            DSPSPAN_box.Name = "DSPSPAN_box";
            DSPSPAN_box.Size = new Size(84, 18);
            DSPSPAN_box.TabIndex = 40;
            DSPSPAN_box.TabStop = false;
            DSPSPAN_box.Text = "<SPAN>";
            DSPSPAN_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            DSPSPAN_box.TextChanged += textBox1_TextChanged_1;
            // 
            // FixB
            // 
            FixB.BackColor = Color.DarkGreen;
            FixB.FlatAppearance.BorderColor = Color.White;
            FixB.FlatAppearance.MouseDownBackColor = Color.Red;
            FixB.FlatAppearance.MouseOverBackColor = Color.Blue;
            FixB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FixB.ForeColor = Color.Yellow;
            FixB.Location = new Point(506, 68);
            FixB.Name = "FixB";
            FixB.Size = new Size(85, 35);
            FixB.TabIndex = 41;
            FixB.Text = "FIX";
            FixB.UseVisualStyleBackColor = false;
            FixB.Click += FixB_Click;
            FixB.MouseClick += Fix_Click;
            // 
            // rfGainTrackBar
            // 
            rfGainTrackBar.BackColor = Color.DarkGreen;
            rfGainTrackBar.Location = new Point(678, 1);
            rfGainTrackBar.Maximum = 255;
            rfGainTrackBar.Name = "rfGainTrackBar";
            rfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            rfGainTrackBar.Size = new Size(45, 102);
            rfGainTrackBar.TabIndex = 42;
            rfGainTrackBar.TickFrequency = 16;
            rfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            rfGainTrackBar.Value = 255;
            rfGainTrackBar.ValueChanged += RfGainTrackBar_ValueChanged;
            // 
            // volumeGainTrackBar
            // 
            volumeGainTrackBar.BackColor = Color.DarkGreen;
            volumeGainTrackBar.Location = new Point(727, 1);
            volumeGainTrackBar.Maximum = 255;
            volumeGainTrackBar.Name = "volumeGainTrackBar";
            volumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            volumeGainTrackBar.Size = new Size(45, 102);
            volumeGainTrackBar.TabIndex = 43;
            volumeGainTrackBar.TickFrequency = 16;
            volumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            volumeGainTrackBar.Value = 60;
            // 
            // FreqM_box
            // 
            FreqM_box.BackColor = Color.DarkGreen;
            FreqM_box.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FreqM_box.ForeColor = Color.Yellow;
            FreqM_box.Location = new Point(2, 1);
            FreqM_box.Multiline = true;
            FreqM_box.Name = "FreqM_box";
            FreqM_box.Size = new Size(166, 33);
            FreqM_box.TabIndex = 44;
            FreqM_box.TabStop = false;
            FreqM_box.Text = "MAIN";
            FreqM_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            FreqM_box.WordWrap = false;
            // 
            // FreqS_box
            // 
            FreqS_box.BackColor = Color.DarkBlue;
            FreqS_box.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FreqS_box.ForeColor = Color.Yellow;
            FreqS_box.Location = new Point(2, 36);
            FreqS_box.Multiline = true;
            FreqS_box.Name = "FreqS_box";
            FreqS_box.Size = new Size(166, 33);
            FreqS_box.TabIndex = 45;
            FreqS_box.TabStop = false;
            FreqS_box.Text = "SUB";
            FreqS_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            FreqS_box.WordWrap = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox1.ForeColor = Color.Cyan;
            textBox1.Location = new Point(679, 106);
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
            textBox2.Location = new Point(728, 106);
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
            BUSY_box.Location = new Point(80, 105);
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
            pwrControlTrackBar.Location = new Point(776, 1);
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
            textBox3.Location = new Point(777, 106);
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
            AMB.Location = new Point(421, 34);
            AMB.Name = "AMB";
            AMB.Size = new Size(44, 35);
            AMB.TabIndex = 49;
            AMB.Text = "AM";
            AMB.UseVisualStyleBackColor = false;
            AMB.MouseClick += AM_click;
            // 
            // FMB
            // 
            FMB.BackColor = Color.DarkGreen;
            FMB.FlatAppearance.BorderColor = Color.White;
            FMB.FlatAppearance.MouseDownBackColor = Color.Red;
            FMB.FlatAppearance.MouseOverBackColor = Color.Blue;
            FMB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FMB.ForeColor = Color.Yellow;
            FMB.Location = new Point(464, 34);
            FMB.Name = "FMB";
            FMB.Size = new Size(44, 35);
            FMB.TabIndex = 50;
            FMB.Text = "FM";
            FMB.UseVisualStyleBackColor = false;
            FMB.MouseClick += FM_click;
            // 
            // DIGB
            // 
            DIGB.BackColor = Color.DarkGreen;
            DIGB.FlatAppearance.BorderColor = Color.White;
            DIGB.FlatAppearance.MouseDownBackColor = Color.Red;
            DIGB.FlatAppearance.MouseOverBackColor = Color.Blue;
            DIGB.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DIGB.ForeColor = Color.Yellow;
            DIGB.Location = new Point(464, 68);
            DIGB.Name = "DIGB";
            DIGB.Size = new Size(44, 35);
            DIGB.TabIndex = 51;
            DIGB.Text = "DIG";
            DIGB.UseVisualStyleBackColor = false;
            DIGB.MouseClick += DIG_click;
            // 
            // SSB4
            // 
            SSB4.BackColor = Color.DarkGreen;
            SSB4.FlatAppearance.BorderColor = Color.White;
            SSB4.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB4.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB4.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB4.ForeColor = Color.Yellow;
            SSB4.Location = new Point(631, 68);
            SSB4.Name = "SSB4";
            SSB4.Size = new Size(44, 35);
            SSB4.TabIndex = 52;
            SSB4.Text = "1 M";
            SSB4.UseVisualStyleBackColor = false;
            SSB4.MouseClick += SSB4_click;
            // 
            // SSB5
            // 
            SSB5.BackColor = Color.DarkGreen;
            SSB5.FlatAppearance.BorderColor = Color.White;
            SSB5.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB5.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB5.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB5.ForeColor = Color.Yellow;
            SSB5.Location = new Point(589, 0);
            SSB5.Name = "SSB5";
            SSB5.Size = new Size(44, 35);
            SSB5.TabIndex = 53;
            SSB5.Text = "20 k";
            SSB5.UseVisualStyleBackColor = false;
            SSB5.MouseClick += SSB5_click;
            // 
            // SSB6
            // 
            SSB6.BackColor = Color.DarkGreen;
            SSB6.FlatAppearance.BorderColor = Color.White;
            SSB6.FlatAppearance.MouseDownBackColor = Color.Red;
            SSB6.FlatAppearance.MouseOverBackColor = Color.Blue;
            SSB6.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SSB6.ForeColor = Color.Yellow;
            SSB6.Location = new Point(631, 0);
            SSB6.Name = "SSB6";
            SSB6.Size = new Size(44, 35);
            SSB6.TabIndex = 54;
            SSB6.Text = "50 k";
            SSB6.UseVisualStyleBackColor = false;
            SSB6.MouseDown += SSB6_click;
            // 
            // IntTune
            // 
            IntTune.BackColor = Color.DarkGreen;
            IntTune.FlatAppearance.BorderColor = Color.White;
            IntTune.FlatAppearance.MouseDownBackColor = Color.Red;
            IntTune.FlatAppearance.MouseOverBackColor = Color.Blue;
            IntTune.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IntTune.ForeColor = Color.Yellow;
            IntTune.Location = new Point(824, 1);
            IntTune.Name = "IntTune";
            IntTune.Size = new Size(86, 35);
            IntTune.TabIndex = 55;
            IntTune.Text = "Int Tuner";
            IntTune.UseVisualStyleBackColor = false;
            IntTune.Click += IntTune_Click;
            // 
            // ItuneOn
            // 
            ItuneOn.BackColor = Color.DarkGreen;
            ItuneOn.FlatAppearance.BorderColor = Color.White;
            ItuneOn.FlatAppearance.MouseDownBackColor = Color.Red;
            ItuneOn.FlatAppearance.MouseOverBackColor = Color.Blue;
            ItuneOn.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItuneOn.ForeColor = Color.Yellow;
            ItuneOn.Location = new Point(824, 36);
            ItuneOn.Name = "ItuneOn";
            ItuneOn.Size = new Size(44, 35);
            ItuneOn.TabIndex = 56;
            ItuneOn.Text = "On";
            ItuneOn.UseVisualStyleBackColor = false;
            ItuneOn.Click += ItuneOn_Click;
            // 
            // ItuneOff
            // 
            ItuneOff.BackColor = Color.DarkGreen;
            ItuneOff.FlatAppearance.BorderColor = Color.White;
            ItuneOff.FlatAppearance.MouseDownBackColor = Color.Red;
            ItuneOff.FlatAppearance.MouseOverBackColor = Color.Blue;
            ItuneOff.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ItuneOff.ForeColor = Color.Yellow;
            ItuneOff.Location = new Point(866, 36);
            ItuneOff.Name = "ItuneOff";
            ItuneOff.Size = new Size(44, 35);
            ItuneOff.TabIndex = 57;
            ItuneOff.Text = "Off";
            ItuneOff.UseVisualStyleBackColor = false;
            ItuneOff.Click += ItuneOff_Click;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.Black;
            textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.ForeColor = Color.Cyan;
            textBox4.Location = new Point(827, 103);
            textBox4.Margin = new System.Windows.Forms.Padding(0);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(84, 18);
            textBox4.TabIndex = 58;
            textBox4.TabStop = false;
            textBox4.Text = "<INT TUN>";
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SubrfGainTrackBar
            // 
            SubrfGainTrackBar.BackColor = Color.DarkBlue;
            SubrfGainTrackBar.Location = new Point(915, 1);
            SubrfGainTrackBar.Maximum = 255;
            SubrfGainTrackBar.Name = "SubrfGainTrackBar";
            SubrfGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SubrfGainTrackBar.Size = new Size(45, 102);
            SubrfGainTrackBar.TabIndex = 59;
            SubrfGainTrackBar.TickFrequency = 16;
            SubrfGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            SubrfGainTrackBar.Value = 255;
            SubrfGainTrackBar.ValueChanged += SubrfGainTrackBar_ValueChanged;
            // 
            // SubvolumeGainTrackBar
            // 
            SubvolumeGainTrackBar.BackColor = Color.DarkBlue;
            SubvolumeGainTrackBar.Location = new Point(964, 1);
            SubvolumeGainTrackBar.Maximum = 255;
            SubvolumeGainTrackBar.Name = "SubvolumeGainTrackBar";
            SubvolumeGainTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SubvolumeGainTrackBar.Size = new Size(45, 102);
            SubvolumeGainTrackBar.TabIndex = 60;
            SubvolumeGainTrackBar.TickFrequency = 16;
            SubvolumeGainTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            SubvolumeGainTrackBar.ValueChanged += SubvolumeGainTrackBar_ValueChanged;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.Black;
            textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox5.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox5.ForeColor = Color.Cyan;
            textBox5.Location = new Point(916, 106);
            textBox5.Margin = new System.Windows.Forms.Padding(0);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(40, 15);
            textBox5.TabIndex = 61;
            textBox5.TabStop = false;
            textBox5.Text = "00";
            textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox5.WordWrap = false;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.Black;
            textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox6.Font = new Font("Verdana", 8F, FontStyle.Bold);
            textBox6.ForeColor = Color.Cyan;
            textBox6.Location = new Point(965, 106);
            textBox6.Margin = new System.Windows.Forms.Padding(0);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(40, 15);
            textBox6.TabIndex = 62;
            textBox6.TabStop = false;
            textBox6.Text = "00";
            textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox6.WordWrap = false;
            // 
            // SWAP
            // 
            SWAP.BackColor = Color.DarkGreen;
            SWAP.FlatAppearance.BorderColor = Color.White;
            SWAP.FlatAppearance.BorderSize = 3;
            SWAP.FlatAppearance.MouseDownBackColor = Color.Red;
            SWAP.FlatAppearance.MouseOverBackColor = Color.Blue;
            SWAP.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SWAP.ForeColor = Color.Yellow;
            SWAP.Location = new Point(0, 68);
            SWAP.Name = "SWAP";
            SWAP.Size = new Size(86, 35);
            SWAP.TabIndex = 63;
            SWAP.Text = "< === >";
            SWAP.UseVisualStyleBackColor = false;
            SWAP.Click += SWAP_Click;
            // 
            // rfGainLabel
            // 
            rfGainLabel.AutoSize = true;
            rfGainLabel.BackColor = Color.DarkGreen;
            rfGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rfGainLabel.ForeColor = Color.Yellow;
            rfGainLabel.Location = new Point(681, 1);
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
            volumeGainLabel.Location = new Point(727, 1);
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
            pwrControlLabel.Location = new Point(778, 1);
            pwrControlLabel.Name = "pwrControlLabel";
            pwrControlLabel.Size = new Size(38, 10);
            pwrControlLabel.TabIndex = 0;
            pwrControlLabel.Text = "POWER";
            // 
            // SubrfGainLabel
            // 
            SubrfGainLabel.AutoSize = true;
            SubrfGainLabel.BackColor = Color.DarkGreen;
            SubrfGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubrfGainLabel.ForeColor = Color.Yellow;
            SubrfGainLabel.Location = new Point(920, 0);
            SubrfGainLabel.Name = "SubrfGainLabel";
            SubrfGainLabel.Size = new Size(38, 10);
            SubrfGainLabel.TabIndex = 0;
            SubrfGainLabel.Text = "SUB RF";
            // 
            // SubvolumeGainLabel
            // 
            SubvolumeGainLabel.AutoSize = true;
            SubvolumeGainLabel.BackColor = Color.DarkGreen;
            SubvolumeGainLabel.Font = new Font("Verdana", 6F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SubvolumeGainLabel.ForeColor = Color.Yellow;
            SubvolumeGainLabel.Location = new Point(966, 0);
            SubvolumeGainLabel.Name = "SubvolumeGainLabel";
            SubvolumeGainLabel.Size = new Size(45, 10);
            SubvolumeGainLabel.TabIndex = 0;
            SubvolumeGainLabel.Text = "SUB VOL";
            // 
            // RX12off
            // 
            RX12off.BackColor = Color.DarkGreen;
            RX12off.FlatAppearance.BorderColor = Color.White;
            RX12off.FlatAppearance.MouseDownBackColor = Color.Red;
            RX12off.FlatAppearance.MouseOverBackColor = Color.Blue;
            RX12off.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RX12off.ForeColor = Color.Yellow;
            RX12off.Location = new Point(168, 68);
            RX12off.Name = "RX12off";
            RX12off.Size = new Size(86, 35);
            RX12off.TabIndex = 64;
            RX12off.Text = "RXs Off";
            RX12off.UseVisualStyleBackColor = false;
            RX12off.MouseClick += RX12off_click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1013, 125);
            Controls.Add(RX12off);
            Controls.Add(rfGainLabel);
            Controls.Add(volumeGainLabel);
            Controls.Add(pwrControlLabel);
            Controls.Add(SubrfGainLabel);
            Controls.Add(SubvolumeGainLabel);
            Controls.Add(SWAP);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(SubvolumeGainTrackBar);
            Controls.Add(SubrfGainTrackBar);
            Controls.Add(textBox4);
            Controls.Add(ItuneOff);
            Controls.Add(ItuneOn);
            Controls.Add(IntTune);
            Controls.Add(SSB6);
            Controls.Add(SSB5);
            Controls.Add(SSB4);
            Controls.Add(DIGB);
            Controls.Add(FMB);
            Controls.Add(AMB);
            Controls.Add(BUSY_box);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(FreqS_box);
            Controls.Add(FreqM_box);
            Controls.Add(volumeGainTrackBar);
            Controls.Add(rfGainTrackBar);
            Controls.Add(FixB);
            Controls.Add(DSPSPAN_box);
            Controls.Add(SSB3);
            Controls.Add(SSB2);
            Controls.Add(SSB1);
            Controls.Add(RX_box);
            Controls.Add(RX12B);
            Controls.Add(RX2);
            Controls.Add(RX1B);
            Controls.Add(IPO_box);
            Controls.Add(ANT_box);
            Controls.Add(AMP2B);
            Controls.Add(AMP1B);
            Controls.Add(IPOB);
            Controls.Add(ANT3RXB);
            Controls.Add(ANT2B);
            Controls.Add(ANT1B);
            Controls.Add(MODE_box);
            Controls.Add(DSPMOD_box);
            Controls.Add(RFTOGGLE);
            Controls.Add(CWB);
            Controls.Add(LSBB);
            Controls.Add(USBB);
            Controls.Add(CenterB);
            Controls.Add(CursorB);
            Controls.Add(ExtTuneButton);
            Controls.Add(TEMP_box);
            Controls.Add(RFSQL_box);
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
            Text = "The590Box v 1 - by Kees, ON9KVE -";
            TransparencyKey = Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)rfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pwrControlTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubrfGainTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SubvolumeGainTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox RFSQL_box;
        private System.Windows.Forms.TextBox TEMP_box;
        private System.Windows.Forms.Button ExtTuneButton;
        private System.Windows.Forms.Button CursorB;
        private System.Windows.Forms.Button CenterB;
        private System.Windows.Forms.Button USBB;
        private System.Windows.Forms.Button LSBB;
        private System.Windows.Forms.Button CWB;
        private System.Windows.Forms.Button RFTOGGLE;
        private System.Windows.Forms.TextBox DSPMOD_box;
        private System.Windows.Forms.TextBox MODE_box;
        private System.Windows.Forms.Button ANT1B;
        private System.Windows.Forms.Button ANT2B;
        private System.Windows.Forms.Button ANT3RXB;
        private System.Windows.Forms.Button IPOB;
        private System.Windows.Forms.Button AMP1B;
        private System.Windows.Forms.Button AMP2B;
        private System.Windows.Forms.TextBox ANT_box;
        private System.Windows.Forms.TextBox IPO_box;
        private System.Windows.Forms.Button RX1B;
        private System.Windows.Forms.Button RX2;
        private System.Windows.Forms.Button RX12B;
        private System.Windows.Forms.TextBox RX_box;
        private System.Windows.Forms.Button SSB1;
        private System.Windows.Forms.Button SSB2;
        private System.Windows.Forms.Button SSB3;
        private System.Windows.Forms.TextBox DSPSPAN_box;
        private System.Windows.Forms.Button FixB;
        private System.Windows.Forms.TrackBar rfGainTrackBar;
        private System.Windows.Forms.TrackBar volumeGainTrackBar;
        private System.Windows.Forms.TrackBar pwrControlTrackBar;
        private System.Windows.Forms.TextBox FreqM_box;
        private System.Windows.Forms.TextBox FreqS_box;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox BUSY_box;
        private System.Windows.Forms.Button AMB;
        private System.Windows.Forms.Button FMB;
        private System.Windows.Forms.Button DIGB;
        private System.Windows.Forms.Button SSB4;
        private System.Windows.Forms.Button SSB5;
        private System.Windows.Forms.Button SSB6;
        private System.Windows.Forms.Button IntTune;
        private System.Windows.Forms.Button ItuneOn;
        private System.Windows.Forms.Button ItuneOff;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TrackBar SubrfGainTrackBar;
        private System.Windows.Forms.TrackBar SubvolumeGainTrackBar;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button SWAP;
        private System.Windows.Forms.Label rfGainLabel;
        private System.Windows.Forms.Label volumeGainLabel;
        private System.Windows.Forms.Label pwrControlLabel;
        private System.Windows.Forms.Label SubrfGainLabel;
        private System.Windows.Forms.Label SubvolumeGainLabel;
        private System.Windows.Forms.Button RX12off;
    }
}

