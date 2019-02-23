namespace LibraryManager
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class Main_Container_Base : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;
        private const int CS_DROPSHADOW = 0x20000;
        private const int WM_NCPAINT = 0x85;
        private const int WM_ACTIVATEAPP = 0x1c;
        private bool Drag;
        private int MouseX;
        private int MouseY;
        private bool m_aeroEnabled;

        public Main_Container_Base()
        {
        }

        public Main_Container_Base(Panel panel)
        {
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                return false;
            }
            int pfEnabled = 0;
            DwmIsCompositionEnabled(ref pfEnabled);
            return (pfEnabled == 1);
        }

        [DllImport("Gdi32.dll")]
        protected static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Main_Container_Base
            // 
            this.ClientSize = new System.Drawing.Size(148, 0);
            this.Name = "Main_Container_Base";
            this.ResumeLayout(false);

        }

        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            this.Drag = true;
            this.MouseX = Cursor.Position.X - base.Left;
            this.MouseY = Cursor.Position.Y - base.Top;
        }

        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Drag)
            {
                base.Top = Cursor.Position.Y - this.MouseY;
                base.Left = Cursor.Position.X - this.MouseX;
            }
        }

        private void PanelMove_MouseUp(object sender, MouseEventArgs e)
        {
            this.Drag = false;
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x85) && this.m_aeroEnabled)
            {
                int attrValue = 2;
                DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 4);
                MARGINS pMarInset = new MARGINS {
                    bottomHeight = 1,
                    leftWidth = 0,
                    rightWidth = 0,
                    topHeight = 0
                };
                DwmExtendFrameIntoClientArea(base.Handle, ref pMarInset);
            }
            base.WndProc(ref m);
            if ((m.Msg == 0x84) && (((int) m.Result) == 1))
            {
                m.Result = (IntPtr) 2;
            }
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                this.m_aeroEnabled = this.CheckAeroEnabled();
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                if (!this.m_aeroEnabled)
                {
                    createParams.ClassStyle |= 0x20000;
                }
                return createParams;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
    }
}

