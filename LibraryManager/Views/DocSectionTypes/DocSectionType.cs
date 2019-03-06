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
    public partial class DocSectionType : BasePartialView
    {
        private DocTypeController _docSectionTypeController;

        public DocSectionType(Panel panel)
            : base(panel)
        {
            InitializeComponent();
            _docSectionTypeController = new DocTypeController();
            this.LoadDocSectionTypes();
        }

        private void LoadDocSectionTypes() 
        {
            this.DTDocSectionType.Rows.Clear();
            var docTypeList = this._docSectionTypeController.GetAll();
            foreach (var docType in docTypeList)
            {
                object[] templateObject = new object[] 
                    {
                        docType.DocTypeName
                    };
                this.DTDocSectionType.Rows.Add(templateObject);
            }
        }

        #region events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DocSectionType_Add newView = new DocSectionType_Add(base.MainPanel, this);
            base.OpenPartialView(newView);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string docSectionTypeName = this.DTDocSectionType.SelectedRows[0].Cells[0].Value.ToString();
            if(this._docSectionTypeController.HasAssociatedOutputType(docSectionTypeName))
            {
                MessageBox.Show("You cannot delete this Doc Section Type because Output Types are associated with this Doc Section Type",
                "Alert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
            else if(this._docSectionTypeController.HasAssociatedSection(docSectionTypeName))
            {
                MessageBox.Show("You cannot delete this Doc Section Type because doc sections are associated with this Doc Section Type",
                "Alert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
                newView.SetText("the doc section type: '" + docSectionTypeName + "'");
                base.OpenPartialAlert(newView);
            }
        }

        private void DTDocSectionType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnDelete.Enabled = true;
            }
            else 
            {
                BtnDelete.Enabled = false;
            }
        }
        #endregion

        public override void Delete()
        {
            try
            {
                string docSectionTypeName = this.DTDocSectionType.SelectedRows[0].Cells[0].Value.ToString();
                this._docSectionTypeController.Delete(docSectionTypeName);
                this.LoadDocSectionTypes();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
