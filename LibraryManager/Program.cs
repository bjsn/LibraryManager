﻿namespace LibraryManager
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
            //Application.Run(new ProposalContent_Container());
            Application.Run(new Main_Container());
        }
    }
}

