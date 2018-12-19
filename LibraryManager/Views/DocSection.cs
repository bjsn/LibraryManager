using LibraryManager.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace LibraryManager.Views
{
    public class DocSection : BasePartialView
    {
        #region components
        private IContainer components;
        private Label label6;
        private Label label7;
        private TextBox TbxSearch;
        private Button BtnAdd;
        private Button BtnEdit;
        private Button BtnDelete;
        private Button BtnExport;
        private Label label8;
        private ComboBox CbxColumn;
        private Label label1;
        private ComboBox comboBox1;
        private Panel panel1;
        private DataGridView DTSectionContent;
        private Button BtnMove;
        private PictureBox BtnSearch;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Section;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn DocType;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Source;
        private DataGridViewTextBoxColumn Updated;
        private DataGridViewTextBoxColumn UpdatedBy;
        private DataGridViewTextBoxColumn ClientUpdated;

        #endregion

        private FileController fileController;
        private DocSectionController docSectionController;
        private SetupController setupController;
        private string ClientName;

        public DocSection(Panel Panel) : base(Panel)
        {
            this.InitializeComponent();
            this.docSectionController = new DocSectionController(true);
            this.fileController = new FileController();
            this.setupController = new SetupController();
            LoadClientName();
            LoadColumnNames();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
        }

        private void DocSection_Shown(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadClientName() 
        {
            try
            {
                this.ClientName = setupController.GetClientName();
            }
            catch (Exception e)
            {
                //add logic to validate
            }
        }

        private void LoadColumnNames() 
        {
            CbxColumn.DataSource = new[]{
                        "Section",
                        "Location",
                        "DocType",
                        "Source",
                        "UpdatedBy"
                    };
        }

        private void DTSectionContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.DTSectionContent.SelectedRows.Count == 1)
            {
                if(this.DTSectionContent.SelectedRows[0].Cells[2].Value.ToString().ToUpper().Contains("INTERNAL"))
                {
                    BtnEdit.Enabled = true;
                }
                //enable just if the source is equal than the client name
                BtnDelete.Enabled = this.DTSectionContent.SelectedRows[0].Cells[5].Value.ToString().ToUpper().Contains(this.ClientName.ToUpper());
            }
            else
            {
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
                BtnMove.Enabled = false;
            }
            if (this.DTSectionContent.SelectedRows.Count >= 1)
            {
                BtnMove.Enabled = true;
            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.UpdateWordFile();
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            if (this.DTSectionContent.SelectedRows.Count > 0)
            {
                this.DTSectionContent.BackgroundColor = Color.Gray;
            }
        }
            
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
            Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
            newView.SetText("The section: '" + sectionName+"'");
            base.OpenPartialAlert(newView);
        }

        public override void Delete()
        {
            
            if (this.DTSectionContent.RowCount > 0)
            {
                string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
                this.docSectionController.DeleteBySectionName(sectionName);
                this.LoadDataGrid();
            }
        }

        private void LoadDataGrid() 
        {
            this.DTSectionContent.Rows.Clear();
            var sectionList = this.docSectionController.GetAll();
            foreach (var section in sectionList)
            {
                object[] sectionObject = new object[] { section.Order, 
                                                        section.Section, 
                                                        section.Location, 
                                                        section.DocType, 
                                                        section.Description, 
                                                        section.RecSource, 
                                                        section.UpdatedDT.ToShortDateString(), 
                                                        section.UpdatedBy, 
                                                        (section.ClientUpdatedDT.Equals(DateTime.MinValue) ? "": "Y")
                                                    };
                this.DTSectionContent.Rows.Add(sectionObject);
            }
        }

        //improve this function
        private void UpdateWordFile() 
        {
            try
            {
                string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
                string filePath = this.docSectionController.GetDocSectionFile(sectionName);
                if (!string.IsNullOrEmpty(filePath))
                {
                    string copyFilePath = this.fileController.CreateFileCopy(filePath);
                    bool fileOpenSuccessfully = this.fileController.OpenFile(filePath);
                    
                    System.Timers.Timer timer = new System.Timers.Timer();
                    timer.Interval = 1000;
                    timer.Elapsed += delegate
                    {
                        //run timer until the user close the file, then take it and save it into the database
                        bool isFileInUse = this.fileController.IsFileInUse(filePath);
                        if (!isFileInUse)
                        {
                            timer.Stop();
                            timer.Dispose();
                            if (!timer.Enabled) 
                            {
                                bool fileWithoutChanges = this.fileController.AreFilesEqual(filePath, copyFilePath);
                                //if the original file had changes
                                if (!fileWithoutChanges)
                                {
                                    this.UpdateFileChage(sectionName, filePath);
                                }
                                //delete both files 
                                this.fileController.DeleteFile(filePath);
                                this.fileController.DeleteFile(copyFilePath);

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
            catch (Exception exception)
            {
                //add error message
            }
        }

        private void UpdateFileChage(string sectionName, string filePath) 
        {
            try
            {
                byte[] fileBynary = this.fileController.GetBinaryFile(filePath);
                this.docSectionController.UpdateSectionFile(sectionName, fileBynary);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        #region components
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TbxSearch = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CbxColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DTSectionContent = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnMove = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTSectionContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Library Manager > Doc Sections";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.Location = new System.Drawing.Point(15, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Search:";
            // 
            // TbxSearch
            // 
            this.TbxSearch.BackColor = System.Drawing.Color.White;
            this.TbxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.TbxSearch.Location = new System.Drawing.Point(16, 70);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new System.Drawing.Size(199, 29);
            this.TbxSearch.TabIndex = 23;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(420, 96);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 32);
            this.BtnAdd.TabIndex = 27;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdit.Enabled = false;
            this.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(516, 95);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(106, 32);
            this.BtnEdit.TabIndex = 26;
            this.BtnEdit.Text = "View/Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(628, 95);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(90, 32);
            this.BtnDelete.TabIndex = 25;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.BtnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExport.Enabled = false;
            this.BtnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.Location = new System.Drawing.Point(628, 129);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(90, 32);
            this.BtnExport.TabIndex = 28;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label8.Location = new System.Drawing.Point(13, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Filter Column:";
            // 
            // CbxColumn
            // 
            this.CbxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CbxColumn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.CbxColumn.FormattingEnabled = true;
            this.CbxColumn.Location = new System.Drawing.Point(16, 134);
            this.CbxColumn.Name = "CbxColumn";
            this.CbxColumn.Size = new System.Drawing.Size(150, 29);
            this.CbxColumn.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(172, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Filter Value:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 29);
            this.comboBox1.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(331, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 27);
            this.panel1.TabIndex = 33;
            // 
            // DTSectionContent
            // 
            this.DTSectionContent.AllowDrop = true;
            this.DTSectionContent.AllowUserToAddRows = false;
            this.DTSectionContent.AllowUserToDeleteRows = false;
            this.DTSectionContent.AllowUserToResizeRows = false;
            this.DTSectionContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTSectionContent.BackgroundColor = System.Drawing.Color.White;
            this.DTSectionContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DTSectionContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DTSectionContent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DTSectionContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTSectionContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DTSectionContent.ColumnHeadersHeight = 25;
            this.DTSectionContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DTSectionContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Section,
            this.Location,
            this.DocType,
            this.Description,
            this.Source,
            this.Updated,
            this.UpdatedBy,
            this.ClientUpdated});
            this.DTSectionContent.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTSectionContent.DefaultCellStyle = dataGridViewCellStyle5;
            this.DTSectionContent.EnableHeadersVisualStyles = false;
            this.DTSectionContent.GridColor = System.Drawing.Color.White;
            this.DTSectionContent.Location = new System.Drawing.Point(12, 167);
            this.DTSectionContent.Name = "DTSectionContent";
            this.DTSectionContent.ReadOnly = true;
            this.DTSectionContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTSectionContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DTSectionContent.RowHeadersVisible = false;
            this.DTSectionContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DTSectionContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DTSectionContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DTSectionContent.Size = new System.Drawing.Size(706, 383);
            this.DTSectionContent.TabIndex = 34;
            this.DTSectionContent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTSectionContent_CellContentClick);
            this.DTSectionContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.DTSectionContent_DragDrop);
            this.DTSectionContent.DragOver += new System.Windows.Forms.DragEventHandler(this.DTSectionContent_DragOver);
            this.DTSectionContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DTSectionContent_MouseDown);
            this.DTSectionContent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DTSectionContent_MouseMove);
            // 
            // Id
            // 
            this.Id.HeaderText = "Order";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 45;
            // 
            // Section
            // 
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            this.Section.Width = 72;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 70;
            // 
            // DocType
            // 
            this.DocType.HeaderText = "DocType";
            this.DocType.Name = "DocType";
            this.DocType.ReadOnly = true;
            this.DocType.Width = 73;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 110;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 80;
            // 
            // Updated
            // 
            this.Updated.HeaderText = "Updated";
            this.Updated.Name = "Updated";
            this.Updated.ReadOnly = true;
            this.Updated.Width = 70;
            // 
            // UpdatedBy
            // 
            this.UpdatedBy.HeaderText = "UpdatedBy";
            this.UpdatedBy.Name = "UpdatedBy";
            this.UpdatedBy.ReadOnly = true;
            this.UpdatedBy.Width = 80;
            // 
            // ClientUpdated
            // 
            this.ClientUpdated.HeaderText = "ClientUpdated";
            this.ClientUpdated.Name = "ClientUpdated";
            this.ClientUpdated.ReadOnly = true;
            // 
            // BtnMove
            // 
            this.BtnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.BtnMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMove.Enabled = false;
            this.BtnMove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMove.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnMove.ForeColor = System.Drawing.Color.White;
            this.BtnMove.Location = new System.Drawing.Point(324, 95);
            this.BtnMove.Name = "BtnMove";
            this.BtnMove.Size = new System.Drawing.Size(90, 32);
            this.BtnMove.TabIndex = 35;
            this.BtnMove.Text = "Move";
            this.BtnMove.UseVisualStyleBackColor = false;
            this.BtnMove.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Image = global::AddEditProposalContent.Properties.Resources.search;
            this.BtnSearch.Location = new System.Drawing.Point(213, 70);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(24, 24);
            this.BtnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnSearch.TabIndex = 36;
            this.BtnSearch.TabStop = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click_1);
            // 
            // DocSection
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnMove);
            this.Controls.Add(this.DTSectionContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CbxColumn);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbxSearch);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DocSection";
            this.Text = "DocSection";
            this.Shown += new System.EventHandler(this.DocSection_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DTSectionContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void DTSectionContent_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = DTSectionContent.DoDragDrop(
                    DTSectionContent.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void DTSectionContent_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = DTSectionContent.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DTSectionContent_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DTSectionContent_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DTSectionContent.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                DTSectionContent.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;
                DTSectionContent.Rows.RemoveAt(rowIndexFromMouseDown);
                DTSectionContent.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }


        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TbxSearch.Text))
            {
                var sectionList = docSectionController.GetByKeyWord(TbxSearch.Text);
                this.DTSectionContent.Rows.Clear();
                foreach (var section in sectionList)
                {
                    object[] sectionObject = new object[] { section.Order, 
                                                            section.Section, 
                                                            section.Location, 
                                                            section.DocType, 
                                                            section.Description, 
                                                            section.RecSource, 
                                                            section.UpdatedDT.ToShortDateString(), 
                                                            section.UpdatedBy, 
                                                            (section.ClientUpdatedDT.Equals(DateTime.MinValue) ? "": "Y")
                                                        };
                    this.DTSectionContent.Rows.Add(sectionObject);
                }
            }
            else 
            {
                LoadDataGrid();
            }
        }



    }
}

