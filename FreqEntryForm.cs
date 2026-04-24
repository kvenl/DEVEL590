using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace The590Box
{
    internal class FreqEntryForm : Form
    {
        public double EnteredKhz { get; private set; }

        private readonly TextBox _inputBox;

        public FreqEntryForm(double currentKhz, Point screenLocation)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition   = FormStartPosition.Manual;
            Location        = screenLocation;
            Size            = new Size(250, 100);
            Text            = "Enter Frequency";
            BackColor       = Color.Black;
            ForeColor       = Color.Gold;
            MaximizeBox     = false;
            MinimizeBox     = false;
            ShowInTaskbar   = false;
            KeyPreview      = true;

            var lbl = new Label
            {
                Text      = "Frequency (kHz):",
                AutoSize  = true,
                Location  = new Point(8, 10),
                ForeColor = Color.Gold,
                BackColor = Color.Black
            };

            _inputBox = new TextBox
            {
                Location    = new Point(8, 30),
                Size        = new Size(222, 24),
                BackColor   = Color.FromArgb(30, 30, 30),
                ForeColor   = Color.Gold,
                Font        = new Font("Courier New", 12F, FontStyle.Bold),
                Text        = currentKhz.ToString("0.##", CultureInfo.InvariantCulture),
                BorderStyle = BorderStyle.FixedSingle
            };
            _inputBox.SelectAll();
            _inputBox.KeyDown += InputBox_KeyDown;

            Controls.Add(lbl);
            Controls.Add(_inputBox);
            ActiveControl = _inputBox;
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TryAccept();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void TryAccept()
        {
            // Accept both '.' and ',' as decimal separator
            string text = _inputBox.Text.Trim().Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double khz) && khz > 0)
            {
                EnteredKhz   = khz;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                _inputBox.BackColor = Color.DarkRed;
                _inputBox.SelectAll();
            }
        }
    }
}
