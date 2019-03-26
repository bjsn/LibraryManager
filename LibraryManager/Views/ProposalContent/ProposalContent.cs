namespace LibraryManager.Views
{
    using LibrMgr.Properties;
    using LibraryManager.Core;
    using LibraryManager.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ProposalContent : BasePartialView
    {
        #region components
        private IContainer components;
        private CheckBox CbxUserAdded;
        private Label label8;
        private ComboBox CbxVendors;
        private PictureBox BtnSearch;
        private Label label7;
        private TextBox TbxSearch;
        private Button BtnAdd;
        private Button BtnEdit;
        private Button BtnDelete;
        private Label label6;
        private DataGridView DTProposalContent;
        private Label label1;
        private Label LblTotalRows;
        #endregion

        private const string VENDORS_FULL_LIST_NAME = "--All--";
        private LibraryManager.Core.ProposalContentController ProposalContentController;
        private List<LibraryManager.Models.ProposalContent> ProposalContentList;
        private DataGridViewTextBoxColumn PartNumber;
        private DataGridViewTextBoxColumn Manufacturer;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn UserAdded;
        public bool AdminContent = false;

        public ProposalContent(Panel Panel, bool requireAdminContent) : base(Panel)
        {
            this.AdminContent = requireAdminContent; 
            this.InitializeComponent();
            this.ProposalContentController = new ProposalContentController(AdminContent);
            LoadMainViewConfiguration();
        }

        private void LoadMainViewConfiguration()
        {
            //resize columns when loading admin content
            if (AdminContent) 
            {
                CbxUserAdded.Visible = false;
                int sharedSize = DTProposalContent.Columns[3].Width / 3;
                DTProposalContent.Columns[0].Width = DTProposalContent.Columns[0].Width + sharedSize;
                DTProposalContent.Columns[1].Width = DTProposalContent.Columns[1].Width + sharedSize;
                DTProposalContent.Columns[2].Width = DTProposalContent.Columns[2].Width + sharedSize;
                DTProposalContent.Columns[3].Visible = false;
            }
        }

        private void FillProposalContentTable(List<LibraryManager.Models.ProposalContent> ProposalContentList)
        {
            this.DTProposalContent.Rows.Clear();
            foreach (LibraryManager.Models.ProposalContent content in ProposalContentList)
            {
                bool flag = content.DownloadDT.Equals(DateTime.MinValue);
                object[] values = new object[] { content.PartNumber, content.VendorName, content.ProductName, flag };
                this.DTProposalContent.Rows.Add(values);
            }
            this.LblTotalRows.Text = ProposalContentList.Count + " Rows";
        }


        public override void ReloadGrid()
        {
            int selectedIndex = this.DTProposalContent.CurrentCell.RowIndex;
            this.LoadProposalContent();
            this.DTProposalContent.Rows[selectedIndex].Selected = true;
        }

        private void LoadAndFilterDataGridInformation()
        {
            string text = this.TbxSearch.Text;
            bool userAddedOnly = this.CbxUserAdded.Checked;
            this.ProposalContentList = this.ProposalContentController.GetFiltered(userAddedOnly, this.CbxVendors.SelectedItem.Equals("--All--") ? "" : this.CbxVendors.SelectedItem.ToString(), text);
            this.FillProposalContentTable(this.ProposalContentList);
        }

        private void LoadProposalContent()
        {
            this.ProposalContentList = this.ProposalContentController.Get();
            this.FillProposalContentTable(this.ProposalContentList);
        }

        private void LoadProposalVendors()
        {
            List<string> vendors = this.ProposalContentController.GetVendors();
            vendors.Insert(0, "--All--");
            this.CbxVendors.SelectedValueChanged -= new EventHandler(this.CbxVendors_SelectedValueChanged);
            this.CbxVendors.DataSource = vendors.ToArray();
            this.CbxVendors.SelectedValueChanged += new EventHandler(this.CbxVendors_SelectedValueChanged);
        }

        public override void Reload()
        {
            this.LoadProposalVendors();
            this.LoadProposalContent();
        }

        public override void Delete()
        {
            if (this.DTProposalContent.RowCount > 0)
            {
                string partNumber = this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString();
                this.ProposalContentController.Delete(partNumber);
                this.LoadProposalContent();
            }
        }

        #region Events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            BasePartialView newView = new ProposalContent_Add_Edit(base.MainPanel, this, this.AdminContent);            
            base.OpenPartialView(newView);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
            if (this.DTProposalContent.RowCount > 0)
            {
                newView.SetText("Part Number: " + this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString());
                base.OpenPartialAlert(newView);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ProposalContent_Add_Edit newView = new ProposalContent_Add_Edit(base.MainPanel, this, this.AdminContent);
            newView.SetPartNumber(this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString());
            base.OpenPartialView(newView);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string text = this.TbxSearch.Text;
            this.CbxVendors.SelectedIndex = 0;
            this.CbxUserAdded.Checked = false;
            this.ProposalContentList = this.ProposalContentController.GetByKeyWord(text);
            this.FillProposalContentTable(this.ProposalContentList);
        }

        private void cbxUserAdded_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadAndFilterDataGridInformation();
        }

        private void CbxVendors_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadAndFilterDataGridInformation();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DTProposalContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.BtnDelete.Enabled = true;
                this.BtnEdit.Enabled = true;
            }
        }

        private void DTProposalContent_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProposalContent_Add_Edit newView = new ProposalContent_Add_Edit(base.MainPanel, this, this.AdminContent);
            if (this.DTProposalContent.RowCount > 0)
            {
                newView.SetPartNumber(this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString());
                base.OpenPartialView(newView);
            }
        }

        private void ProposalContent_Load(object sender, EventArgs e)
        {
            this.Reload();
        }
        #endregion

        #region paintView
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTotalRows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbxUserAdded = new System.Windows.Forms.CheckBox();
            this.DTProposalContent = new System.Windows.Forms.DataGridView();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAdded = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.CbxVendors = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TbxSearch = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTProposalContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTotalRows
            // 
            this.LblTotalRows.AutoSize = true;
            this.LblTotalRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblTotalRows.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.LblTotalRows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.LblTotalRows.Location = new System.Drawing.Point(61, 552);
            this.LblTotalRows.Name = "LblTotalRows";
            this.LblTotalRows.Size = new System.Drawing.Size(0, 15);
            this.LblTotalRows.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(14, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Showing:";
            // 
            // CbxUserAdded
            // 
            this.CbxUserAdded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxUserAdded.AutoSize = true;
            this.CbxUserAdded.BackColor = System.Drawing.Color.Transparent;
            this.CbxUserAdded.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbxUserAdded.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CbxUserAdded.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.CbxUserAdded.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.CbxUserAdded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CbxUserAdded.Location = new System.Drawing.Point(603, 147);
            this.CbxUserAdded.Name = "CbxUserAdded";
            this.CbxUserAdded.Size = new System.Drawing.Size(148, 24);
            this.CbxUserAdded.TabIndex = 25;
            this.CbxUserAdded.Text = "User-Added Only";
            this.CbxUserAdded.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CbxUserAdded.UseVisualStyleBackColor = true;
            this.CbxUserAdded.CheckedChanged += new System.EventHandler(this.cbxUserAdded_CheckedChanged);
            // 
            // DTProposalContent
            // 
            this.DTProposalContent.AllowUserToAddRows = false;
            this.DTProposalContent.AllowUserToDeleteRows = false;
            this.DTProposalContent.AllowUserToResizeRows = false;
            this.DTProposalContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTProposalContent.BackgroundColor = System.Drawing.Color.White;
            this.DTProposalContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DTProposalContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.DTProposalContent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DTProposalContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTProposalContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DTProposalContent.ColumnHeadersHeight = 25;
            this.DTProposalContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DTProposalContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PartNumber,
            this.Manufacturer,
            this.Description,
            this.UserAdded});
            this.DTProposalContent.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTProposalContent.DefaultCellStyle = dataGridViewCellStyle6;
            this.DTProposalContent.EnableHeadersVisualStyles = false;
            this.DTProposalContent.GridColor = System.Drawing.Color.White;
            this.DTProposalContent.Location = new System.Drawing.Point(13, 169);
            this.DTProposalContent.MultiSelect = false;
            this.DTProposalContent.Name = "DTProposalContent";
            this.DTProposalContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTProposalContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DTProposalContent.RowHeadersVisible = false;
            this.DTProposalContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DTProposalContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DTProposalContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DTProposalContent.Size = new System.Drawing.Size(705, 375);
            this.DTProposalContent.TabIndex = 24;
            this.DTProposalContent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTProposalContent_CellClick);
            this.DTProposalContent.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTProposalContent_CellClick);
            this.DTProposalContent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTProposalContent_CellDoubleClick);
            // 
            // PartNumber
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.PartNumber.HeaderText = "Part Number";
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.ReadOnly = true;
            this.PartNumber.Width = 135;
            // 
            // Manufacturer
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Manufacturer.DefaultCellStyle = dataGridViewCellStyle3;
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Width = 140;
            // 
            // Description
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Description.DefaultCellStyle = dataGridViewCellStyle4;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 320;
            // 
            // UserAdded
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.NullValue = false;
            this.UserAdded.DefaultCellStyle = dataGridViewCellStyle5;
            this.UserAdded.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UserAdded.HeaderText = "User-Added";
            this.UserAdded.Name = "UserAdded";
            this.UserAdded.ReadOnly = true;
            this.UserAdded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UserAdded.Width = 105;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label8.Location = new System.Drawing.Point(13, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Manufacturer Filter:";
            // 
            // CbxVendors
            // 
            this.CbxVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxVendors.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.CbxVendors.FormattingEnabled = true;
            this.CbxVendors.Location = new System.Drawing.Point(16, 129);
            this.CbxVendors.Name = "CbxVendors";
            this.CbxVendors.Size = new System.Drawing.Size(221, 29);
            this.CbxVendors.TabIndex = 22;
            this.CbxVendors.SelectedValueChanged += new System.EventHandler(this.CbxVendors_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.Location = new System.Drawing.Point(15, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Search:";
            // 
            // TbxSearch
            // 
            this.TbxSearch.BackColor = System.Drawing.Color.White;
            this.TbxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TbxSearch.Location = new System.Drawing.Point(16, 68);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new System.Drawing.Size(199, 27);
            this.TbxSearch.TabIndex = 20;
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
            this.BtnAdd.Location = new System.Drawing.Point(436, 103);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 32);
            this.BtnAdd.TabIndex = 19;
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
            this.BtnEdit.Location = new System.Drawing.Point(532, 103);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(90, 32);
            this.BtnEdit.TabIndex = 18;
            this.BtnEdit.Text = "Edit";
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
            this.BtnDelete.Location = new System.Drawing.Point(628, 103);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(90, 32);
            this.BtnDelete.TabIndex = 17;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(424, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Library Manager > Structured Proposal Content for Products";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Image = global::LibrMgr.Properties.Resources.search;
            this.BtnSearch.Location = new System.Drawing.Point(213, 68);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(23, 23);
            this.BtnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnSearch.TabIndex = 15;
            this.BtnSearch.TabStop = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // ProposalContent
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.LblTotalRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbxUserAdded);
            this.Controls.Add(this.DTProposalContent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CbxVendors);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbxSearch);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProposalContent";
            this.Text = "ProposalContent";
            this.Load += new System.EventHandler(this.ProposalContent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTProposalContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void DTProposalContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.BtnDelete.Enabled = true;
                this.BtnEdit.Enabled = true;
                ProposalContent_Add_Edit newView = new ProposalContent_Add_Edit(base.MainPanel, this, this.AdminContent);
                newView.SetPartNumber(this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString());
                base.OpenPartialView(newView);
            }
        }

    }
}

