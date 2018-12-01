namespace LibraryManager
{
    using LibraryManager.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Main_Container : Main_Container_Base
    {
        private bool moving;
        private Point offset;
        private Point original;
        private IContainer components;
        private Panel MainPanel;
        private Label label1;
        private Panel PnlBorderTop;
        private PictureBox BtnClose;
        private PictureBox BtnMinimize;

        public Main_Container()
        {
            this.InitializeComponent();
            base.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, base.Width - 1, base.Height - 1, 1, 1));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Main_Container));
            this.PnlBorderTop = new Panel();
            this.label1 = new Label();
            this.BtnMinimize = new PictureBox();
            this.BtnClose = new PictureBox();
            this.MainPanel = new Panel();
            this.PnlBorderTop.SuspendLayout();
            ((ISupportInitialize) this.BtnMinimize).BeginInit();
            ((ISupportInitialize) this.BtnClose).BeginInit();
            base.SuspendLayout();
            this.PnlBorderTop.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.PnlBorderTop.Controls.Add(this.label1);
            this.PnlBorderTop.Controls.Add(this.BtnMinimize);
            this.PnlBorderTop.Controls.Add(this.BtnClose);
            this.PnlBorderTop.Cursor = Cursors.Arrow;
            this.PnlBorderTop.Location = new Point(0xa3, 0);
            this.PnlBorderTop.Name = "PnlBorderTop";
            this.PnlBorderTop.Size = new Size(730, 0x16);
            this.PnlBorderTop.TabIndex = 5;
            this.PnlBorderTop.MouseDown += new MouseEventHandler(this.panel2_MouseDown);
            this.PnlBorderTop.MouseMove += new MouseEventHandler(this.panel2_MouseMove);
            this.PnlBorderTop.MouseUp += new MouseEventHandler(this.panel2_MouseUp);
            this.label1.AutoSize = true;
            this.label1.FlatStyle = FlatStyle.Flat;
            this.label1.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(0x100, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xd7, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add / Edit Proposal Content for Products";
            this.BtnMinimize.Anchor = AnchorStyles.None;
            this.BtnMinimize.BackgroundImageLayout = ImageLayout.Center;
            this.BtnMinimize.Cursor = Cursors.Hand;
            //this.BtnMinimize.Image = Resources.minimizes2;
            this.BtnMinimize.Location = new Point(0x2a9, 3);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new Size(15, 15);
            this.BtnMinimize.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BtnMinimize.TabIndex = 3;
            this.BtnMinimize.TabStop = false;
            this.BtnMinimize.Click += new EventHandler(this.BtnMinimize_Click);
            this.BtnClose.Anchor = AnchorStyles.None;
            this.BtnClose.BackgroundImageLayout = ImageLayout.Center;
            this.BtnClose.Cursor = Cursors.Hand;
            //this.BtnClose.Image = Resources.close;
            this.BtnClose.Location = new Point(0x2c3, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new Size(15, 15);
            this.BtnClose.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new EventHandler(this.BtnClose_Click);
            this.MainPanel.BackColor = Color.WhiteSmoke;
            this.MainPanel.Location = new Point(0xa3, 0x16);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new Size(730, 580);
            this.MainPanel.TabIndex = 5;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0x26, 0x26, 0x26);
            base.ClientSize = new Size(0x37f, 600);
            base.Controls.Add(this.PnlBorderTop);
            base.Controls.Add(this.MainPanel);
            this.Cursor = Cursors.Arrow;
            base.FormBorderStyle = FormBorderStyle.None;
            //base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "Main_Container";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Main_Container";
            base.Load += new EventHandler(this.Main_Container_Load);
            this.PnlBorderTop.ResumeLayout(false);
            this.PnlBorderTop.PerformLayout();
            ((ISupportInitialize) this.BtnMinimize).EndInit();
            ((ISupportInitialize) this.BtnClose).EndInit();
            base.ResumeLayout(false);
        }

        private void Main_Container_Load(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar(this.MainPanel) {
                TopLevel = false,
                AutoScroll = false,
                Location = new Point(0, 0)
            };
            base.Controls.Add(navbar);
            navbar.Show();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            this.moving = true;
            this.PnlBorderTop.Capture = true;
            this.offset = Control.MousePosition;
            this.original = base.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.moving)
            {
                int x = (this.original.X + Control.MousePosition.X) - this.offset.X;
                base.Location = new Point(x, (this.original.Y + Control.MousePosition.Y) - this.offset.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            this.moving = false;
            this.PnlBorderTop.Capture = false;
        }
    }
}

