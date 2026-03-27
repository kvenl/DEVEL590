using System;
using System.Threading;
using System.Windows.Forms;

namespace The590Box
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using var mutex = new Mutex(true, "The590Box_SingleInstance", out bool isNewInstance);
            if (!isNewInstance)
            {
                MessageBox.Show("The590Box is already running.", "Already Running",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
