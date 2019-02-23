using LibraryManager.Core;
using LibraryManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddEditProposalContent.Views.DocTemplates
{
    public partial class DocTemplate : BasePartialView
    {
        private DocTemplateController _docTemplateController;
        private FileController _fileController;

        public DocTemplate(Panel panel) : base(panel)
        {
            InitializeComponent();
            this._docTemplateController = new DocTemplateController();
            this._fileController = new FileController();
            this.LoadDataGrid();
            this.BtnView.Enabled = false;   
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
            UpdateWordFile();
        }
        #endregion

        //improve this function
        private void UpdateWordFile()
        {
            try
            {
                string sectionName = this.DTDocTemplate.SelectedRows[0].Cells[0].Value.ToString();
                string filePath = this._docTemplateController.GetDocTemplateFile(sectionName);
                if (!string.IsNullOrEmpty(filePath))
                {
                    string copyFilePath = this._fileController.CreateFileCopy(filePath);
                    bool fileOpenSuccessfully = this._fileController.OpenFile(filePath);

                    System.Timers.Timer timer = new System.Timers.Timer();
                    timer.Interval = 1000;
                    timer.Elapsed += delegate
                    {
                        //run timer until the user close the file, then take it and save it into the database
                        bool isFileInUse = this._fileController.IsFileInUse(filePath);
                        if (!isFileInUse)
                        {
                            timer.Stop();
                            timer.Dispose();
                            if (!timer.Enabled)
                            {
                                bool fileWithoutChanges = this._fileController.AreFilesEqual(filePath, copyFilePath);
                                //if the original file had changes
                                if (!fileWithoutChanges)
                                {
                                    this.UpdateFileChage(sectionName, filePath);
                                }
                                //delete both files 
                                this._fileController.DeleteFile(filePath);
                                this._fileController.DeleteFile(copyFilePath);

                                if (!fileWithoutChanges)
                                {
                                    if (InvokeRequired)
                                    {
                                        BeginInvoke(new MethodInvoker(this.LoadDataGrid));
                                    }
                                    else
                                    {
                                        this.LoadDataGrid();
                                    }
                                }
                            }
                        }
                    };
                    timer.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
        }

        private void UpdateFileChage(string sectionName, string filePath)
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

       

    }
}
