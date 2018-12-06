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
            this.PnlBorderTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BtnMinimize = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.PnlBorderTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBorderTop
            // 
            this.PnlBorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.PnlBorderTop.Controls.Add(this.label1);
            this.PnlBorderTop.Controls.Add(this.BtnMinimize);
            this.PnlBorderTop.Controls.Add(this.BtnClose);
            this.PnlBorderTop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PnlBorderTop.Location = new System.Drawing.Point(163, 0);
            this.PnlBorderTop.Name = "PnlBorderTop";
            this.PnlBorderTop.Size = new System.Drawing.Size(730, 22);
            this.PnlBorderTop.TabIndex = 5;
            this.PnlBorderTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.PnlBorderTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.PnlBorderTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(256, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add / Edit Proposal Content for Products";
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainPanel.Location = new System.Drawing.Point(163, 22);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(730, 580);
            this.MainPanel.TabIndex = 5;
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinimize.Image = global::LibraryManager.Properties.Resources.icon;
            this.BtnMinimize.Location = new System.Drawing.Point(681, 3);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(15, 15);
            this.BtnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnMinimize.TabIndex = 3;
            this.BtnMinimize.TabStop = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Image = global::LibraryManager.Properties.Resources.cancel;
            this.BtnClose.Location = new System.Drawing.Point(707, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(15, 15);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // Main_Container
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(895, 600);
            this.Controls.Add(this.PnlBorderTop);
            this.Controls.Add(this.MainPanel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Container";
            this.Load += new System.EventHandler(this.Main_Container_Load);
            this.PnlBorderTop.ResumeLayout(false);
            this.PnlBorderTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.ResumeLayout(false);

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

