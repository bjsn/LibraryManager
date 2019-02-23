namespace LibraryManager
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    internal class SeeThroughPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30, 50)), base.ClientRectangle);
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x20;
                return createParams;
            }
        }
    }
}

