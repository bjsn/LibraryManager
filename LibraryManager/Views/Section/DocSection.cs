using LibraryManager.Core;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using AddEditProposalContent.Views;
using System.Threading;
using System.Threading.Tasks;

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
        private DataGridView DTSectionContent;
        private Button BtnIndex;
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
        private DocSectionController _docSectionController;
        private SetupController _setupController;
        private Label LblDtgvAlert;
        private string ClientName;
        private Label lblSaveAlert;
        private List<double> ListOrderIndexes;

        public DocSection(Panel Panel) : base(Panel)
        {
            this.InitializeComponent();
            this._docSectionController = new DocSectionController(true);
            this.fileController = new FileController();
            this._setupController = new SetupController();
            LoadClientName();
            LoadColumnNames();
            SetTimer();
        }

        #region components
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblDtgvAlert = new System.Windows.Forms.Label();
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TbxSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.PictureBox();
            this.BtnIndex = new System.Windows.Forms.Button();
            this.lblSaveAlert = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DTSectionContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // LblDtgvAlert
            // 
            this.LblDtgvAlert.AutoSize = true;
            this.LblDtgvAlert.BackColor = System.Drawing.Color.Transparent;
            this.LblDtgvAlert.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LblDtgvAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LblDtgvAlert.Location = new System.Drawing.Point(328, 554);
            this.LblDtgvAlert.Name = "LblDtgvAlert";
            this.LblDtgvAlert.Size = new System.Drawing.Size(472, 19);
            this.LblDtgvAlert.TabIndex = 37;
            this.LblDtgvAlert.Text = "You can only move/cut doc sections if the list is sorted by the Order column";
            this.LblDtgvAlert.Visible = false;
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
            this.DTSectionContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DTSectionContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
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
            this.DTSectionContent.Location = new System.Drawing.Point(12, 100);
            this.DTSectionContent.Name = "DTSectionContent";
            this.DTSectionContent.ReadOnly = true;
            this.DTSectionContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
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
            this.DTSectionContent.Size = new System.Drawing.Size(706, 448);
            this.DTSectionContent.TabIndex = 34;
            this.DTSectionContent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTSectionContent_CellContentClick);
            this.DTSectionContent.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DTSectionContent_CellMouseClick);
            this.DTSectionContent.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DTSectionContent_CellPainting);
            this.DTSectionContent.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DTSectionContent_ColumnHeaderMouseClick);
            this.DTSectionContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.DTSectionContent_DragDrop);
            this.DTSectionContent.DragOver += new System.Windows.Forms.DragEventHandler(this.DTSectionContent_DragOver);
            this.DTSectionContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DTSectionContent_MouseClick);
            this.DTSectionContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DTSectionContent_MouseDown);
            this.DTSectionContent.MouseLeave += new System.EventHandler(this.DTSectionContent_MouseLeave);
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
            this.BtnAdd.Location = new System.Drawing.Point(419, 63);
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
            this.BtnEdit.Location = new System.Drawing.Point(515, 63);
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
            this.BtnDelete.Location = new System.Drawing.Point(627, 63);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(90, 32);
            this.BtnDelete.TabIndex = 25;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.Location = new System.Drawing.Point(11, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Search:";
            // 
            // TbxSearch
            // 
            this.TbxSearch.BackColor = System.Drawing.Color.White;
            this.TbxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.TbxSearch.Location = new System.Drawing.Point(12, 63);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new System.Drawing.Size(199, 29);
            this.TbxSearch.TabIndex = 23;
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
            // BtnSearch
            // 
            this.BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Image = global::LibrMgr.Properties.Resources.search;
            this.BtnSearch.Location = new System.Drawing.Point(209, 63);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(24, 24);
            this.BtnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnSearch.TabIndex = 36;
            this.BtnSearch.TabStop = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click_1);
            // 
            // BtnIndex
            // 
            this.BtnIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnIndex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIndex.Enabled = false;
            this.BtnIndex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIndex.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnIndex.ForeColor = System.Drawing.Color.White;
            this.BtnIndex.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnIndex.Location = new System.Drawing.Point(323, 63);
            this.BtnIndex.Name = "BtnIndex";
            this.BtnIndex.Size = new System.Drawing.Size(90, 32);
            this.BtnIndex.TabIndex = 35;
            this.BtnIndex.Text = "Save";
            this.BtnIndex.UseVisualStyleBackColor = false;
            this.BtnIndex.Click += new System.EventHandler(this.BtnReIndex_Click);
            // 
            // lblSaveAlert
            // 
            this.lblSaveAlert.AutoSize = true;
            this.lblSaveAlert.BackColor = System.Drawing.Color.Transparent;
            this.lblSaveAlert.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblSaveAlert.Location = new System.Drawing.Point(12, 551);
            this.lblSaveAlert.Name = "lblSaveAlert";
            this.lblSaveAlert.Size = new System.Drawing.Size(226, 20);
            this.lblSaveAlert.TabIndex = 38;
            this.lblSaveAlert.Text = "Click save to apply the changes!";
            this.lblSaveAlert.Visible = false;
            // 
            // DocSection
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.lblSaveAlert);
            this.Controls.Add(this.LblDtgvAlert);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnIndex);
            this.Controls.Add(this.DTSectionContent);
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

        private void LoadColumnNames()
        {
            //CbxColumn.DataSource = new[]{
            //            "--All--",
            //            "Section",
            //            "Location",
            //            "DocType",
            //            "Source",
            //            "UpdatedBy"
            //        };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DocSection_Shown(object sender, EventArgs e)
        {
            LoadDataGrid();
            LoadIndexesList();
        }

        private void LoadClientName() 
        {
            try
            {
                this.ClientName = _setupController.GetClientName();
            }
            catch (Exception e)
            {
                //change this for the error implementation
                MessageBox.Show("Error:"  + e.Message);
            }
        }

        private void DTSectionContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.DTSectionContent.SelectedRows.Count == 1)
            {
                if(this.DTSectionContent.SelectedRows[0].Cells[2].Value.ToString().ToUpper().Contains("INTERNAL"))
                {
                    BtnEdit.Enabled = true;
                }
                BtnDelete.Enabled = this.DTSectionContent.SelectedRows[0].Cells[5].Value.ToString().ToUpper().Contains(this.ClientName.ToUpper());
            }
            else
            {
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
            DocSection_Add newView = new DocSection_Add(base.MainPanel, this, sectionName);
            base.OpenPartialView(newView);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            BasePartialView newView = new DocSection_Add(base.MainPanel, this);
            base.OpenPartialView(newView);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
            Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
            newView.SetText("The section: '" + sectionName+"'");
            base.OpenPartialAlert(newView);
        }

        Wait_Alert waitAlert = null;
        private void OpenReindexForm() 
        {
            waitAlert = new Wait_Alert(base.MainPanel, this);
            waitAlert.SetText("Reindexing the doc sections");
            base.OpenPartialAlert(waitAlert);
        }

        private void CloseWaitAlert() 
        {
            if (waitAlert != null) 
            {
                waitAlert.CloseCurrentAlert();
            }
        }


        public override void Delete()
        {
            if (this.DTSectionContent.RowCount > 0)
            {
                string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
                this._docSectionController.DeleteBySectionName(sectionName);
                this.LoadDataGrid();
            }
        }

        public override void Reload()
        {
            this.LoadDataGrid();
        }

        private void LoadDataGrid() 
        {
            this.DTSectionContent.Rows.Clear();
            var sectionList = this._docSectionController.GetAll();
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


        private void LoadIndexesList()
        {
            this.ListOrderIndexes = this._docSectionController.GetAllIndexes();
        }

        //improve this function
        private void UpdateWordFile() 
        {
            try
            {
                string sectionName = this.DTSectionContent.SelectedRows[0].Cells[1].Value.ToString();
                string filePath = this._docSectionController.GetDocSectionFile(sectionName);
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
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
        }

        private void UpdateFileChage(string sectionName, string filePath) 
        {
            try
            {
                byte[] fileBynary = this.fileController.GetBinaryFile(filePath);
                this._docSectionController.UpdateSectionFile(sectionName, fileBynary);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        #region Drang and drop functionality

        private Rectangle DragBoxFromMouseDown;
        private int RowIndexFromMouseDown;
        private int RowIndexOfItemUnderMouseToDrop;
        private System.Timers.Timer LoopTimerHoldDown;
        private int RowHoverInt = 0;
        private int SavedRowInt = 0;
        private bool DTSortedById = true;
        private List<DataGridViewRow> CutRows = new List<DataGridViewRow>();

        private void SetTimer() 
        {
            //loop timer
            LoopTimerHoldDown = new System.Timers.Timer();
            LoopTimerHoldDown.Interval = 100;//interval in milliseconds
            LoopTimerHoldDown.Enabled = false;
            LoopTimerHoldDown.Elapsed += LoopTimerEvent;
            LoopTimerHoldDown.AutoReset = true;
        }

        private void LoopTimerEvent(Object source, ElapsedEventArgs e)
        {
            if (this.DTSortedById)
            {
                int FirstIndex = this.DTSectionContent.FirstDisplayedScrollingRowIndex;
                int MaximunShowedRows = 16;

                if (this.DTSectionContent.InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        Point p = DTSectionContent.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                        DataGridView.HitTestInfo hti = DTSectionContent.HitTest(p.X, p.Y);
                        int index = (hti.RowIndex - FirstIndex + 1);
                        RowHoverInt = hti.RowIndex;

                        if (SavedRowInt != RowHoverInt && hti.RowIndex > -1 && SavedRowInt > -1)
                        {
                            this.DTSectionContent.InvalidateRow(SavedRowInt);
                            this.DTSectionContent.InvalidateRow(hti.RowIndex);
                        }

                        SavedRowInt = RowHoverInt;
                        if (index >= MaximunShowedRows - 2)
                        {
                            this.DTSectionContent.FirstDisplayedScrollingRowIndex = Math.Max(0, FirstIndex + 2);
                        }
                        else if (index <= 2)
                        {
                            if (FirstIndex > 0)
                            {
                                this.DTSectionContent.FirstDisplayedScrollingRowIndex = Math.Max(0, FirstIndex - 2);
                            }
                        }
                    }));
                }
            }
        }


        private void DTSectionContent_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //check to top
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex == RowHoverInt && RowHoverInt >= 0 && LoopTimerHoldDown.Enabled)
            {
                using (Pen p = new Pen(Color.LightGray, 5))
                {
                    var cb = e.CellBounds;  // a short reference
                    e.PaintBackground(e.ClipBounds, true);
                    e.PaintContent(e.ClipBounds);
                    e.Graphics.DrawLine(p, cb.X, cb.Y + cb.Height, cb.X + cb.Width, cb.Y + cb.Height);
                    e.Handled = true;
                }
            }
        }
        
        private void DTSectionContent_MouseLeave(object sender, EventArgs e)
        {
            //loopTimerHoldDown.Enabled = false;
        }

        private void DTSectionContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.DTSortedById) 
            {
                // Get the index of the item the mouse is below.
                RowIndexFromMouseDown = DTSectionContent.HitTest(e.X, e.Y).RowIndex;
                if (RowIndexFromMouseDown != -1)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    DragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
                else
                {
                    // Reset the rectangle if the mouse is not over an item in the ListBox.
                    DragBoxFromMouseDown = Rectangle.Empty;
                }
            }
        }


        private void DTSectionContent_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (!LoopTimerHoldDown.Enabled)
                {
                    LoopTimerHoldDown.Enabled = true;
                }

                // If the mouse moves outside the rectangle, start the drag.
                if (DragBoxFromMouseDown != Rectangle.Empty &&
                    !DragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = DTSectionContent.DoDragDrop(DTSectionContent.Rows[RowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
            else 
            {
                LoopTimerHoldDown.Enabled = false;
            }
        }

        private void DTSectionContent_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DTSectionContent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control))
            {
                return;
            }
        }

        private void DTSectionContent_DragDrop(object sender, DragEventArgs e)
        {
            List<DataGridViewRow> SelectedRows =
            (from DataGridViewRow row in DTSectionContent.SelectedRows
             where !row.IsNewRow
             orderby row.Index
             select row).ToList<DataGridViewRow>();
            
            Point clientPoint = DTSectionContent.PointToClient(new Point(e.X, e.Y));
            RowIndexOfItemUnderMouseToDrop = DTSectionContent.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            
            //reorder list in background to save them in the database
            ReorderFullIndexList(SelectedRows, RowIndexOfItemUnderMouseToDrop);

            foreach (DataGridViewRow rowToMove in SelectedRows)
            {
                if (e.Effect == DragDropEffects.Move && RowHoverInt > -1)
                {
                    DataGridViewRow example = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                    DataGridViewRow rowCopy = rowToMove;
                    DTSectionContent.Rows.RemoveAt(rowToMove.Index);
                    DTSectionContent.Rows.Insert(RowIndexOfItemUnderMouseToDrop, rowCopy);
                }
            }

            DTSectionContent.ClearSelection();

            foreach (DataGridViewRow rowToMove in SelectedRows)
            {
                rowToMove.Selected = true;
            }

            if (LoopTimerHoldDown.Enabled)
            {
                LoopTimerHoldDown.Enabled = false;
                if (RowHoverInt >= 0)
                {
                    this.DTSectionContent.InvalidateRow(RowHoverInt);
                }
            }

            //activate the index button if the list is order by id
            if (this.DTSortedById == true)
            {
                this.BtnIndex.Enabled = true;
                this.lblSaveAlert.Visible = true;
            }

        }

        /// <summary>
        /// </summary>
        /// <param name="ListToMove"></param>
        /// <param name="rowToMove"></param>
        private void ReorderFullIndexList(List<DataGridViewRow> ListRowsToMove, int RowIndexOfItemUnderMouseToDrop) 
        {
            try
            {
                List<double> LocalOrderIndexes = this.ListOrderIndexes;
                DataGridViewRow RowToDrop = this.DTSectionContent.Rows[RowIndexOfItemUnderMouseToDrop];
                double OrderIdRow = (double)RowToDrop.Cells[0].Value;
                var eee = RowToDrop.Cells[1].Value;
                int indexToInsert = LocalOrderIndexes.FindIndex(x => x == OrderIdRow);

                List<double> IndexElemetsToMove = new List<double>();
                foreach (var RowToMove in ListRowsToMove) 
                {
                    double OrderNumberRow = (double)RowToMove.Cells[0].Value;
                    int IndexInFullList = LocalOrderIndexes.FindIndex(x => x == OrderNumberRow);
                    if (IndexInFullList >= 0)
                    {
                        LocalOrderIndexes.RemoveAt(IndexInFullList);
                        LocalOrderIndexes.Insert(indexToInsert, OrderNumberRow);
                    }
                    else 
                    {
                        throw new Exception("Error no element found");
                    }
                }

                //reasign element to the normal list
                this.ListOrderIndexes = LocalOrderIndexes;
            }
            catch (Exception e) 
            {
                //change this
            }
        }

        private void DTSectionContent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //disable Index button if the list is not order by number
            if (e.ColumnIndex == 0)
            {
                this.DTSortedById = true;
                this.LblDtgvAlert.Visible = false;
            }
            else
            {
                this.DTSortedById = false;
                this.BtnIndex.Enabled = false;
                this.lblSaveAlert.Visible = false;
                this.LblDtgvAlert.Visible = true;
            }
        }
        #endregion

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TbxSearch.Text))
            {
                var sectionList = _docSectionController.GetByKeyWord(TbxSearch.Text);
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

        //Re index the order of the elemets in th respective order they should be
        private void BtnReIndex_Click(object sender, EventArgs e)
        {
            OpenReindexForm();
            
            ThreadStart threadStart = new ThreadStart(ReindexElements);
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            this.LoadDataGrid();
            this.ListOrderIndexes.Clear();
            this.LoadIndexesList();
            CloseWaitAlert();
        }

        private void ReindexElements() 
        {
            this._docSectionController.ReIndexAllSections(this.ListOrderIndexes);
        }

        //add cut/past functionality buttom
        private void DTSectionContent_MouseClick(object sender, MouseEventArgs e)
        {
            //get clicked row index
            DataGridView dgv = (DataGridView)sender;
            int rowIndex =  dgv.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex >= 0) 
            {
                //get selected rows
                List<DataGridViewRow> SelectedRows =
                    (from DataGridViewRow row in this.DTSectionContent.SelectedRows
                     where !row.IsNewRow
                     orderby row.Index
                     select row).ToList<DataGridViewRow>();

                bool SelectedInList = (from row in SelectedRows
                                       where row.Index == rowIndex
                                       select row.Index).Any();

                if (!SelectedInList)
                {
                    this.DTSectionContent.ClearSelection();
                    this.DTSectionContent.Rows[rowIndex].Selected = true;
                }

                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu menuContext = new ContextMenu();
                    menuContext.MenuItems.Add("Cut", new EventHandler(MenuContext_CutAction));
                    menuContext.MenuItems.Add("Paste", new EventHandler(MenuContext_PasteAction));

                    //enable or disable cut paste
                    menuContext.MenuItems[1].Enabled = (CutRows.Count > 0);
                    if (!DTSortedById) 
                    {
                        menuContext.MenuItems[0].Enabled = false;
                        menuContext.MenuItems[1].Enabled = false;
                    }
                    int currentMouseOverRow = this.DTSectionContent.HitTest(e.X, e.Y).RowIndex;
                    menuContext.Show(this.DTSectionContent, new Point(e.X, e.Y));
                }
            }
        }


        public void MenuContext_CutAction(object sender, EventArgs e)
        {
            try 
            {
                if (CutRows.Count > 0) 
                {
                    foreach (var row in CutRows)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    CutRows.Clear();
                }

                List<DataGridViewRow> SelectedRows =
               (from DataGridViewRow row in this.DTSectionContent.SelectedRows
                where !row.IsNewRow
                orderby row.Index
                select row).ToList<DataGridViewRow>();
                foreach(var row in SelectedRows)
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                CutRows.AddRange(SelectedRows);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void MenuContext_PasteAction(object sender, EventArgs e)
        {
            Point clientPoint = DTSectionContent.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            RowIndexOfItemUnderMouseToDrop = (from DataGridViewRow row in this.DTSectionContent.SelectedRows
                                              where !row.IsNewRow
                                              orderby row.Index
                                              select row.Index).FirstOrDefault();


            //reorder list in background to save them in the database
            ReorderFullIndexList(CutRows, RowIndexOfItemUnderMouseToDrop);

            foreach (DataGridViewRow rowToMove in CutRows)
            {
                DataGridViewRow rowCopy = rowToMove;
                DTSectionContent.Rows.RemoveAt(rowToMove.Index);
                DTSectionContent.Rows.Insert(RowIndexOfItemUnderMouseToDrop, rowCopy);
            }

            DTSectionContent.ClearSelection();
            foreach (DataGridViewRow rowToMove in CutRows)
            {
                rowToMove.Selected = true;
            }

            foreach (var row in CutRows)
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.Selected = true;
            }
            CutRows.Clear();

            this.BtnIndex.Enabled = true;
            this.lblSaveAlert.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CbxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}

