namespace LibraryManager.Views
{
    using LibraryManager;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class BasePartialView : Form
    {
        protected Panel MainPanel;
        protected BasePartialView PreviewForm;
        private Panel SeeThroughPanel;
        private IContainer components;

        public BasePartialView()
        {
        }

        public BasePartialView(Panel Panel)
        {
            this.MainPanel = Panel;
        }

        public BasePartialView(Panel Panel, BasePartialView Preview = null)
        {
            this.MainPanel = Panel;
            this.PreviewForm = Preview;
        }

        private void AddThroughPanel()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(AddThroughPanel));
            }
            else 
            {
                this.SeeThroughPanel = new LibraryManager.SeeThroughPanel();
                base.Controls.Add(this.SeeThroughPanel);
                this.SeeThroughPanel.Width = this.MainPanel.Width;
                this.SeeThroughPanel.Height = this.MainPanel.Height;
                this.SeeThroughPanel.Location = new Point(0, 0);
                this.SeeThroughPanel.BringToFront();
                this.SeeThroughPanel.Show();
            }
        }

        protected void CloseCurrentView()
        {
            base.Close();
            if (this.PreviewForm != null)
            {
                this.PreviewForm.Show();
                this.PreviewForm.Reload();
            }
        }

        protected void ClosePartialView()
        {
            base.Close();
            if (this.PreviewForm == null)
            {
                this.DeleteThroughPanel();
            }
            else
            {
                this.PreviewForm.Reload();
                this.PreviewForm.Show();
                this.PreviewForm.DeleteThroughPanel();
            }
        }

        public virtual void Delete()
        {
        }

        private void DeleteThroughPanel()
        {
            if (this.SeeThroughPanel != null)
            {
                base.Controls.Remove(this.SeeThroughPanel);
            }
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.ClientSize = new Size(0xa7, 2);
            //base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Name = "BasePartialView";
            this.Text = "BasePartView";
            base.ResumeLayout(false);
        }

        protected void OpenPartialAlert(Form NewView)
        {
            this.AddThroughPanel();
            NewView.TopLevel = false;
            NewView.AutoScroll = false;
            NewView.Location = new Point((this.MainPanel.Width / 2) - (NewView.Width / 2), (this.MainPanel.Height / 2) - (NewView.Height / 2));
            this.MainPanel.Controls.Add(NewView);
            NewView.Show();
            NewView.BringToFront();
        }

        protected void OpenPartialConfirmationView(Form NewView)
        {
            this.AddThroughPanel();
            NewView.TopLevel = false;
            NewView.AutoScroll = false;
            NewView.Location = new Point((this.MainPanel.Width / 2) - (NewView.Width / 2), (this.MainPanel.Height / 2) - (NewView.Height / 2));
            this.MainPanel.Controls.Add(NewView);
            NewView.Show();
            NewView.BringToFront();
        }

        protected void OpenPartialView(Form NewView)
        {
            base.Hide();
            NewView.TopLevel = false;
            NewView.AutoScroll = false;
            NewView.Location = new Point(0, 0);
            this.MainPanel.Controls.Add(NewView);
            NewView.Show();
        }

        public virtual void Reload()
        {
        }

        public virtual void SetRTFText(string RTF)
        {
        }
    }
}

