namespace LibraryManager
{
    using LibrMgr.Properties;
    using LibraryManager.Views;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ProposalContent_Container : Main_Container_Base
    {
        private bool moving;
        private Point offset;
        private Point original;
        private IContainer components;
        private Panel PnlBorderTop;
        private PictureBox BtnMinimize;
        private PictureBox BtnClose;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel MainPanel;

        public ProposalContent_Container()
        {
            this.InitializeComponent();
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
            this.BtnMinimize = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.PnlBorderTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlBorderTop
            // 
            this.PnlBorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.PnlBorderTop.Controls.Add(this.BtnMinimize);
            this.PnlBorderTop.Controls.Add(this.BtnClose);
            this.PnlBorderTop.Controls.Add(this.label1);
            this.PnlBorderTop.Location = new System.Drawing.Point(0, 0);
            this.PnlBorderTop.Name = "PnlBorderTop";
            this.PnlBorderTop.Size = new System.Drawing.Size(730, 22);
            this.PnlBorderTop.TabIndex = 6;
            this.PnlBorderTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlBorderTop_MouseDown);
            this.PnlBorderTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PnlBorderTop_MouseMove);
            this.PnlBorderTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PnlBorderTop_MouseUp);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinimize.Image = global::LibrMgr.Properties.Resources.icon;
            this.BtnMinimize.Location = new System.Drawing.Point(691, 4);
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
            this.BtnClose.Image = global::LibrMgr.Properties.Resources.cancel;
            this.BtnClose.Location = new System.Drawing.Point(712, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(15, 15);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(232, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add / Edit Proposal Content for Products";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrMgr.Properties.Resources.Logo_transparent;
            this.pictureBox1.Location = new System.Drawing.Point(297, 613);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainPanel.Location = new System.Drawing.Point(0, 22);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(730, 580);
            this.MainPanel.TabIndex = 8;
            // 
            // ProposalContent_Container
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(730, 661);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PnlBorderTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProposalContent_Container";
            this.Text = "ProposalContent_Container";
            this.Load += new System.EventHandler(this.ProposalContent_Container_Load);
            this.PnlBorderTop.ResumeLayout(false);
            this.PnlBorderTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void PnlBorderTop_MouseDown(object sender, MouseEventArgs e)
        {
            this.moving = true;
            this.PnlBorderTop.Capture = true;
            this.offset = Control.MousePosition;
            this.original = base.Location;
        }

        private void PnlBorderTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.moving)
            {
                int x = (this.original.X + Control.MousePosition.X) - this.offset.X;
                base.Location = new Point(x, (this.original.Y + Control.MousePosition.Y) - this.offset.Y);
            }
        }

        private void PnlBorderTop_MouseUp(object sender, MouseEventArgs e)
        {
            this.moving = false;
            this.PnlBorderTop.Capture = false;
        }

        private void ProposalContent_Container_Load(object sender, EventArgs e)
        {
            BasePartialView view = new ProposalContent(this.MainPanel, false) {
                TopLevel = false,
                AutoScroll = false,
                Location = new Point(0, 0)
            };
            this.MainPanel.Controls.Add(view);
            view.Show();
        }
    }
}

