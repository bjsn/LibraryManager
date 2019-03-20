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
    public partial class OutputType_Add_Edit : BasePartialView
    {
        private DocTypeGroupController _docTypeGroupController;
        private DocTypesByDocTypeGroupController _docTypesByDocTypeGroupController; 
        private DocTypeController _docTypeController;

        //business variables
        private string outputTypeName;

        public OutputType_Add_Edit(Panel panel, BasePartialView preview = null, string outputTypeName = "")
            : base(panel, preview)
        {
            InitializeComponent();
            this._docTypeGroupController = new DocTypeGroupController();
            this._docTypeController = new DocTypeController();
            this._docTypesByDocTypeGroupController = new DocTypesByDocTypeGroupController();

            this.outputTypeName = outputTypeName;
            LoadOutputTypeInformation();
            LoadDocTypeList();
        }

        #region bussiness
        private void LoadOutputTypeInformation() 
        {
            if (!string.IsNullOrEmpty(this.outputTypeName))
            {
                var docTypeGroup = this._docTypeGroupController.GetByName(this.outputTypeName);
                this.TxbOutputTypeName.Text = docTypeGroup.DocTypeGroupName;
                this.TxbOutputTypeName.Enabled = false;

                var docTypeByDocTypeGroupList = this._docTypesByDocTypeGroupController.GetByDocTypeGroup(this.outputTypeName);
                this.DTSectionType.Rows.Clear();
                foreach (var docTypeByDocTypeGroup in docTypeByDocTypeGroupList)
                {
                    object[] values = new object[] { docTypeByDocTypeGroup.DocType };
                    this.DTSectionType.Rows.Add(values);
                }
            }
        }

        private void LoadDocTypeList() 
        {
            var docTypeList = this._docTypeController.GetAll();
            foreach (var docType in docTypeList)
            {
                this.CbxSectionType.Items.Add(docType.DocTypeName);
            }
        }
        #endregion

        #region events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var selectedDocType = this.CbxSectionType.SelectedItem == null ? "" : this.CbxSectionType.SelectedItem;
            if (!string.IsNullOrEmpty(selectedDocType.ToString()))
            {
                bool newDocType = true;
                foreach (DataGridViewRow row in this.DTSectionType.Rows)
                {
                    var addedRow = row.Cells[0].Value;
                    if (addedRow.Equals(selectedDocType))
                    {
                        newDocType = false;
                        break;
                    }
                }
                if (newDocType)
                {
                    object[] values = new object[] { selectedDocType };
                    this.DTSectionType.Rows.Add(values);
                    this.LblAlertSection.Visible = false;
                }
                else
                {
                    this.LblAlertSection.Visible = true;
                }
            }
        }
        
        private void DTSectionType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnDelete.Enabled = true;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            this.DTSectionType.Rows.RemoveAt(this.DTSectionType.SelectedRows[0].Index);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.CloseCurrentView();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(this.outputTypeName))
            {
                //add
                bool flag = this.RequiredFieldEmpty(this.TxbOutputTypeName);
                if (!flag)
                {
                    string docTypeGroupName = this.TxbOutputTypeName.Text;
                    List<string> docTypeList = new List<string>();

                    foreach (DataGridViewRow row in this.DTSectionType.Rows)
                    {
                        docTypeList.Add(row.Cells[0].Value.ToString());
                    }
                    this.outputTypeName = this.TxbOutputTypeName.Text;
                    if (this._docTypeGroupController.IsValidName(outputTypeName))
                    {
                        this._docTypeGroupController.Add(docTypeGroupName, docTypeList);
                        this.lblNameError.Visible = false;
                        base.CloseCurrentView();
                    }
                    else
                    {
                        this.lblNameError.Text = "The Output Type Name already exists. Please enter a different name.";
                        this.lblNameError.Visible = true;
                    }
                }
            }
            else 
            {
                //update
                string docTypeGroupName = this.TxbOutputTypeName.Text;
                List<string> docTypeList = new List<string>();

                foreach (DataGridViewRow row in this.DTSectionType.Rows)
                {
                    docTypeList.Add(row.Cells[0].Value.ToString());
                }
                if (this._docTypeGroupController.IsValidName(outputTypeName))
                {
                    this._docTypeGroupController.Update(docTypeGroupName, docTypeList);
                    this.lblNameError.Visible = false;
                    base.CloseCurrentView();
                }
            }
        }
        #endregion


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
