namespace AddEditProposalContent.Views
{
    partial class DocSection_Add
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.lblImportSection = new System.Windows.Forms.Label();
            this.PnlDocumentEdit = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSectionNameError = new System.Windows.Forms.Label();
            this.LblLocationError = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.BtnViewEdit = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVOutputTypes = new System.Windows.Forms.DataGridView();
            this.OutputTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CbxSectionType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RbtLocation_External = new System.Windows.Forms.RadioButton();
            this.RbtLocation_Internal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtSectionName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PnlDocumentEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOutputTypes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(37, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 19);
            this.label10.TabIndex = 53;
            this.label10.Text = "(import Word document)";
            // 
            // lblImportSection
            // 
            this.lblImportSection.AutoSize = true;
            this.lblImportSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblImportSection.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblImportSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblImportSection.Location = new System.Drawing.Point(37, 106);
            this.lblImportSection.Name = "lblImportSection";
            this.lblImportSection.Size = new System.Drawing.Size(327, 19);
            this.lblImportSection.TabIndex = 52;
            this.lblImportSection.Text = "Import a doc section by selecting \'Internal to library\'";
            // 
            // PnlDocumentEdit
            // 
            this.PnlDocumentEdit.Controls.Add(this.pictureBox2);
            this.PnlDocumentEdit.Controls.Add(this.label5);
            this.PnlDocumentEdit.Location = new System.Drawing.Point(12, 514);
            this.PnlDocumentEdit.Name = "PnlDocumentEdit";
            this.PnlDocumentEdit.Size = new System.Drawing.Size(343, 42);
            this.PnlDocumentEdit.TabIndex = 51;
            this.PnlDocumentEdit.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibraryManager.Views.Properties.Resources.warning;
            this.pictureBox2.Location = new System.Drawing.Point(3, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 55;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label5.Location = new System.Drawing.Point(27, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "The document is being edited!";
            // 
            // lblSectionNameError
            // 
            this.lblSectionNameError.AutoSize = true;
            this.lblSectionNameError.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionNameError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSectionNameError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(70)))));
            this.lblSectionNameError.Location = new System.Drawing.Point(20, 210);
            this.lblSectionNameError.Name = "lblSectionNameError";
            this.lblSectionNameError.Size = new System.Drawing.Size(0, 19);
            this.lblSectionNameError.TabIndex = 50;
            // 
            // LblLocationError
            // 
            this.LblLocationError.AutoSize = true;
            this.LblLocationError.BackColor = System.Drawing.Color.Transparent;
            this.LblLocationError.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LblLocationError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(70)))));
            this.LblLocationError.Location = new System.Drawing.Point(20, 195);
            this.LblLocationError.Name = "LblLocationError";
            this.LblLocationError.Size = new System.Drawing.Size(0, 19);
            this.LblLocationError.TabIndex = 49;
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.BackColor = System.Drawing.Color.Transparent;
            this.LblLocation.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.LblLocation.Location = new System.Drawing.Point(20, 140);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(0, 19);
            this.LblLocation.TabIndex = 48;
            this.LblLocation.Visible = false;
            // 
            // BtnViewEdit
            // 
            this.BtnViewEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnViewEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.BtnViewEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnViewEdit.Enabled = false;
            this.BtnViewEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BtnViewEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnViewEdit.ForeColor = System.Drawing.Color.White;
            this.BtnViewEdit.Location = new System.Drawing.Point(374, 524);
            this.BtnViewEdit.Name = "BtnViewEdit";
            this.BtnViewEdit.Size = new System.Drawing.Size(149, 32);
            this.BtnViewEdit.TabIndex = 45;
            this.BtnViewEdit.Text = "Edit Document";
            this.BtnViewEdit.UseVisualStyleBackColor = false;
            this.BtnViewEdit.Click += new System.EventHandler(this.BtnViewEdit_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(530, 524);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(90, 32);
            this.BtnCancel.TabIndex = 44;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(626, 524);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(90, 32);
            this.BtnSave.TabIndex = 43;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label4.Location = new System.Drawing.Point(421, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "following Output Types:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label3.Location = new System.Drawing.Point(421, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "The Doc Section Type appears in the";
            // 
            // DGVOutputTypes
            // 
            this.DGVOutputTypes.AllowUserToAddRows = false;
            this.DGVOutputTypes.AllowUserToDeleteRows = false;
            this.DGVOutputTypes.AllowUserToResizeColumns = false;
            this.DGVOutputTypes.AllowUserToResizeRows = false;
            this.DGVOutputTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVOutputTypes.BackgroundColor = System.Drawing.Color.White;
            this.DGVOutputTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVOutputTypes.CausesValidation = false;
            this.DGVOutputTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVOutputTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVOutputTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVOutputTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOutputTypes.ColumnHeadersVisible = false;
            this.DGVOutputTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OutputTypes});
            this.DGVOutputTypes.Enabled = false;
            this.DGVOutputTypes.GridColor = System.Drawing.Color.White;
            this.DGVOutputTypes.Location = new System.Drawing.Point(425, 70);
            this.DGVOutputTypes.MultiSelect = false;
            this.DGVOutputTypes.Name = "DGVOutputTypes";
            this.DGVOutputTypes.ReadOnly = true;
            this.DGVOutputTypes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVOutputTypes.RowHeadersVisible = false;
            this.DGVOutputTypes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DGVOutputTypes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVOutputTypes.RowTemplate.Height = 24;
            this.DGVOutputTypes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVOutputTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVOutputTypes.ShowCellErrors = false;
            this.DGVOutputTypes.ShowEditingIcon = false;
            this.DGVOutputTypes.Size = new System.Drawing.Size(283, 208);
            this.DGVOutputTypes.TabIndex = 35;
            this.DGVOutputTypes.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DGVOutputTypes_RowPostPaint);
            // 
            // OutputTypes
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.OutputTypes.HeaderText = "Output Types";
            this.OutputTypes.Name = "OutputTypes";
            this.OutputTypes.ReadOnly = true;
            this.OutputTypes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OutputTypes.Width = 283;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(8, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Description:";
            // 
            // TxtDescription
            // 
            this.TxtDescription.BackColor = System.Drawing.Color.White;
            this.TxtDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TxtDescription.Location = new System.Drawing.Point(12, 331);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(343, 101);
            this.TxtDescription.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label8.Location = new System.Drawing.Point(11, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "Doc Section Type";
            // 
            // CbxSectionType
            // 
            this.CbxSectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxSectionType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.CbxSectionType.FormattingEnabled = true;
            this.CbxSectionType.Location = new System.Drawing.Point(12, 250);
            this.CbxSectionType.Name = "CbxSectionType";
            this.CbxSectionType.Size = new System.Drawing.Size(343, 28);
            this.CbxSectionType.TabIndex = 31;
            this.CbxSectionType.SelectedIndexChanged += new System.EventHandler(this.CbxSectionType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.RbtLocation_External);
            this.panel1.Controls.Add(this.RbtLocation_Internal);
            this.panel1.Location = new System.Drawing.Point(18, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 55);
            this.panel1.TabIndex = 30;
            // 
            // RbtLocation_External
            // 
            this.RbtLocation_External.AutoSize = true;
            this.RbtLocation_External.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbtLocation_External.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.RbtLocation_External.Location = new System.Drawing.Point(2, 28);
            this.RbtLocation_External.Name = "RbtLocation_External";
            this.RbtLocation_External.Size = new System.Drawing.Size(217, 23);
            this.RbtLocation_External.TabIndex = 32;
            this.RbtLocation_External.TabStop = true;
            this.RbtLocation_External.Text = "External to library (Excel range)";
            this.RbtLocation_External.UseVisualStyleBackColor = true;
            this.RbtLocation_External.Click += new System.EventHandler(this.rbtLocation_External_Click);
            // 
            // RbtLocation_Internal
            // 
            this.RbtLocation_Internal.AutoSize = true;
            this.RbtLocation_Internal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbtLocation_Internal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.RbtLocation_Internal.Location = new System.Drawing.Point(3, 4);
            this.RbtLocation_Internal.Name = "RbtLocation_Internal";
            this.RbtLocation_Internal.Size = new System.Drawing.Size(292, 23);
            this.RbtLocation_Internal.TabIndex = 31;
            this.RbtLocation_Internal.TabStop = true;
            this.RbtLocation_Internal.Text = "Internal to library (import Word document)";
            this.RbtLocation_Internal.UseVisualStyleBackColor = true;
            this.RbtLocation_Internal.Click += new System.EventHandler(this.rbtLocation_Internal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Section Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.Location = new System.Drawing.Point(14, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Section Name:";
            // 
            // TxtSectionName
            // 
            this.TxtSectionName.BackColor = System.Drawing.Color.White;
            this.TxtSectionName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TxtSectionName.Location = new System.Drawing.Point(15, 181);
            this.TxtSectionName.MaxLength = 30;
            this.TxtSectionName.Name = "TxtSectionName";
            this.TxtSectionName.Size = new System.Drawing.Size(340, 27);
            this.TxtSectionName.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Library Manager > Doc Sections > Add/Edit";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DocSection_Add
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblImportSection);
            this.Controls.Add(this.PnlDocumentEdit);
            this.Controls.Add(this.lblSectionNameError);
            this.Controls.Add(this.LblLocationError);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.BtnViewEdit);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGVOutputTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CbxSectionType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtSectionName);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DocSection_Add";
            this.Text = "DocSection_Add";
            this.Load += new System.EventHandler(this.DocSection_Add_Load);
            this.PnlDocumentEdit.ResumeLayout(false);
            this.PnlDocumentEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOutputTypes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtSectionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RbtLocation_External;
        private System.Windows.Forms.RadioButton RbtLocation_Internal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CbxSectionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnViewEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DGVOutputTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputTypes;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label LblLocationError;
        private System.Windows.Forms.Label lblSectionNameError;
        private System.Windows.Forms.Panel PnlDocumentEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblImportSection;
    }
}