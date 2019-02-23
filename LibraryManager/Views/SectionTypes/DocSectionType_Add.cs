using LibraryManager.Core;
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

namespace AddEditProposalContent.Views.SectionTypes
{
    public partial class DocSectionType_Add : BasePartialView
    {
        DocTypeController _docTypeController;

        public DocSectionType_Add(Panel panel, BasePartialView Preview = null)
            : base(panel, Preview)
        {
            InitializeComponent();
            this._docTypeController = new DocTypeController();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.CloseCurrentView();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sectionTypeName = this.TxbSectionTypeName.Text;
                if (!RequiredFieldEmpty(this.TxbSectionTypeName))
                {
                    if (this._docTypeController.IsValidName(sectionTypeName))
                    {
                        this.LblAlertSection.Visible = false;
                        this._docTypeController.Add(sectionTypeName);
                        this.CloseCurrentView();
                    }
                    else
                    {
                        this.LblAlertSection.Visible = true;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool RequiredFieldEmpty(TextBox Textbox)
        {
            if (Textbox.Text.Length <= 0)
            {
                Textbox.BackColor = Color.FromArgb(0xcc, 0x36, 0x36);
                this.errorProvider1.SetError(Textbox, "This field is required");
                return true;
            }
            Textbox.BackColor = Color.White;
            this.errorProvider1.SetError(Textbox, "");
            return false;
        }


    }
}
