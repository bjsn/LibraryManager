namespace LibraryManager
{
    using LibrMgr.Views.Reindex;
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Reindex());
            Application.Run(new Main_Container());
        }

    }
}

