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

namespace AddEditProposalContent.Views.OutputTypes
{
    public partial class OutputType : BasePartialView
    {
        private DocTypeGroupController _docTypeGroupController;

        public OutputType(Panel panel) : base(panel)
        {
            InitializeComponent();
            _docTypeGroupController = new DocTypeGroupController();
            LoadDataGrid();
        }

        #region bussines
        public override void Delete()
        {
            try
            {
                string outputName = this.DTOutputType.SelectedRows[0].Cells[0].Value.ToString();
                _docTypeGroupController.Delete(outputName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally 
            {
                LoadDataGrid();
            }
        }
        #endregion


        private void LoadDataGrid() 
        {
            try
            {
                this.DTOutputType.Rows.Clear();
                var docTypeGroupList = _docTypeGroupController.GetAll();
                foreach (var docType in docTypeGroupList)
                {
                    object[] templateObject = new object[] 
                    {
                        docType.DocTypeGroupName,
                        docType.AssociatedDocSectionTypes
                    };
                    this.DTOutputType.Rows.Add(templateObject);
                }
                RepaintAssociatedDocSectionCells();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void RepaintAssociatedDocSectionCells()
        {
             foreach (DataGridViewRow row in this.DTOutputType.Rows) 
            {
                row.Cells[1].Style.ForeColor = Color.Blue;
            }
        }

        #region Events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            BasePartialView newView = new OutputType_Add_Edit(base.MainPanel, this, "");
            base.OpenPartialView(newView);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string outputName = this.DTOutputType.SelectedRows[0].Cells[0].Value.ToString();
            BasePartialView newView = new OutputType_Add_Edit(base.MainPanel, this, outputName);
            base.OpenPartialView(newView);
        }
         
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string outputName = this.DTOutputType.SelectedRows[0].Cells[0].Value.ToString();
            Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
            newView.SetText("the output type: '" + outputName + "'");
            base.OpenPartialAlert(newView);
        }

        private void DTOutputType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.DTOutputType.SelectedRows.Count == 1)
            {
                BtnDelete.Enabled = true;
                BtnEdit.Enabled = true;
            }
            else
            {
                BtnDelete.Enabled = false;
                BtnEdit.Enabled = false;
            }
        }
        #endregion

        private void DTOutputType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) 
            {
                string outputName = this.DTOutputType.SelectedRows[0].Cells[0].Value.ToString();
                BasePartialView newView = new OutputType_Add_Edit(base.MainPanel, this, outputName);
                base.OpenPartialView(newView);
            }
        }
    }
}
