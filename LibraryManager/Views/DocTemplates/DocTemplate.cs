using LibraryManager.Core;
using LibraryManager.Views;
using LibrMgr.Views.Common.Edit_document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddEditProposalContent.Views.DocTemplates
{
    public partial class DocTemplate : BasePartialView
    {
        private DocTemplateController _docTemplateController;
        private FileController _fileController;
        private bool closeDocument = false;
        private string tempFilePath = "";

        public DocTemplate(Panel panel) : base(panel)
        {
            InitializeComponent();
            this._docTemplateController = new DocTemplateController();
            this._fileController = new FileController();
            this.BtnView.Enabled = false;   
            this.LoadDataGrid();
        }

        #region Business
        private void LoadDataGrid() 
        {
            try
            {
                this.DTDocTemplate.Rows.Clear();
                var docTemplateList = _docTemplateController.Get();
                foreach (var template in docTemplateList) 
                {
                    object[] templateObject = new object[] 
                    {
                        template.Template_Name
                    };
                    this.DTDocTemplate.Rows.Add(templateObject);
                }
            }
            catch (Exception e) 
            {
                //add custom message
                MessageBox.Show(e.Message);
            }
        }

        private void LoadExternalDocument()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Import your template document";
                fileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                fileDialog.Filter = "Word Files (*.dot, *.dotx)|*.dot; *.dotx";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string documentPath = fileDialog.FileName;
                        string fileName = Path.GetFileNameWithoutExtension(documentPath);
                        if (this._docTemplateController.IsTemplateNameValid(fileName))
                        {
                            this._docTemplateController.Add(fileName, documentPath);
                            this.LoadDataGrid();
                        }
                        else 
                        {
                            MessageBox.Show("Not imported, a template with that name already exist",
                                             "Alert",
                                             MessageBoxButtons.OK, 
                                             MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception e) 
                    {
                        MessageBox.Show(e.Message);
                    }
                }

            };
        }

        private void AddDocTemplate()
        {
            LoadExternalDocument();
        }

        public override void Delete() 
        {
            try
            {
                if (this.DTDocTemplate.RowCount > 0)
                {
                    string templateName = this.DTDocTemplate.SelectedRows[0].Cells[0].Value.ToString();
                    this._docTemplateController.Delete(templateName);
                    this.LoadDataGrid();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.AddDocTemplate();
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string docTemplateName = this.DTDocTemplate.SelectedRows[0].Cells[0].Value.ToString();
            Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
            newView.SetText("the template: '" + docTemplateName + "'");
            base.OpenPartialAlert(newView);
        }


        private void DTDocTemplate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.DTDocTemplate.SelectedRows.Count == 1)
            {
                BtnDelete.Enabled = true;
                BtnView.Enabled = true;
            }
            else
            {
                BtnDelete.Enabled = false;
                BtnView.Enabled = false;
            }
        }


        private void BtnView_Click(object sender, EventArgs e)
        {
            this.tempFilePath = "";
            this.closeDocument = false;
            OpenEditDocument();
        }
        #endregion


        private async void OpenEditDocument() 
        {
            string sectionName = this.DTDocTemplate.SelectedRows[0].Cells[0].Value.ToString();
            Edit_Document edit_Document = new Edit_Document(this);
            base.OpenPartialAlert(edit_Document);

            edit_Document.EditText("Opening the " + sectionName + " doc template");
            string fileOpenedPath = "";
            await Task.Run(() => fileOpenedPath = OpenWordDocument().Result);

            if (!string.IsNullOrEmpty(fileOpenedPath)) 
            {
                edit_Document.EditText("The " + sectionName + " template \nis being edited in Word");
                edit_Document.EditingDocument();
                bool fileHasChanges = false;
                await Task.Run(() => fileHasChanges = CheckIfDocumentIsOpen(fileOpenedPath).Result);
                
                edit_Document.EditText("Processing document");
                await Task.Delay(500);
                if (fileHasChanges)
                {
                    edit_Document.EditText("Do you want to save the changes to \nthe " + sectionName + "doc template?");
                    edit_Document.ClosingDocument();
                }
                else
                {
                    edit_Document.EditText("Closing the template");
                    await Task.Delay(500);
                    edit_Document.CloseCurrent();
                    closeDocument = true;
                }
            }
        }


        public override void SaveChanges()
        {
            if (!string.IsNullOrEmpty(this.tempFilePath)) 
            {
                string sectionName = this.DTDocTemplate.SelectedRows[0].Cells[0].Value.ToString();
                byte[] GetBinaryFile = this._fileController.GetBinaryFile(this.tempFilePath);
                this._docTemplateController.UpdateTemplateFile(sectionName, GetBinaryFile);
                this._fileController.DeleteFile(this.tempFilePath);
                this.tempFilePath = "";
            }
        }


        public override void CloseDocument()
        {
            if (!string.IsNullOrEmpty(this.tempFilePath)) 
            {
                this.closeDocument = true;
            }
        }


        private async Task<string> OpenWordDocument() 
        {
            try
            {
                string sectionName = this.DTDocTemplate.SelectedRows[0].Cells[0].Value.ToString();
                string filePath = this._docTemplateController.GetDocTemplateFile(sectionName);
                this.tempFilePath = filePath;
                string copyFilePath = this._fileController.CreateFileCopy(filePath);
                bool fileOpenSuccessfully = this._fileController.OpenFile(filePath);
                return (fileOpenSuccessfully) ? filePath : "";
            }
            catch (Exception) 
            {
                throw;
            }
        }


        private async Task<bool> CheckIfDocumentIsOpen(string filePath) 
        {
            try
            {
                string copyFilePath = this._fileController.CreateFileCopy(filePath);
                bool hasFileChanges = false;
                bool isFileInUse = true;
                while (isFileInUse && closeDocument == false)
                {
                    isFileInUse = this._fileController.IsFileInUse(filePath);
                    Thread.Sleep(500);
                }
                this._fileController.CloseDocument(filePath, true);
                hasFileChanges = !this._fileController.AreFilesEqual(filePath, copyFilePath);
                this._fileController.DeleteFile(copyFilePath);
                return hasFileChanges;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void UpdateFileChange(string sectionName, string filePath)
        {
            try
            {
                byte[] fileBynary = this._fileController.GetBinaryFile(filePath);
                this._docTemplateController.UpdateTemplateFile(sectionName, fileBynary);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private void DTDocTemplate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.BtnView.Enabled = false;
                this.tempFilePath = "";
                this.closeDocument = false;
                OpenEditDocument();
            }
        }

    }
}
