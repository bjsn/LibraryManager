namespace LibraryManager.Views
{
    using LibraryManager.Core;
    using LibraryManager.Models;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class ProposalContent_Add_Edit : BasePartialView
    {
        private LibraryManager.Core.ProposalContentController ProposalContentController;
        private string PartNumber;
        private int DocumentPartEdit;
        private bool NewProposalContent;
        public bool AdminContent = false;

        #region components
        private IContainer components;
        private Label label6;
        private Label label1;
        private TextBox TxbPartNumber;
        private TextBox TxbManufacturer;
        private Label label2;
        private PictureBox PBProduct;
        private Label label3;
        private TextBox TxbPDescription;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Button BtnCancel;
        private Button BtnSave;
        private Button BtnRemoveImage;
        private RichTextBox TxbPDetails;
        private RichTextBox TxbPOverview;
        private RichTextBox TxbPBenefits;
        private ErrorProvider errorProvider1;
        private Button BtnAddImage;
        #endregion

        public ProposalContent_Add_Edit(Panel Panel, BasePartialView Preview = null, bool requireAdminContent = false)
            : base(Panel, Preview)
        {
            this.AdminContent = requireAdminContent;
            this.InitializeComponent();
            this.ProposalContentController = new LibraryManager.Core.ProposalContentController(this.AdminContent);
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.PBProduct.Image = new Bitmap(dialog.FileName);
                this.PBProduct.ImageLocation = dialog.FileName;
                this.BtnRemoveImage.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.ClosePartialView();
        }

        private void BtnRemoveImage_Click(object sender, EventArgs e)
        {
            this.PBProduct.Image = null;
            this.BtnRemoveImage.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool flag = this.RequiredFieldEmpty(this.TxbPartNumber);
            bool flag2 = this.RequiredFieldEmpty(this.TxbManufacturer);
            bool flag3 = this.RequiredFieldEmpty(this.TxbPDescription);
            try
            {
                if (!flag && !flag2 && !flag3)
                {
                    //if all of the fields are empty
                    if (String.IsNullOrEmpty(this.TxbPBenefits.Text) && String.IsNullOrEmpty(this.TxbPOverview.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("This product will not be included in proposal content if it doesn't have either the Product Benefits or Product Overview.  Would you like to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SaveProposalContent();
                        }
                    }
                    else
                    {
                        SaveProposalContent();
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void SaveProposalContent() 
        {
            string text = this.TxbPartNumber.Text;
            string imageLocation = this.PBProduct.ImageLocation;
            LibraryManager.Models.ProposalContent proposalContent = null;
            byte[] image = null;
            if (!string.IsNullOrEmpty(imageLocation)) 
            {
                //get bytes from image to save them into the database
                image = Utilitary.GetBytesFromImage(imageLocation);
            }
            proposalContent = new LibraryManager.Models.ProposalContent
            {
                PartNumber = text,
                VendorName = this.TxbManufacturer.Text,
                ProductName = this.TxbPDescription.Text,
                FeatureBullets = this.TxbPBenefits.Rtf,
                MarketingInfo = this.TxbPOverview.Rtf,
                TechnicalInfo = this.TxbPDetails.Rtf,
                ProductPicturePath = string.IsNullOrEmpty(imageLocation) ? "" : imageLocation,
                ProductPicture = image
            };
            if (!this.NewProposalContent)
            {
                this.ProposalContentController.Update(proposalContent);
                base.CloseCurrentView();
            }
            else if (this.ProposalContentController.Get(text) != null)
            {
                MessageBox.Show("The product part number is a duplicate and therefore, not valid.", "Product part already exist", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.ProposalContentController.Save(proposalContent);
                base.CloseCurrentView();
            }
        }

        private void CallNewEditorRTF(string txtOpenName, int documentPartEdit, string rtf)
        {
            ProposalContent_Editor newView = new ProposalContent_Editor(base.MainPanel, this);
            newView.SetTxbOpenName(txtOpenName);
            this.DocumentPartEdit = documentPartEdit;
            newView.SetRTFString(rtf);
            base.OpenPartialView(newView);
        }

        private void CleanUpTextBox(TextBox Textbox)
        {
            Textbox.BackColor = Color.White;
            this.errorProvider1.SetError(Textbox, "");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillForm(LibraryManager.Models.ProposalContent proposalContent)
        {
            if (proposalContent != null)
            {
                this.TxbPartNumber.Text = proposalContent.PartNumber;
                this.TxbManufacturer.Text = proposalContent.VendorName;
                this.TxbPDescription.Text = proposalContent.ProductName;
                if (!string.IsNullOrEmpty(proposalContent.ProductPicturePath))
                {
                    if (File.Exists(proposalContent.ProductPicturePath)) 
                    {
                        this.PBProduct.Image = new Bitmap(proposalContent.ProductPicturePath);
                        this.PBProduct.ImageLocation = proposalContent.ProductPicturePath;
                        this.BtnRemoveImage.Enabled = true;
                    }
                }
                else if (proposalContent.ProductPicture != null)
                {
                    this.PBProduct.Image = Utilitary.ByteToImage(proposalContent.ProductPicture);
                }
                try
                {
                    this.TxbPBenefits.Rtf = proposalContent.FeatureBullets;
                    this.TxbPOverview.Rtf = proposalContent.MarketingInfo;
                    this.TxbPDetails.Rtf = proposalContent.TechnicalInfo;
                    float emSize = 9f;
                    this.TxbPBenefits.Font = new Font("", emSize);
                    this.TxbPOverview.Font = new Font("", emSize);
                    this.TxbPDetails.Font = new Font("", emSize);
                }
                catch (Exception)
                {
                }
            }
        }


        private void ProposalContent_Add_Edit_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.PartNumber))
            {
                this.NewProposalContent = true;
                this.TxbPartNumber.ReadOnly = false;
                this.TxbPartNumber.Enabled = true;
            }
            else
            {
                this.NewProposalContent = false;
                this.TxbPartNumber.ReadOnly = true;
                this.TxbPartNumber.Enabled = false;
                LibraryManager.Models.ProposalContent proposalContent = this.ProposalContentController.Get(this.PartNumber);
                this.FillForm(proposalContent);
            }
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

        public void SetPartNumber(string partNumber)
        {
            this.PartNumber = partNumber;
        }

        public override void SetRTFText(string RTF)
        {
            switch (this.DocumentPartEdit)
            {
                case 1:
                    this.TxbPBenefits.Rtf = RTF;
                    return;

                case 2:
                    this.TxbPOverview.Rtf = RTF;
                    return;

                case 3:
                    this.TxbPDetails.Rtf = RTF;
                    return;
            }
        }

        private void TxbManufacturer_Enter(object sender, EventArgs e)
        {
            this.CleanUpTextBox(this.TxbManufacturer);
        }

        private void TxbPartNumber_Enter(object sender, EventArgs e)
        {
            this.CleanUpTextBox(this.TxbPartNumber);
        }

        private void TxbPBenefits_Enter(object sender, EventArgs e)
        {
            this.CallNewEditorRTF("Product Benefits", 1, this.TxbPBenefits.Rtf);
        }

        private void TxbPDescription_Enter(object sender, EventArgs e)
        {
            this.CleanUpTextBox(this.TxbPDescription);
        }

        private void TxbPDetails_Click(object sender, EventArgs e)
        {
            this.CallNewEditorRTF("Product Details", 3, this.TxbPDetails.Rtf);
        }

        private void TxbPDetails_Enter(object sender, EventArgs e)
        {
            this.CallNewEditorRTF("Product Details", 3, this.TxbPDetails.Rtf);
        }

        private void TxbPOverview_Click(object sender, EventArgs e)
        {
            this.CallNewEditorRTF("Product Overview", 2, this.TxbPOverview.Rtf);
        }

        private void TxbPOverview_Enter(object sender, EventArgs e)
        {
            this.CallNewEditorRTF("Product Overview", 2, this.TxbPOverview.Rtf);
        }

        private void TxbPartNumber_TextChanged(object sender, EventArgs e)
        {
            if (TxbPartNumber.Text.Contains("dd"))
            {
                var testing = "";
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnAddImage = new System.Windows.Forms.Button();
            this.TxbPBenefits = new System.Windows.Forms.RichTextBox();
            this.TxbPOverview = new System.Windows.Forms.RichTextBox();
            this.TxbPDetails = new System.Windows.Forms.RichTextBox();
            this.BtnRemoveImage = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxbPDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PBProduct = new System.Windows.Forms.PictureBox();
            this.TxbManufacturer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PBProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAddImage
            // 
            this.BtnAddImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddImage.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.BtnAddImage.ForeColor = System.Drawing.Color.White;
            this.BtnAddImage.Location = new System.Drawing.Point(575, 194);
            this.BtnAddImage.Name = "BtnAddImage";
            this.BtnAddImage.Size = new System.Drawing.Size(69, 25);
            this.BtnAddImage.TabIndex = 44;
            this.BtnAddImage.Text = "Add";
            this.BtnAddImage.UseVisualStyleBackColor = false;
            this.BtnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // TxbPBenefits
            // 
            this.TxbPBenefits.BackColor = System.Drawing.Color.White;
            this.TxbPBenefits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxbPBenefits.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.TxbPBenefits.Location = new System.Drawing.Point(16, 185);
            this.TxbPBenefits.Name = "TxbPBenefits";
            this.TxbPBenefits.ReadOnly = true;
            this.TxbPBenefits.Size = new System.Drawing.Size(545, 90);
            this.TxbPBenefits.TabIndex = 32;
            this.TxbPBenefits.Text = "";
            this.TxbPBenefits.Enter += new System.EventHandler(this.TxbPBenefits_Enter);
            // 
            // TxbPOverview
            // 
            this.TxbPOverview.BackColor = System.Drawing.Color.White;
            this.TxbPOverview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxbPOverview.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.TxbPOverview.Location = new System.Drawing.Point(18, 305);
            this.TxbPOverview.Name = "TxbPOverview";
            this.TxbPOverview.ReadOnly = true;
            this.TxbPOverview.Size = new System.Drawing.Size(539, 90);
            this.TxbPOverview.TabIndex = 34;
            this.TxbPOverview.Text = "";
            this.TxbPOverview.Click += new System.EventHandler(this.TxbPOverview_Click);
            this.TxbPOverview.Enter += new System.EventHandler(this.TxbPOverview_Enter);
            // 
            // TxbPDetails
            // 
            this.TxbPDetails.BackColor = System.Drawing.Color.White;
            this.TxbPDetails.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.TxbPDetails.Location = new System.Drawing.Point(18, 428);
            this.TxbPDetails.Name = "TxbPDetails";
            this.TxbPDetails.ReadOnly = true;
            this.TxbPDetails.Size = new System.Drawing.Size(539, 90);
            this.TxbPDetails.TabIndex = 36;
            this.TxbPDetails.Text = "";
            this.TxbPDetails.Click += new System.EventHandler(this.TxbPDetails_Click);
            this.TxbPDetails.Enter += new System.EventHandler(this.TxbPDetails_Enter);
            // 
            // BtnRemoveImage
            // 
            this.BtnRemoveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemoveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.BtnRemoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemoveImage.Enabled = false;
            this.BtnRemoveImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BtnRemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveImage.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.BtnRemoveImage.ForeColor = System.Drawing.Color.White;
            this.BtnRemoveImage.Location = new System.Drawing.Point(649, 194);
            this.BtnRemoveImage.Name = "BtnRemoveImage";
            this.BtnRemoveImage.Size = new System.Drawing.Size(69, 25);
            this.BtnRemoveImage.TabIndex = 40;
            this.BtnRemoveImage.Text = "Remove";
            this.BtnRemoveImage.UseVisualStyleBackColor = false;
            this.BtnRemoveImage.Click += new System.EventHandler(this.BtnRemoveImage_Click);
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
            this.BtnCancel.Location = new System.Drawing.Point(530, 536);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(90, 32);
            this.BtnCancel.TabIndex = 42;
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
            this.BtnSave.Location = new System.Drawing.Point(626, 536);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(90, 32);
            this.BtnSave.TabIndex = 40;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label8.Location = new System.Drawing.Point(17, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Product Features:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.Location = new System.Drawing.Point(15, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Product Overview:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label5.Location = new System.Drawing.Point(15, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Product Benefits:";
            // 
            // TxbPDescription
            // 
            this.TxbPDescription.BackColor = System.Drawing.Color.White;
            this.TxbPDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.TxbPDescription.Location = new System.Drawing.Point(16, 128);
            this.TxbPDescription.Name = "TxbPDescription";
            this.TxbPDescription.Size = new System.Drawing.Size(545, 29);
            this.TxbPDescription.TabIndex = 30;
            this.TxbPDescription.Enter += new System.EventHandler(this.TxbPDescription_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label4.Location = new System.Drawing.Point(15, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Product Description (Name):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label3.Location = new System.Drawing.Point(575, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Picture:";
            // 
            // PBProduct
            // 
            this.PBProduct.BackColor = System.Drawing.Color.Transparent;
            this.PBProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBProduct.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PBProduct.Location = new System.Drawing.Point(578, 61);
            this.PBProduct.Name = "PBProduct";
            this.PBProduct.Size = new System.Drawing.Size(140, 130);
            this.PBProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBProduct.TabIndex = 27;
            this.PBProduct.TabStop = false;
            // 
            // TxbManufacturer
            // 
            this.TxbManufacturer.BackColor = System.Drawing.Color.White;
            this.TxbManufacturer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.TxbManufacturer.Location = new System.Drawing.Point(301, 70);
            this.TxbManufacturer.MaxLength = 500;
            this.TxbManufacturer.Name = "TxbManufacturer";
            this.TxbManufacturer.Size = new System.Drawing.Size(260, 29);
            this.TxbManufacturer.TabIndex = 26;
            this.TxbManufacturer.Enter += new System.EventHandler(this.TxbManufacturer_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(298, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Manufacturer:";
            // 
            // TxbPartNumber
            // 
            this.TxbPartNumber.BackColor = System.Drawing.Color.White;
            this.TxbPartNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.TxbPartNumber.Location = new System.Drawing.Point(16, 70);
            this.TxbPartNumber.MaxLength = 254;
            this.TxbPartNumber.Name = "TxbPartNumber";
            this.TxbPartNumber.Size = new System.Drawing.Size(260, 29);
            this.TxbPartNumber.TabIndex = 24;
            this.TxbPartNumber.TextChanged += new System.EventHandler(this.TxbPartNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Part Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(502, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Library Manager > Structured Proposal Content for Products > Add/Edit";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 100;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ProposalContent_Add_Edit
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.BtnAddImage);
            this.Controls.Add(this.TxbPBenefits);
            this.Controls.Add(this.TxbPOverview);
            this.Controls.Add(this.TxbPDetails);
            this.Controls.Add(this.BtnRemoveImage);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxbPDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PBProduct);
            this.Controls.Add(this.TxbManufacturer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxbPartNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProposalContent_Add_Edit";
            this.Text = "ProposalContent_Add_Edit";
            this.Load += new System.EventHandler(this.ProposalContent_Add_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}

