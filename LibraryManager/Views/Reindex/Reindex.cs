using LibraryManager.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibrMgr.Views.Reindex
{
    public partial class Reindex : Form
    {
        public Reindex()
        {
            InitializeComponent();
        }

        private void Reindex_Shown(object sender, EventArgs e)
        {
            UpdateLblMessage();

            ThreadWorker worker = new ThreadWorker();
            worker.ThreadDone += HandleThreadDone;

            Thread thread1 = new Thread(worker.Run);
            thread1.Start();
        }

        private void UpdateLblMessage() 
        {
            this.LblMessage.Text = "Indexing the Doc Sections, \nplease wait a moment";
            Point middel = GetPosition();
            var with = this.LblMessage.Size.Width / 2;
            this.LblMessage.Location = new Point(middel.X - with, middel.Y - 5); ;
        }

        private void HandleThreadDone(object sender, EventArgs e)
        {
            CloseCurrentView();
        }

        private void CloseCurrentView()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { CloseCurrentView(); }));
            }
            else 
            {
                this.Close();
            }
        }

        private Point GetPosition()
        {
            int y = (this.Height / 2);
            int x = (this.Width / 2);
            return new Point(x, y);
        }
    }


    class ThreadWorker
    {
        public event EventHandler ThreadDone;
        private DocSectionController _docSectionController;

        public ThreadWorker() 
        {
            _docSectionController = new DocSectionController();
        }

        public void Run()
        {
             this._docSectionController.ReOrderNumberList();

            if (ThreadDone != null)
                ThreadDone(this, EventArgs.Empty);
        }
    }
}
