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

namespace AddEditProposalContent.Views
{
    public partial class DocSection_Add :  BasePartialView
    {
        #region #controllers
        private DocTypeController _docTypeController;
        private DocTypesByDocTypeGroupController _docTypesByDocTypeGroupController;
        private DocSectionController _docSectionController;
        private FileController _fileController;
        #endregion

        #region variables
        private string documentPath;
        private string documentLocation;
        private string sectionName;
        private bool isNewSection;
        private string openFileTempPath;
        private bool killDocumentOpenCheck = false;
        #endregion

        public DocSection_Add(Panel Panel, BasePartialView Preview = null, string sectionName = "")
            : base(Panel, Preview)
        {
            this.sectionName = sectionName;

            InitializeComponent();
            this.InitializeControllers();
            this.LoadDocTypes();
            this.LoadDocSection();
            this.LoadOutputs();
            this.DefaultEditDocumentVisibility();
        }

        #region Initializers
        private void InitializeControllers() 
        {
            this._docSectionController = new DocSectionController();
            this._docTypeController = new DocTypeController();
            this._docTypesByDocTypeGroupController = new DocTypesByDocTypeGroupController();
            this._fileController = new FileController();
        }
        #endregion

        #region Events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CloseOpenedFile();
            base.ClosePartialView();
        }

