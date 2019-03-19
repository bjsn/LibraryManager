using LibraryManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrMgr.Views.Common.Edit_document
{
    public partial class Edit_Document : BasePartialView
    {
        public Edit_Document(BasePartialView Preview)
            : base(null, Preview)
        {
            InitializeComponent();
            CenterLabel();
        }

        public void EditText(string text) 
        {
            this.LblMessage.Text = text;
            CenterLabel();
        }

        private void CenterLabel() 
        {
            Point middel =  GetPosition();
            var with = this.LblMessage.Size.Width / 2 ;
            this.LblMessage.Location = new Point(middel.X - with, middel.Y - 5); ;
        }

        public void EditingDocument() 
        {
            this.BtnClose.Enabled = true;
        }

        public void ClosingDocument()
        {
            this.PBAlert.Visible = true;
            this.BtnClose.Visible = false;
            this.BtnCancel.Visible = true;
            this.BtnSave.Visible = true;
        }

        private Point GetPosition()
        {
            int y = (this.Height / 2);
            int x = (this.Width / 2);
            return new Point(x, y);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            base.CloseDocument();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CloseCurrent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            base.SaveChanges();
            CloseCurrent();
        }

        public void CloseCurrent() 
        {
            base.DeleteThroughPanel();
            this.ClosePartialView();
        }
        
    }
}
