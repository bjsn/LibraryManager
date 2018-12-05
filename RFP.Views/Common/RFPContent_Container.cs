using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RFP.Views
{
    public class RFPContent_Container : Main_Container_Base
    {
        private bool moving;
        private Point offset;
        private Point original;
        private IContainer components;
        private PictureBox BtnClose;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel MainPanel;

        public RFPContent_Container()
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
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Image = global::RFPView.Properties.Resources.cancel;
            this.BtnClose.Location = new System.Drawing.Point(705, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(16, 16);
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
            this.label1.Location = new System.Drawing.Point(279, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert RFP response content";
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MainPanel.Location = new System.Drawing.Point(0, 22);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(730, 580);
            this.MainPanel.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RFPView.Properties.Resources.Logo_transparent;
            this.pictureBox1.Location = new System.Drawing.Point(297, 613);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // RFPContent_Container
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(730, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RFPContent_Container";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProposalContent_Container";
            this.Load += new System.EventHandler(this.RFPContent_Container_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PnlBorderTop_MouseDown(object sender, MouseEventArgs e)
        {
            this.moving = true;
            //this.PnlBorderTop.Capture = true;
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
            //this.PnlBorderTop.Capture = false;
        }

        private void RFPContent_Container_Load(object sender, EventArgs e)
        {
            BasePartialView view = new RFPContent(this.MainPanel)
            {
                TopLevel = false,
                AutoScroll = false,
                Location = new Point(0, 0)
            };
            this.MainPanel.Controls.Add(view);
            view.Show();
        }

    }
}

