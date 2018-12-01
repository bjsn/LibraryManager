namespace LibraryManager.Views
{
    using LibraryManager.Core;
    using LibraryManager.Models;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ProposalContent_Add_Edit : BasePartialView
    {
        private LibraryManager.Core.ProposalContentController ProposalContentController;
        private string PartNumber;
        private int DocumentPartEdit;
        private bool NewProposalContent;
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

        public ProposalContent_Add_Edit(Panel Panel, BasePartialView Preview = null) : base(Panel, Preview)
        {
            this.InitializeComponent();
            this.ProposalContentController = new LibraryManager.Core.ProposalContentController();
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
                if ((!flag && !flag2) && !flag3)
                {
                    string text = this.TxbPartNumber.Text;
                    string imageLocation = this.PBProduct.ImageLocation;
                    LibraryManager.Models.ProposalContent proposalContent = null;
                    proposalContent = new LibraryManager.Models.ProposalContent {
                        PartNumber = text,
                        VendorName = this.TxbManufacturer.Text,
                        ProductName = this.TxbPDescription.Text,
                        FeatureBullets = this.TxbPBenefits.Rtf,
                        MarketingInfo = this.TxbPOverview.Rtf,
                        TechnicalInfo = this.TxbPDetails.Rtf,
                        ProductPicturePath = string.IsNullOrEmpty(imageLocation) ? "" : imageLocation
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
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    this.PBProduct.Image = new Bitmap(proposalContent.ProductPicturePath);
                    this.PBProduct.ImageLocation = proposalContent.ProductPicturePath;
                    this.BtnRemoveImage.Enabled = true;
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

        private void InitializeComponent()
        {
            this.components = new Container();
            this.BtnAddImage = new Button();
            this.TxbPBenefits = new RichTextBox();
            this.TxbPOverview = new RichTextBox();
            this.TxbPDetails = new RichTextBox();
            this.BtnRemoveImage = new Button();
            this.BtnCancel = new Button();
            this.BtnSave = new Button();
            this.label8 = new Label();
            this.label7 = new Label();
            this.label5 = new Label();
            this.TxbPDescription = new TextBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.PBProduct = new PictureBox();
            this.TxbManufacturer = new TextBox();
            this.label2 = new Label();
            this.TxbPartNumber = new TextBox();
            this.label1 = new Label();
            this.label6 = new Label();
            this.errorProvider1 = new ErrorProvider(this.components);
            ((ISupportInitialize) this.PBProduct).BeginInit();
            ((ISupportInitialize) this.errorProvider1).BeginInit();
            base.SuspendLayout();
            this.BtnAddImage.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnAddImage.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnAddImage.Cursor = Cursors.Hand;
            this.BtnAddImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            this.BtnAddImage.FlatStyle = FlatStyle.Flat;
            this.BtnAddImage.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
            this.BtnAddImage.ForeColor = Color.White;
            this.BtnAddImage.Location = new Point(0x23f, 0xc2);
            this.BtnAddImage.Name = "BtnAddImage";
            this.BtnAddImage.Size = new Size(0x45, 0x19);
            this.BtnAddImage.TabIndex = 0x2c;
            this.BtnAddImage.Text = "Add";
            this.BtnAddImage.UseVisualStyleBackColor = false;
            this.BtnAddImage.Click += new EventHandler(this.BtnAddImage_Click);
            this.TxbPBenefits.BackColor = Color.White;
            this.TxbPBenefits.BorderStyle = BorderStyle.FixedSingle;
            this.TxbPBenefits.Font = new Font("Segoe UI", 7f);
            this.TxbPBenefits.Location = new Point(0x10, 0xb9);
            this.TxbPBenefits.Name = "TxbPBenefits";
            this.TxbPBenefits.ReadOnly = true;
            this.TxbPBenefits.Size = new Size(0x221, 90);
            this.TxbPBenefits.TabIndex = 0x20;
            this.TxbPBenefits.Text = "";
            this.TxbPBenefits.Click += new EventHandler(this.TxbPBenefits_Click);
            this.TxbPBenefits.Enter += new EventHandler(this.TxbPBenefits_Enter);
            this.TxbPOverview.BackColor = Color.White;
            this.TxbPOverview.BorderStyle = BorderStyle.FixedSingle;
            this.TxbPOverview.Font = new Font("Segoe UI", 7f);
            this.TxbPOverview.Location = new Point(0x12, 0x131);
            this.TxbPOverview.Name = "TxbPOverview";
            this.TxbPOverview.ReadOnly = true;
            this.TxbPOverview.Size = new Size(0x21b, 90);
            this.TxbPOverview.TabIndex = 0x22;
            this.TxbPOverview.Text = "";
            this.TxbPOverview.Click += new EventHandler(this.TxbPOverview_Click);
            this.TxbPOverview.Enter += new EventHandler(this.TxbPOverview_Enter);
            this.TxbPDetails.BackColor = Color.White;
            this.TxbPDetails.Font = new Font("Segoe UI", 7f);
            this.TxbPDetails.Location = new Point(0x12, 0x1ac);
            this.TxbPDetails.Name = "TxbPDetails";
            this.TxbPDetails.ReadOnly = true;
            this.TxbPDetails.Size = new Size(0x21b, 90);
            this.TxbPDetails.TabIndex = 0x24;
            this.TxbPDetails.Text = "";
            this.TxbPDetails.Click += new EventHandler(this.TxbPDetails_Click);
            this.TxbPDetails.Enter += new EventHandler(this.TxbPDetails_Enter);
            this.BtnRemoveImage.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnRemoveImage.BackColor = Color.FromArgb(0xfe, 0x35, 0x47);
            this.BtnRemoveImage.Cursor = Cursors.Hand;
            this.BtnRemoveImage.Enabled = false;
            this.BtnRemoveImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(0xe5, 0x2d, 0x2d);
            this.BtnRemoveImage.FlatStyle = FlatStyle.Flat;
            this.BtnRemoveImage.Font = new Font("Segoe UI", 7f, FontStyle.Bold);
            this.BtnRemoveImage.ForeColor = Color.White;
            this.BtnRemoveImage.Location = new Point(0x289, 0xc2);
            this.BtnRemoveImage.Name = "BtnRemoveImage";
            this.BtnRemoveImage.Size = new Size(0x45, 0x19);
            this.BtnRemoveImage.TabIndex = 40;
            this.BtnRemoveImage.Text = "Remove";
            this.BtnRemoveImage.UseVisualStyleBackColor = false;
            this.BtnRemoveImage.Click += new EventHandler(this.BtnRemoveImage_Click);
            this.BtnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnCancel.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnCancel.Cursor = Cursors.Hand;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            this.BtnCancel.FlatStyle = FlatStyle.Flat;
            this.BtnCancel.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnCancel.ForeColor = Color.White;
            this.BtnCancel.Location = new Point(530, 0x218);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new Size(90, 0x20);
            this.BtnCancel.TabIndex = 0x2a;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new EventHandler(this.BtnCancel_Click);
            this.BtnSave.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.BtnSave.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.BtnSave.Cursor = Cursors.Hand;
            this.BtnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            this.BtnSave.FlatStyle = FlatStyle.Flat;
            this.BtnSave.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
            this.BtnSave.ForeColor = Color.White;
            this.BtnSave.Location = new Point(0x272, 0x218);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new Size(90, 0x20);
            this.BtnSave.TabIndex = 40;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
            this.label8.AutoSize = true;
            this.label8.FlatStyle = FlatStyle.Flat;
            this.label8.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label8.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label8.Location = new Point(0x11, 410);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x5b, 15);
            this.label8.TabIndex = 0x23;
            this.label8.Text = "Product Details:";
            this.label7.AutoSize = true;
            this.label7.FlatStyle = FlatStyle.Flat;
            this.label7.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label7.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label7.Location = new Point(15, 0x11f);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x68, 15);
            this.label7.TabIndex = 0x21;
            this.label7.Text = "Product Overview:";
            this.label5.AutoSize = true;
            this.label5.FlatStyle = FlatStyle.Flat;
            this.label5.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label5.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label5.Location = new Point(15, 0xa7);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x61, 15);
            this.label5.TabIndex = 0x1f;
            this.label5.Text = "Product Benefits:";
            this.TxbPDescription.BackColor = Color.White;
            this.TxbPDescription.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            this.TxbPDescription.ImeMode = ImeMode.Katakana;
            this.TxbPDescription.Location = new Point(0x10, 0x80);
            this.TxbPDescription.Name = "TxbPDescription";
            this.TxbPDescription.Size = new Size(0x221, 0x18);
            this.TxbPDescription.TabIndex = 30;
            this.TxbPDescription.Enter += new EventHandler(this.TxbPDescription_Enter);
            this.label4.AutoSize = true;
            this.label4.FlatStyle = FlatStyle.Flat;
            this.label4.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label4.Location = new Point(15, 110);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x9f, 15);
            this.label4.TabIndex = 0x1d;
            this.label4.Text = "Product Description (Name):";
            this.label3.AutoSize = true;
            this.label3.FlatStyle = FlatStyle.Flat;
            this.label3.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label3.Location = new Point(0x23f, 0x2b);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x2f, 15);
            this.label3.TabIndex = 0x1c;
            this.label3.Text = "Picture:";
            this.PBProduct.BackColor = Color.Transparent;
            this.PBProduct.BorderStyle = BorderStyle.FixedSingle;
            this.PBProduct.Cursor = Cursors.Arrow;
            this.PBProduct.Location = new Point(0x242, 0x3d);
            this.PBProduct.Name = "PBProduct";
            this.PBProduct.Size = new Size(140, 130);
            this.PBProduct.SizeMode = PictureBoxSizeMode.Zoom;
            this.PBProduct.TabIndex = 0x1b;
            this.PBProduct.TabStop = false;
            this.TxbManufacturer.BackColor = Color.White;
            this.TxbManufacturer.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            this.TxbManufacturer.ImeMode = ImeMode.Katakana;
            this.TxbManufacturer.Location = new Point(0x12d, 70);
            this.TxbManufacturer.MaxLength = 500;
            this.TxbManufacturer.Name = "TxbManufacturer";
            this.TxbManufacturer.Size = new Size(260, 0x18);
            this.TxbManufacturer.TabIndex = 0x1a;
            this.TxbManufacturer.Enter += new EventHandler(this.TxbManufacturer_Enter);
            this.label2.AutoSize = true;
            this.label2.FlatStyle = FlatStyle.Flat;
            this.label2.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label2.Location = new Point(0x12a, 0x34);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x52, 15);
            this.label2.TabIndex = 0x19;
            this.label2.Text = "Manufacturer:";
            this.TxbPartNumber.BackColor = Color.White;
            this.TxbPartNumber.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            this.TxbPartNumber.ImeMode = ImeMode.Katakana;
            this.TxbPartNumber.Location = new Point(0x10, 70);
            this.TxbPartNumber.MaxLength = 0xfe;
            this.TxbPartNumber.Name = "TxbPartNumber";
            this.TxbPartNumber.Size = new Size(260, 0x18);
            this.TxbPartNumber.TabIndex = 0x18;
            this.TxbPartNumber.Enter += new EventHandler(this.TxbPartNumber_Enter);
            this.label1.AutoSize = true;
            this.label1.FlatStyle = FlatStyle.Flat;
            this.label1.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label1.Location = new Point(15, 0x33);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4e, 15);
            this.label1.TabIndex = 0x17;
            this.label1.Text = "Part Number:";
            this.label6.AutoSize = true;
            this.label6.FlatStyle = FlatStyle.Flat;
            this.label6.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label6.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label6.Location = new Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x182, 15);
            this.label6.TabIndex = 0x11;
            this.label6.Text = "Library Manager > Structured Proposal Content for Products > Add/Edit";
            this.errorProvider1.BlinkRate = 100;
            this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            base.ClientSize = new Size(730, 580);
            base.Controls.Add(this.BtnAddImage);
            base.Controls.Add(this.TxbPBenefits);
            base.Controls.Add(this.TxbPOverview);
            base.Controls.Add(this.TxbPDetails);
            base.Controls.Add(this.BtnRemoveImage);
            base.Controls.Add(this.BtnCancel);
            base.Controls.Add(this.BtnSave);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.TxbPDescription);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.PBProduct);
            base.Controls.Add(this.TxbManufacturer);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.TxbPartNumber);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label6);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "ProposalContent_Add_Edit";
            this.Text = "ProposalContent_Add_Edit";
            base.Load += new EventHandler(this.ProposalContent_Add_Edit_Load);
            ((ISupportInitialize) this.PBProduct).EndInit();
            ((ISupportInitialize) this.errorProvider1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
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

        private void TxbPBenefits_Click(object sender, EventArgs e)
        {
            this.CallNewEditorRTF("Product Benefits", 1, this.TxbPBenefits.Rtf);
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
    }
}

