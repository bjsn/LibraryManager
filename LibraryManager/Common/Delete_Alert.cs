namespace LibraryManager.Views
{
    using LibraryManager.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class Delete_Alert : BasePartialView
    {
        private IContainer components;
        private Panel panel2;
        private PictureBox BtnMinimize;
        private PictureBox BtnClose;
        private Label label1;
        private Label label2;
        private Button BtnCancel;
        private Button BtnDelete;
        private PictureBox pictureBox2;
        private Label lblTextDelete;

        public Delete_Alert()
        {
        }

        public Delete_Alert(Panel Panel, BasePartialView Preview = null) : base(Panel, Preview)
        {
            this.InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.ClosePartialView();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            base.PreviewForm.Delete();
            base.ClosePartialView();
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
            this.panel2 = new Panel();
            this.pictureBox2 = new PictureBox();
            this.BtnMinimize = new PictureBox();
            this.BtnClose = new PictureBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.BtnCancel = new Button();
            this.BtnDelete = new Button();
            this.lblTextDelete = new Label();
            this.panel2.SuspendLayout();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.BtnMinimize).BeginInit();
            ((ISupportInitialize) this.BtnClose).BeginInit();
            base.SuspendLayout();
            this.panel2.BackColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.BtnMinimize);
            this.panel2.Controls.Add(this.BtnClose);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x133, 0x1c);
            this.panel2.TabIndex = 0x29;
            this.pictureBox2.Anchor = AnchorStyles.None;
            this.pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox2.Image = Resources.danger;
            this.pictureBox2.Location = new Point(10, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(20, 0x12);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.BtnMinimize.Anchor = AnchorStyles.None;
            this.BtnMinimize.BackgroundImageLayout = ImageLayout.Center;
            this.BtnMinimize.Cursor = Cursors.Hand;
            //this.BtnMinimize.Image = Resources.minimizes2;
            this.BtnMinimize.Location = new Point(0x1a7, 6);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new Size(15, 15);
            this.BtnMinimize.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BtnMinimize.TabIndex = 3;
            this.BtnMinimize.TabStop = false;
            this.BtnClose.Anchor = AnchorStyles.None;
            this.BtnClose.BackgroundImageLayout = ImageLayout.Center;
            this.BtnClose.Cursor = Cursors.Hand;
            //this.BtnClose.Image = Resources.close;
            this.BtnClose.Location = new Point(0x1c1, 6);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new Size(15, 15);
            this.BtnClose.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = FlatStyle.Flat;
            this.label1.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(0x26, 7);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x29, 0x11);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alert!";
            this.label2.AutoSize = true;
            this.label2.FlatStyle = FlatStyle.Flat;
            this.label2.Font = new Font("Segoe UI Semibold", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.FromArgb(40, 40, 40);
            this.label2.Location = new Point(0x34, 0x24);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0xca, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Do you really want to delete";
            this.BtnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnCancel.BackColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.BtnCancel.Cursor = Cursors.Hand;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            this.BtnCancel.FlatStyle = FlatStyle.Flat;
            this.BtnCancel.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnCancel.ForeColor = Color.White;
            this.BtnCancel.Location = new Point(0x44, 0x62);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new Size(0x51, 0x1d);
            this.BtnCancel.TabIndex = 0x2d;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
            this.BtnDelete.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnDelete.BackColor = Color.FromArgb(0xe7, 0x4c, 70);
            this.BtnDelete.Cursor = Cursors.Hand;
            this.BtnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xc0, 0x39, 0x2b);
            this.BtnDelete.FlatStyle = FlatStyle.Flat;
            this.BtnDelete.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnDelete.ForeColor = Color.White;
            this.BtnDelete.Location = new Point(0xa3, 0x62);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new Size(0x52, 0x1d);
            this.BtnDelete.TabIndex = 0x2c;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new EventHandler(this.BtnDelete_Click);
            this.lblTextDelete.AutoSize = true;
            this.lblTextDelete.FlatStyle = FlatStyle.Flat;
            this.lblTextDelete.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTextDelete.ForeColor = Color.FromArgb(0, 0x72, 0xc6);
            this.lblTextDelete.Location = new Point(0x35, 0x38);
            this.lblTextDelete.Name = "lblTextDelete";
            this.lblTextDelete.Size = new Size(0, 0x11);
            this.lblTextDelete.TabIndex = 0x2e;
            base.AutoScaleDimensions = new SizeF(7f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x133, 0x8a);
            base.Controls.Add(this.lblTextDelete);
            base.Controls.Add(this.BtnCancel);
            base.Controls.Add(this.BtnDelete);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.panel2);
            this.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "Delete_Alert";
            this.Text = "Delete_Alert";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.BtnMinimize).EndInit();
            ((ISupportInitialize) this.BtnClose).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void SetText(string text)
        {
            this.lblTextDelete.Text = text;
        }
    }
}

