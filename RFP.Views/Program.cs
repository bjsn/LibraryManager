namespace RFP.Views
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (RFPContent_Container form = new RFPContent_Container())
            {
                form.ShowDialog();
            }

        }
    }
}

