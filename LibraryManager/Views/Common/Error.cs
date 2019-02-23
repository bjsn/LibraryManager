namespace LibraryManager.Common
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class Error : Form
    {
        private IContainer components;

        public Error()
        {
            this.InitializeComponent();
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
            this.components = new Container();
            //base.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "Error";
        }
    }
}

