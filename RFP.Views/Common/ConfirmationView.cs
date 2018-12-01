using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RFP.Views
{
    public class ConfirmationView : BasePartialView
    {
        private IContainer components;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label1;

        public ConfirmationView()
        {
            this.InitializeComponent();
        }

        public void Close()
        {
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
            this.label4 = new Label();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.White;
            this.label4.FlatStyle = FlatStyle.Flat;
            this.label4.Font = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.FromArgb(0, 0x72, 0xc6);
            this.label4.Location = new Point(100, 9);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x3e, 0x15);
            this.label4.TabIndex = 0x20;
            this.label4.Text = "Saving";
            this.label1.AutoSize = true;
            this.label1.FlatStyle = FlatStyle.Flat;
            this.label1.Font = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label1.Location = new Point(70, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x8e, 0x11);
            this.label1.TabIndex = 0x21;
            this.label1.Text = "Please wait a moment";
            //this.pictureBox1.Image = Resources.loading_puntos;
            this.pictureBox1.Location = new Point(50, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0xa2, 0x6a);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0x1f;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(0x119, 0x67);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "ConfirmationView";
            this.Text = "ConfirmationView";
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

