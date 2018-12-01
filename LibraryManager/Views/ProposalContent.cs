namespace LibraryManager.Views
{
    using LibraryManager.Core;
    using LibraryManager.Models;
    using LibraryManager.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ProposalContent : BasePartialView
    {
        private const string VENDORS_FULL_LIST_NAME = "--All--";
        private LibraryManager.Core.ProposalContentController ProposalContentController;
        private List<LibraryManager.Models.ProposalContent> ProposalContentList;
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
        private DataGridViewTextBoxColumn PartNumber;
        private DataGridViewTextBoxColumn Manufacturer;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn UserAdded;

        public ProposalContent(Panel Panel) : base(Panel)
        {
            this.InitializeComponent();
            this.ProposalContentController = new LibraryManager.Core.ProposalContentController();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            BasePartialView newView = new ProposalContent_Add_Edit(base.MainPanel, this);
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
            ProposalContent_Add_Edit newView = new ProposalContent_Add_Edit(base.MainPanel, this);
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

        public override void Delete()
        {
            if (this.DTProposalContent.RowCount > 0)
            {
                string partNumber = this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString();
                this.ProposalContentController.Delete(partNumber);
                this.LoadProposalContent();
            }
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
            ProposalContent_Add_Edit newView = new ProposalContent_Add_Edit(base.MainPanel, this);
            if (this.DTProposalContent.RowCount > 0)
            {
                newView.SetPartNumber(this.DTProposalContent.SelectedRows[0].Cells[0].Value.ToString());
                base.OpenPartialView(newView);
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

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            DataGridViewCellStyle style7 = new DataGridViewCellStyle();
            this.LblTotalRows = new Label();
            this.label1 = new Label();
            this.CbxUserAdded = new CheckBox();
            this.DTProposalContent = new DataGridView();
            this.PartNumber = new DataGridViewTextBoxColumn();
            this.Manufacturer = new DataGridViewTextBoxColumn();
            this.Description = new DataGridViewTextBoxColumn();
            this.UserAdded = new DataGridViewCheckBoxColumn();
            this.label8 = new Label();
            this.CbxVendors = new ComboBox();
            this.label7 = new Label();
            this.TbxSearch = new TextBox();
            this.BtnAdd = new Button();
            this.BtnEdit = new Button();
            this.BtnDelete = new Button();
            this.label6 = new Label();
            this.BtnSearch = new PictureBox();
            ((ISupportInitialize) this.DTProposalContent).BeginInit();
            ((ISupportInitialize) this.BtnSearch).BeginInit();
            base.SuspendLayout();
            this.LblTotalRows.AutoSize = true;
            this.LblTotalRows.FlatStyle = FlatStyle.Flat;
            this.LblTotalRows.Font = new Font("Segoe UI Semibold", 7f, FontStyle.Bold);
            this.LblTotalRows.ForeColor = Color.FromArgb(0, 0x72, 0xc6);
            this.LblTotalRows.Location = new Point(0x3d, 0x228);
            this.LblTotalRows.Name = "LblTotalRows";
            this.LblTotalRows.Size = new Size(0, 12);
            this.LblTotalRows.TabIndex = 0x1b;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = FlatStyle.Flat;
            this.label1.Font = new Font("Segoe UI Semibold", 7f, FontStyle.Bold);
            this.label1.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label1.Location = new Point(14, 0x228);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2f, 12);
            this.label1.TabIndex = 0x1a;
            this.label1.Text = "Showing:";
            this.CbxUserAdded.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.CbxUserAdded.AutoSize = true;
            this.CbxUserAdded.BackColor = Color.Transparent;
            this.CbxUserAdded.Cursor = Cursors.Hand;
            this.CbxUserAdded.FlatAppearance.BorderColor = Color.FromArgb(40, 40, 40);
            this.CbxUserAdded.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.CbxUserAdded.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            this.CbxUserAdded.ForeColor = Color.FromArgb(40, 40, 40);
            this.CbxUserAdded.Location = new Point(0x25a, 0x92);
            this.CbxUserAdded.Name = "CbxUserAdded";
            this.CbxUserAdded.Size = new Size(0x74, 0x13);
            this.CbxUserAdded.TabIndex = 0x19;
            this.CbxUserAdded.Text = "User-Added Only";
            this.CbxUserAdded.TextImageRelation = TextImageRelation.ImageAboveText;
            this.CbxUserAdded.UseVisualStyleBackColor = true;
            this.CbxUserAdded.CheckedChanged += new EventHandler(this.cbxUserAdded_CheckedChanged);
            this.DTProposalContent.AllowUserToAddRows = false;
            this.DTProposalContent.AllowUserToDeleteRows = false;
            this.DTProposalContent.AllowUserToResizeRows = false;
            this.DTProposalContent.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.DTProposalContent.BackgroundColor = Color.White;
            this.DTProposalContent.BorderStyle = BorderStyle.None;
            this.DTProposalContent.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.DTProposalContent.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            this.DTProposalContent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.BackColor = Color.White;
            style.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = Color.FromArgb(0, 0x72, 0xc6);
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.False;
            this.DTProposalContent.ColumnHeadersDefaultCellStyle = style;
            this.DTProposalContent.ColumnHeadersHeight = 0x19;
            this.DTProposalContent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.PartNumber, this.Manufacturer, this.Description, this.UserAdded };
            this.DTProposalContent.Columns.AddRange(dataGridViewColumns);
            this.DTProposalContent.Cursor = Cursors.Hand;
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style2.BackColor = Color.White;
            style2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            style2.ForeColor = Color.FromArgb(0x23, 0x23, 0x23);
            style2.SelectionBackColor = Color.FromArgb(0, 0x72, 0xc6);
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.False;
            this.DTProposalContent.DefaultCellStyle = style2;
            this.DTProposalContent.EnableHeadersVisualStyles = false;
            this.DTProposalContent.GridColor = Color.White;
            this.DTProposalContent.Location = new Point(13, 0xa9);
            this.DTProposalContent.Name = "DTProposalContent";
            this.DTProposalContent.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = SystemColors.Control;
            style3.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            style3.ForeColor = SystemColors.WindowText;
            style3.SelectionBackColor = SystemColors.Highlight;
            style3.SelectionForeColor = SystemColors.HighlightText;
            style3.WrapMode = DataGridViewTriState.True;
            this.DTProposalContent.RowHeadersDefaultCellStyle = style3;
            this.DTProposalContent.RowHeadersVisible = false;
            this.DTProposalContent.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DTProposalContent.ScrollBars = ScrollBars.Vertical;
            this.DTProposalContent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DTProposalContent.Size = new Size(0x2c1, 0x177);
            this.DTProposalContent.TabIndex = 0x18;
            this.DTProposalContent.CellClick += new DataGridViewCellEventHandler(this.DTProposalContent_CellClick);
            this.DTProposalContent.CellContentDoubleClick += new DataGridViewCellEventHandler(this.DTProposalContent_CellContentDoubleClick);
            style4.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.PartNumber.DefaultCellStyle = style4;
            this.PartNumber.HeaderText = "Part Number";
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.ReadOnly = true;
            this.PartNumber.Width = 0x87;
            style5.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            this.Manufacturer.DefaultCellStyle = style5;
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            this.Manufacturer.Width = 140;
            style6.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            this.Description.DefaultCellStyle = style6;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 350;
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style7.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            style7.NullValue = false;
            this.UserAdded.DefaultCellStyle = style7;
            this.UserAdded.FlatStyle = FlatStyle.Popup;
            this.UserAdded.HeaderText = "User-Added";
            this.UserAdded.Name = "UserAdded";
            this.UserAdded.ReadOnly = true;
            this.UserAdded.SortMode = DataGridViewColumnSortMode.Automatic;
            this.UserAdded.Width = 80;
            this.label8.AutoSize = true;
            this.label8.FlatStyle = FlatStyle.Flat;
            this.label8.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label8.Location = new Point(13, 110);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x6f, 15);
            this.label8.TabIndex = 0x17;
            this.label8.Text = "Manufacturer Filter:";
            this.CbxVendors.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CbxVendors.FlatStyle = FlatStyle.Popup;
            this.CbxVendors.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            this.CbxVendors.FormattingEnabled = true;
            this.CbxVendors.Location = new Point(0x10, 0x81);
            this.CbxVendors.Name = "CbxVendors";
            this.CbxVendors.Size = new Size(0xdd, 0x19);
            this.CbxVendors.TabIndex = 0x16;
            this.CbxVendors.SelectedValueChanged += new EventHandler(this.CbxVendors_SelectedValueChanged);
            this.label7.AutoSize = true;
            this.label7.FlatStyle = FlatStyle.Flat;
            this.label7.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label7.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label7.Location = new Point(15, 0x31);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x2e, 15);
            this.label7.TabIndex = 0x15;
            this.label7.Text = "Search:";
            this.TbxSearch.BackColor = Color.White;
            this.TbxSearch.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            this.TbxSearch.ImeMode = ImeMode.Katakana;
            this.TbxSearch.Location = new Point(0x10, 0x44);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new Size(0xc7, 0x18);
            this.TbxSearch.TabIndex = 20;
            this.BtnAdd.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnAdd.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnAdd.Cursor = Cursors.Hand;
            this.BtnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            this.BtnAdd.FlatStyle = FlatStyle.Flat;
            this.BtnAdd.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnAdd.ForeColor = Color.White;
            this.BtnAdd.Location = new Point(0x1b4, 0x67);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new Size(90, 0x20);
            this.BtnAdd.TabIndex = 0x13;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new EventHandler(this.BtnAdd_Click);
            this.BtnEdit.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnEdit.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnEdit.Cursor = Cursors.Hand;
            this.BtnEdit.Enabled = false;
            this.BtnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            this.BtnEdit.FlatStyle = FlatStyle.Flat;
            this.BtnEdit.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnEdit.ForeColor = Color.White;
            this.BtnEdit.Location = new Point(0x214, 0x67);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new Size(90, 0x20);
            this.BtnEdit.TabIndex = 0x12;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new EventHandler(this.BtnEdit_Click);
            this.BtnDelete.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnDelete.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnDelete.Cursor = Cursors.Hand;
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            this.BtnDelete.FlatStyle = FlatStyle.Flat;
            this.BtnDelete.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnDelete.ForeColor = Color.White;
            this.BtnDelete.Location = new Point(0x274, 0x67);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new Size(90, 0x20);
            this.BtnDelete.TabIndex = 0x11;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new EventHandler(this.BtnDelete_Click);
            this.label6.AutoSize = true;
            this.label6.FlatStyle = FlatStyle.Flat;
            this.label6.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label6.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label6.Location = new Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x145, 15);
            this.label6.TabIndex = 0x10;
            this.label6.Text = "Library Manager > Structured Proposal Content for Products";
            this.BtnSearch.Anchor = AnchorStyles.None;
            this.BtnSearch.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnSearch.BackgroundImageLayout = ImageLayout.Center;
            this.BtnSearch.Cursor = Cursors.Hand;
            //this.BtnSearch.Image = Resources.search;
            this.BtnSearch.Location = new Point(0xd5, 0x44);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new Size(0x18, 0x18);
            this.BtnSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BtnSearch.TabIndex = 15;
            this.BtnSearch.TabStop = false;
            this.BtnSearch.Click += new EventHandler(this.BtnSearch_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            base.ClientSize = new Size(730, 580);
            base.Controls.Add(this.LblTotalRows);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.CbxUserAdded);
            base.Controls.Add(this.DTProposalContent);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.CbxVendors);
            base.Controls.Add(this.BtnSearch);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.TbxSearch);
            base.Controls.Add(this.BtnAdd);
            base.Controls.Add(this.BtnEdit);
            base.Controls.Add(this.BtnDelete);
            base.Controls.Add(this.label6);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "ProposalContent";
            this.Text = "ProposalContent";
            base.Load += new EventHandler(this.ProposalContent_Load);
            ((ISupportInitialize) this.DTProposalContent).EndInit();
            ((ISupportInitialize) this.BtnSearch).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
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

        private void ProposalContent_Load(object sender, EventArgs e)
        {
            this.Reload();
        }

        public override void Reload()
        {
            this.LoadProposalVendors();
            this.LoadProposalContent();
        }
    }
}

