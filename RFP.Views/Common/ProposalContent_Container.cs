using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RFP.Views
{
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ProposalContent_Container));
            this.PnlBorderTop = new Panel();
            this.BtnMinimize = new PictureBox();
            this.BtnClose = new PictureBox();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            this.MainPanel = new Panel();
            this.PnlBorderTop.SuspendLayout();
            ((ISupportInitialize) this.BtnMinimize).BeginInit();
            ((ISupportInitialize) this.BtnClose).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.PnlBorderTop.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.PnlBorderTop.Controls.Add(this.BtnMinimize);
            this.PnlBorderTop.Controls.Add(this.BtnClose);
            this.PnlBorderTop.Controls.Add(this.label1);
            this.PnlBorderTop.Location = new Point(0, 0);
            this.PnlBorderTop.Name = "PnlBorderTop";
            this.PnlBorderTop.Size = new Size(730, 0x16);
            this.PnlBorderTop.TabIndex = 6;
            this.PnlBorderTop.MouseDown += new MouseEventHandler(this.PnlBorderTop_MouseDown);
            this.PnlBorderTop.MouseMove += new MouseEventHandler(this.PnlBorderTop_MouseMove);
            this.PnlBorderTop.MouseUp += new MouseEventHandler(this.PnlBorderTop_MouseUp);
            this.BtnMinimize.Anchor = AnchorStyles.None;
            this.BtnMinimize.BackgroundImageLayout = ImageLayout.Center;
            this.BtnMinimize.Cursor = Cursors.Hand;
            //this.BtnMinimize.Image = Resources.minimizes2;
            this.BtnMinimize.Location = new Point(0x2b3, 4);
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
            this.BtnClose.Location = new Point(0x2c8, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new Size(15, 15);
            this.BtnClose.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new EventHandler(this.BtnClose_Click);
            this.label1.AutoSize = true;
            this.label1.FlatStyle = FlatStyle.Flat;
            this.label1.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(0xe8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xd7, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add / Edit Proposal Content for Products";
            //this.pictureBox1.Image = Resources.Logo_Transparent__white_;
            this.pictureBox1.Location = new Point(0x129, 0x265);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x85, 0x24);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.MainPanel.BackColor = Color.WhiteSmoke;
            this.MainPanel.Location = new Point(0, 0x16);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new Size(730, 580);
            this.MainPanel.TabIndex = 8;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0x26, 0x26, 0x26);
            base.ClientSize = new Size(730, 0x295);
            base.Controls.Add(this.MainPanel);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.PnlBorderTop);
            base.FormBorderStyle = FormBorderStyle.None;
            //base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "ProposalContent_Container";
            this.Text = "ProposalContent_Container";
            base.Load += new EventHandler(this.ProposalContent_Container_Load);
            this.PnlBorderTop.ResumeLayout(false);
            this.PnlBorderTop.PerformLayout();
            ((ISupportInitialize) this.BtnMinimize).EndInit();
            ((ISupportInitialize) this.BtnClose).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
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
            //BasePartialView view = new ProposalContent(this.MainPanel) {
            //    TopLevel = false,
            //    AutoScroll = false,
            //    Location = new Point(0, 0)
            //};
            //this.MainPanel.Controls.Add(view);
            //view.Show();
        }
    }
}