        private void CbxSectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadOutputTypes();
        }

        bool activate = true;
        private void rbtLocation_Internal_Click(object sender, EventArgs e)
        {
            if (activate) 
            {
                this.documentLocation = "Internal";
                this.LblLocationError.Visible = false;
                this.LoadExternalDocument();
            }
            activate = true;
        }

        private void rbtLocation_External_Click(object sender, EventArgs e)
        {
            this.documentLocation = "External";
            this.LblLocationError.Visible = false;
            this.LblLocation.Visible = false;
            this.BtnViewEdit.Enabled = false;
        }

        private void BtnViewEdit_Click(object sender, EventArgs e)
        {
            activate = false;
            this.UpdateWordFile();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                bool requiredName = this.RequiredFieldEmpty(this.TxtSectionName);
                bool requiredDocument = IsDocumentRequired();
                if (!requiredName && !requiredDocument)
                {
                    if (!string.IsNullOrEmpty(this.openFileTempPath)) 
                    {
                        if (this._fileController.IsFileInUse(this.openFileTempPath))
                        {
                            this.killDocumentOpenCheck = true;
                            this.CloseOpenedFile(saveDocument: true);
                            this.documentPath = this.openFileTempPath;
                        }
                    }

                    if (this.isNewSection)
                    {
                        if (this._docSectionController.IsDocSectionNameValid(this.TxtSectionName.Text))
                        {
                            int result = this._docSectionController.Add(this.TxtSectionName.Text, this.documentLocation, this.documentPath,
                                                                        this.CbxSectionType.SelectedItem.ToString(), this.TxtDescription.Text);
                        }
                        else
                        {
                            this.lblSectionNameError.Text = "The section name already exist, try with a different one.";
                            this.lblSectionNameError.Visible = true;
                        }
                    }
                    else 
                    {
                        int result = this._docSectionController.Update(this.TxtSectionName.Text, this.documentLocation, this.documentPath,
                                                                       this.CbxSectionType.SelectedItem.ToString(), this.TxtDescription.Text);
                    }
                    this.lblSectionNameError.Visible = false;
                    this.killDocumentOpenCheck = false;
                    CloseOpenedFile();
                    base.CloseCurrentView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Business

        private void DefaultEditDocumentVisibility() 
        {
            if (string.IsNullOrEmpty(this.sectionName))
            {
                this.BtnViewEdit.Visible = false;
            }
        }


        private void LoadDocSection()
        {

            if (!string.IsNullOrEmpty(this.sectionName)) 
            {
                var docSection = this._docSectionController.GetByName(this.sectionName);
                this.isNewSection = false;

                this.TxtSectionName.Enabled = false;
                this.TxtSectionName.Text = docSection.Section;
                this.TxtDescription.Text = docSection.Description;
                this.CbxSectionType.SelectedItem = docSection.DocType;
                if (docSection.Location.Equals("Internal"))
                {
                    this.RbtLocation_Internal.Checked = true;
                    this.BtnViewEdit.Enabled = true;
                    this.LblLocation.Text = "Saved in the database";
                    this.LblLocation.Visible = true;
                    this.documentLocation = "Internal";
                }
                else
                {
                    this.RbtLocation_External.Checked = true;
                    this.BtnViewEdit.Enabled = false;
                    this.documentLocation = "External";
                }
                this.RbtLocation_External.Enabled = false;
                this.RbtLocation_Internal.Enabled = false;
            }
            else
            {
                this.isNewSection = true;
            }
        }

        private void LoadDocTypes()
        {
            var docTypes = this._docTypeController.GetAll();
            this.CbxSectionType.DataSource = docTypes.Select(x => x.DocTypeName).ToList();
        }

        private void LoadOutputTypes()
        {
            try
            {
                string selectedOutput = this.CbxSectionType.SelectedItem.ToString();
                var outputTypesByDocSection = this._docTypesByDocTypeGroupController.GetByDocType(selectedOutput);
                this.DGVOutputTypes.Rows.Clear();
                foreach (var outputTypeGroup in outputTypesByDocSection)
                {
                    object[] values = new object[] { outputTypeGroup.DocTypeGroupName };
                    this.DGVOutputTypes.Rows.Add(values);
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LoadExternalDocument()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Import your section document";
                fileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                fileDialog.Filter = "Word Files (*.doc, *.docx)|*.docx; *.doc";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.documentPath = fileDialog.FileName;
                    string fileName = Utilitary.GetFileNameFromPath(documentPath);
                    this.TxtSectionName.Text = fileName;

                    this.LblLocation.Text = this.documentPath;
                    this.LblLocation.Visible = true;
                    this.BtnViewEdit.Enabled = true;
                }
                else
                {
                    this.RbtLocation_Internal.Checked = false;
                    this.LblLocation.Visible = false;
                    this.BtnViewEdit.Enabled = false;
                }
            };
        }

        public void LoadOutputs() 
        {

        }

        private void CloseOpenedFile(bool saveDocument = false) 
        {
            if (!string.IsNullOrEmpty(this.openFileTempPath)) 
            {
                this._fileController.CloseDocument(openFileTempPath, saveDocument);
                this.BtnViewEdit.Enabled = true;
                this.PnlDocumentEdit.Visible = false;
            }
        }

        private void UpdateWordFile()
        {
            try
            {
                this.PnlDocumentEdit.Visible = true;
                string sectionName = this.TxtSectionName.Text.ToString();
                string filePath = "";
                
                if (this.isNewSection)
                {
                    filePath = this.documentPath;
                }
                else
                {
                    if (string.IsNullOrEmpty(this.openFileTempPath))
                    {
                        filePath = this._docSectionController.GetDocSectionFile(sectionName);
                    }
                    else 
                    {
                        filePath = this.openFileTempPath;
                    }
                }

                if (this._fileController.IsFileInUse(filePath)) 
                {
                    MessageBox.Show("This file is already open, please close it before edit it.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.BtnViewEdit.Enabled = true;
                    this.PnlDocumentEdit.Visible = false;
                    return;
                }

                if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(sectionName))
                {
                    this.BtnViewEdit.Enabled = false;
                    string copyFilePath = this._fileController.CreateFileCopy(filePath);
                    bool fileOpenSuccessfully = this._fileController.OpenFile(filePath);
                    this.openFileTempPath = filePath;

                    System.Timers.Timer timer = new System.Timers.Timer();
                    timer.Interval = 1000;
                    timer.Elapsed += delegate
                    {
                        bool isFileInUse = this._fileController.IsFileInUse(filePath);
                        if (!isFileInUse || killDocumentOpenCheck == true)
                        {
                            timer.Stop();
                            timer.Dispose();
                            //check just if the word instance was closed by the user, if the process was killed does not make the check
                            if (!killDocumentOpenCheck) 
                            {
                                if (!timer.Enabled)
                                {
                                    bool fileWithoutChanges = this._fileController.AreFilesEqual(filePath, copyFilePath);
                                    if (!fileWithoutChanges)
                                    {
                                        this.documentPath = filePath;
                                    }
                                    this._fileController.DeleteFile(copyFilePath);
                                }
                                if (this.PnlDocumentEdit.InvokeRequired)
                                {
                                    this.PnlDocumentEdit.Invoke(new Action(() => this.PnlDocumentEdit.Visible = false));
                                    this.BtnViewEdit.Invoke(new Action(() => this.BtnViewEdit.Enabled = true));
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
                this._docSectionController.UpdateSectionFile(sectionName, fileBynary);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private bool IsDocumentRequired() 
        {
            if (this.RbtLocation_External.Checked) 
            {
                this.LblLocation.Visible = false;
                return false;
            }
            else if (this.RbtLocation_Internal.Checked)
            {
                this.LblLocation.Visible = true;
                return false;
            }
            else 
            {
                this.LblLocation.Visible = false;
                this.LblLocationError.Visible = true;
                this.LblLocationError.Text = "*Is required to choose an option";
                this.LblLocationError.ForeColor = Color.FromArgb(0xcc, 0x36, 0x36);
            }
            return true;
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

        public void SetSectionName(string sectionName) 
        {
            this.sectionName = sectionName;
        }
        #endregion

        private void BtnViewEdit_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void DocSection_Add_Load(object sender, EventArgs e)
        {
            this.DGVOutputTypes.CurrentRow.Selected = false;
        }

    }
}
