namespace LibraryManager
{
    using LibrMgr.Properties;
    using AddEditProposalContent.Views;
    using AddEditProposalContent.Views.DocTemplates;
    using AddEditProposalContent.Views.ItemCats;
    using AddEditProposalContent.Views.OutputTypes;
    using AddEditProposalContent.Views.SectionTypes;
    using LibraryManager.Views;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class Navbar : BasePartialView
    {
        private IContainer components;
        private Panel Pnl_OutputTypes;
        private Label lblOutputTypes;
        private PictureBox pictureBox8;
        private Panel Pnl_StructuredProposal;
        private PictureBox pictureBox3;
        private Label lblStructuredProposal;
        private Label label4lblStructuredProposal2;
        private Panel Pnl_DocTemplates;
        private Label lblDocTemplates;
        private PictureBox pictureBox4;
        private Panel Pnl_ItemCats;
        private PictureBox pictureBox6;
        private Label lblDocItemCats;
        private Panel Pnl_DocSections;
        private PictureBox pictureBox5;
        private Label lblDocSections;
        private Label lblTypeAssociations;
        private Panel Pnl_SectionTypes;
        private PictureBox pictureBox7;
        private Label lblDocSectionTypes;
        private Label label5;
        private Label lblLibraryManager;
        private PictureBox pictureBox1;

        public Navbar(Panel panel) : base(panel)
        {
            base.MainPanel = panel;
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LockElements() 
        {
            //implement logic
        }

        private void Navbar_Load(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new DocSection(base.MainPanel);
            this.SelectOption(this.Pnl_DocSections, proposalContentView);
        }

        #region Menu Elements Events
        private void Pnl_StructuredProposal_Click(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new ProposalContent(base.MainPanel, true);
            this.SelectOption(this.Pnl_StructuredProposal, proposalContentView);
        }

        private void Pnl_DocTemplates_Click(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new DocTemplate(base.MainPanel);
            this.SelectOption(this.Pnl_DocTemplates, proposalContentView);
        }

        private void Pnl_DocSections_Click(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new DocSection(base.MainPanel);
            this.SelectOption(this.Pnl_DocSections, proposalContentView);
        }

        private void Pnl_OutputTypes_Click(object sender, EventArgs e)
        {
            OutputType outputType  = new OutputType(base.MainPanel);
            this.SelectOption(this.Pnl_OutputTypes, outputType);
        }

        private void Pnl_SectionTypes_Click(object sender, EventArgs e)
        {
            DocSectionType docSectionType = new DocSectionType(base.MainPanel);
            this.SelectOption(this.Pnl_SectionTypes, docSectionType);
        }

        private void Pnl_ItemCats_Click(object sender, EventArgs e)
        {
            ItemCategory itemCategory = new ItemCategory(base.MainPanel);
            this.SelectOption(this.Pnl_ItemCats, itemCategory);
        }
        #endregion


        private void SelectOption(Panel panel, BasePartialView proposalContentView = null)
        {
            if (panel.BackColor != Color.FromArgb(20,20,20))
            {
                base.MainPanel.Controls.Clear();
                if (proposalContentView != null)
                {
                    proposalContentView.TopLevel = false;
                    proposalContentView.AutoScroll = false;
                    proposalContentView.Location = new Point(0, 0);
                    base.MainPanel.Controls.Add(proposalContentView);
                    proposalContentView.Show();
                }
            }

            foreach (Control control in base.Controls)
            {
                if (!(control is Panel))
                {
                    continue;
                }

                if (!control.Name.Equals("Pnl_LibrayManager") && !control.Name.Equals("Pnl_TypesAssociations"))
                {
                    control.BackColor = Color.FromArgb(22, 22, 22);
                    IEnumerator enumerator = control.Controls.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Control current = (Control)enumerator.Current;
                            if (current is Panel)
                            {
                                control.Controls.Remove(current);
                            }
                        }
                    }
                    finally
                    {
                        //IDisposable disposable = enumerator as IDisposable;
                        //if (disposable == null)
                        //{
                        //    continue;
                        //}
                        //disposable.Dispose();
                    }
                }
            }

            Panel panel2 = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(10, 40),
                MaximumSize = new Size(6, 40),
                BackColor = Color.FromArgb(0, 0x72, 0xc6)
            };
            //panel.Controls.Add(panel2);
            //panel.BackColor = Color.FromArgb(45, 45, 45);
            panel.BackColor = Color.FromArgb(0, 114, 198);
        }

        private void AddHoverToPanel(Panel panel) 
        {
            if (panel.BackColor != Color.FromArgb(0, 114, 198))
            {
                panel.BackColor = Color.FromArgb(41,41,41);
            }
        }

        private void RemoveHoverFromPanel(Panel panel) 
        {
            if (panel.BackColor != Color.FromArgb(0, 114, 198))
            {
                panel.BackColor = Color.Transparent;
            }
        }

        private void Pnl_DocSections_MouseEnter(object sender, EventArgs e)
        {
            AddHoverToPanel(this.Pnl_DocSections);
        }

        private void Pnl_DocSections_MouseLeave(object sender, EventArgs e)
        {
            RemoveHoverFromPanel(this.Pnl_DocSections);
        }

        private void Pnl_DocTemplates_MouseEnter(object sender, EventArgs e)
        {
            AddHoverToPanel(this.Pnl_DocTemplates);
        }

        private void Pnl_DocTemplates_MouseLeave(object sender, EventArgs e)
        {
            RemoveHoverFromPanel(this.Pnl_DocTemplates);
        }

        private void Pnl_StructuredProposal_MouseEnter(object sender, EventArgs e)
        {
            AddHoverToPanel(this.Pnl_StructuredProposal);
        }

        private void Pnl_StructuredProposal_MouseLeave(object sender, EventArgs e)
        {
            RemoveHoverFromPanel(this.Pnl_StructuredProposal);
        }

        private void Pnl_OutputTypes_MouseEnter(object sender, EventArgs e)
        {
            AddHoverToPanel(this.Pnl_OutputTypes);
        }

        private void Pnl_OutputTypes_MouseLeave(object sender, EventArgs e)
        {
            RemoveHoverFromPanel(this.Pnl_OutputTypes);
        }

        private void Pnl_SectionTypes_MouseEnter(object sender, EventArgs e)
        {
            AddHoverToPanel(this.Pnl_SectionTypes);
        }

        private void Pnl_SectionTypes_MouseLeave(object sender, EventArgs e)
        {
            RemoveHoverFromPanel(this.Pnl_SectionTypes);
        }

        private void Pnl_ItemCats_MouseEnter(object sender, EventArgs e)
        {
            AddHoverToPanel(this.Pnl_ItemCats);
        }

        private void Pnl_ItemCats_MouseLeave(object sender, EventArgs e)
        {
            RemoveHoverFromPanel(this.Pnl_ItemCats);
        }


        private void InitializeComponent()
        {
            this.Pnl_OutputTypes = new System.Windows.Forms.Panel();
            this.lblOutputTypes = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.Pnl_StructuredProposal = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblStructuredProposal = new System.Windows.Forms.Label();
            this.label4lblStructuredProposal2 = new System.Windows.Forms.Label();
            this.Pnl_DocTemplates = new System.Windows.Forms.Panel();
            this.lblDocTemplates = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Pnl_ItemCats = new System.Windows.Forms.Panel();
            this.lblDocItemCats = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Pnl_DocSections = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblDocSections = new System.Windows.Forms.Label();
            this.lblTypeAssociations = new System.Windows.Forms.Label();
            this.Pnl_SectionTypes = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblDocSectionTypes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLibraryManager = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pnl_OutputTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.Pnl_StructuredProposal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.Pnl_DocTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.Pnl_ItemCats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.Pnl_DocSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.Pnl_SectionTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_OutputTypes
            // 
            this.Pnl_OutputTypes.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_OutputTypes.Controls.Add(this.lblOutputTypes);
            this.Pnl_OutputTypes.Controls.Add(this.pictureBox8);
            this.Pnl_OutputTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_OutputTypes.Location = new System.Drawing.Point(0, 267);
            this.Pnl_OutputTypes.Name = "Pnl_OutputTypes";
            this.Pnl_OutputTypes.Size = new System.Drawing.Size(166, 35);
            this.Pnl_OutputTypes.TabIndex = 63;
            this.Pnl_OutputTypes.Click += new System.EventHandler(this.Pnl_OutputTypes_Click);
            this.Pnl_OutputTypes.MouseEnter += new System.EventHandler(this.Pnl_OutputTypes_MouseEnter);
            this.Pnl_OutputTypes.MouseLeave += new System.EventHandler(this.Pnl_OutputTypes_MouseLeave);
            // 
            // lblOutputTypes
            // 
            this.lblOutputTypes.AutoSize = true;
            this.lblOutputTypes.BackColor = System.Drawing.Color.Transparent;
            this.lblOutputTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOutputTypes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOutputTypes.ForeColor = System.Drawing.Color.White;
            this.lblOutputTypes.Location = new System.Drawing.Point(33, 7);
            this.lblOutputTypes.Name = "lblOutputTypes";
            this.lblOutputTypes.Size = new System.Drawing.Size(102, 21);
            this.lblOutputTypes.TabIndex = 1;
            this.lblOutputTypes.Text = "Output Types";
            this.lblOutputTypes.Click += new System.EventHandler(this.Pnl_OutputTypes_Click);
            this.lblOutputTypes.MouseEnter += new System.EventHandler(this.Pnl_OutputTypes_MouseEnter);
            this.lblOutputTypes.MouseLeave += new System.EventHandler(this.Pnl_OutputTypes_MouseLeave);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox8.Enabled = false;
            this.pictureBox8.Image = global::LibrMgr.Properties.Resources.list1;
            this.pictureBox8.Location = new System.Drawing.Point(14, 9);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(16, 16);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            // 
            // Pnl_StructuredProposal
            // 
            this.Pnl_StructuredProposal.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_StructuredProposal.Controls.Add(this.pictureBox3);
            this.Pnl_StructuredProposal.Controls.Add(this.lblStructuredProposal);
            this.Pnl_StructuredProposal.Controls.Add(this.label4lblStructuredProposal2);
            this.Pnl_StructuredProposal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_StructuredProposal.Location = new System.Drawing.Point(0, 180);
            this.Pnl_StructuredProposal.Name = "Pnl_StructuredProposal";
            this.Pnl_StructuredProposal.Size = new System.Drawing.Size(166, 40);
            this.Pnl_StructuredProposal.TabIndex = 59;
            this.Pnl_StructuredProposal.Click += new System.EventHandler(this.Pnl_StructuredProposal_Click);
            this.Pnl_StructuredProposal.MouseEnter += new System.EventHandler(this.Pnl_StructuredProposal_MouseEnter);
            this.Pnl_StructuredProposal.MouseLeave += new System.EventHandler(this.Pnl_StructuredProposal_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Image = global::LibrMgr.Properties.Resources.content;
            this.pictureBox3.Location = new System.Drawing.Point(15, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // lblStructuredProposal
            // 
            this.lblStructuredProposal.AutoSize = true;
            this.lblStructuredProposal.BackColor = System.Drawing.Color.Transparent;
            this.lblStructuredProposal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStructuredProposal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStructuredProposal.ForeColor = System.Drawing.Color.White;
            this.lblStructuredProposal.Location = new System.Drawing.Point(34, 1);
            this.lblStructuredProposal.Name = "lblStructuredProposal";
            this.lblStructuredProposal.Size = new System.Drawing.Size(147, 21);
            this.lblStructuredProposal.TabIndex = 1;
            this.lblStructuredProposal.Text = "Structured Proposal";
            this.lblStructuredProposal.Click += new System.EventHandler(this.Pnl_StructuredProposal_Click);
            this.lblStructuredProposal.MouseEnter += new System.EventHandler(this.Pnl_StructuredProposal_MouseEnter);
            this.lblStructuredProposal.MouseLeave += new System.EventHandler(this.Pnl_StructuredProposal_MouseLeave);
            // 
            // label4lblStructuredProposal2
            // 
            this.label4lblStructuredProposal2.AutoSize = true;
            this.label4lblStructuredProposal2.BackColor = System.Drawing.Color.Transparent;
            this.label4lblStructuredProposal2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4lblStructuredProposal2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4lblStructuredProposal2.ForeColor = System.Drawing.Color.White;
            this.label4lblStructuredProposal2.Location = new System.Drawing.Point(34, 19);
            this.label4lblStructuredProposal2.Name = "label4lblStructuredProposal2";
            this.label4lblStructuredProposal2.Size = new System.Drawing.Size(154, 21);
            this.label4lblStructuredProposal2.TabIndex = 2;
            this.label4lblStructuredProposal2.Text = "Content for Products";
            this.label4lblStructuredProposal2.Click += new System.EventHandler(this.Pnl_StructuredProposal_Click);
            this.label4lblStructuredProposal2.MouseEnter += new System.EventHandler(this.Pnl_StructuredProposal_MouseEnter);
            this.label4lblStructuredProposal2.MouseLeave += new System.EventHandler(this.Pnl_StructuredProposal_MouseLeave);
            // 
            // Pnl_DocTemplates
            // 
            this.Pnl_DocTemplates.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_DocTemplates.Controls.Add(this.lblDocTemplates);
            this.Pnl_DocTemplates.Controls.Add(this.pictureBox4);
            this.Pnl_DocTemplates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_DocTemplates.Location = new System.Drawing.Point(0, 145);
            this.Pnl_DocTemplates.Name = "Pnl_DocTemplates";
            this.Pnl_DocTemplates.Size = new System.Drawing.Size(166, 35);
            this.Pnl_DocTemplates.TabIndex = 61;
            this.Pnl_DocTemplates.Click += new System.EventHandler(this.Pnl_DocTemplates_Click);
            this.Pnl_DocTemplates.MouseEnter += new System.EventHandler(this.Pnl_DocTemplates_MouseEnter);
            this.Pnl_DocTemplates.MouseLeave += new System.EventHandler(this.Pnl_DocTemplates_MouseLeave);
            // 
            // lblDocTemplates
            // 
            this.lblDocTemplates.AutoSize = true;
            this.lblDocTemplates.BackColor = System.Drawing.Color.Transparent;
            this.lblDocTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDocTemplates.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocTemplates.ForeColor = System.Drawing.Color.White;
            this.lblDocTemplates.Location = new System.Drawing.Point(34, 7);
            this.lblDocTemplates.Name = "lblDocTemplates";
            this.lblDocTemplates.Size = new System.Drawing.Size(109, 21);
            this.lblDocTemplates.TabIndex = 1;
            this.lblDocTemplates.Text = "Doc templates";
            this.lblDocTemplates.Click += new System.EventHandler(this.Pnl_DocTemplates_Click);
            this.lblDocTemplates.MouseEnter += new System.EventHandler(this.Pnl_DocTemplates_MouseEnter);
            this.lblDocTemplates.MouseLeave += new System.EventHandler(this.Pnl_DocTemplates_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Image = global::LibrMgr.Properties.Resources.contract;
            this.pictureBox4.Location = new System.Drawing.Point(15, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // Pnl_ItemCats
            // 
            this.Pnl_ItemCats.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_ItemCats.Controls.Add(this.lblDocItemCats);
            this.Pnl_ItemCats.Controls.Add(this.pictureBox6);
            this.Pnl_ItemCats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_ItemCats.Location = new System.Drawing.Point(0, 337);
            this.Pnl_ItemCats.Name = "Pnl_ItemCats";
            this.Pnl_ItemCats.Size = new System.Drawing.Size(166, 35);
            this.Pnl_ItemCats.TabIndex = 64;
            this.Pnl_ItemCats.Click += new System.EventHandler(this.Pnl_ItemCats_Click);
            this.Pnl_ItemCats.MouseEnter += new System.EventHandler(this.Pnl_ItemCats_MouseEnter);
            this.Pnl_ItemCats.MouseLeave += new System.EventHandler(this.Pnl_ItemCats_MouseLeave);
            // 
            // lblDocItemCats
            // 
            this.lblDocItemCats.AutoSize = true;
            this.lblDocItemCats.BackColor = System.Drawing.Color.Transparent;
            this.lblDocItemCats.CausesValidation = false;
            this.lblDocItemCats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDocItemCats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocItemCats.ForeColor = System.Drawing.Color.White;
            this.lblDocItemCats.Location = new System.Drawing.Point(34, 7);
            this.lblDocItemCats.Name = "lblDocItemCats";
            this.lblDocItemCats.Size = new System.Drawing.Size(134, 21);
            this.lblDocItemCats.TabIndex = 1;
            this.lblDocItemCats.Text = "Docs  - Items Cats";
            this.lblDocItemCats.Click += new System.EventHandler(this.Pnl_ItemCats_Click);
            this.lblDocItemCats.MouseEnter += new System.EventHandler(this.Pnl_ItemCats_MouseEnter);
            this.lblDocItemCats.MouseLeave += new System.EventHandler(this.Pnl_ItemCats_MouseLeave);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Image = global::LibrMgr.Properties.Resources.item_connections;
            this.pictureBox6.Location = new System.Drawing.Point(15, 7);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // Pnl_DocSections
            // 
            this.Pnl_DocSections.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_DocSections.Controls.Add(this.pictureBox5);
            this.Pnl_DocSections.Controls.Add(this.lblDocSections);
            this.Pnl_DocSections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_DocSections.Location = new System.Drawing.Point(0, 110);
            this.Pnl_DocSections.Name = "Pnl_DocSections";
            this.Pnl_DocSections.Size = new System.Drawing.Size(166, 35);
            this.Pnl_DocSections.TabIndex = 60;
            this.Pnl_DocSections.Click += new System.EventHandler(this.Pnl_DocSections_Click);
            this.Pnl_DocSections.MouseEnter += new System.EventHandler(this.Pnl_DocSections_MouseEnter);
            this.Pnl_DocSections.MouseLeave += new System.EventHandler(this.Pnl_DocSections_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::LibrMgr.Properties.Resources.screen_with_news_sections;
            this.pictureBox5.Location = new System.Drawing.Point(15, 10);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // lblDocSections
            // 
            this.lblDocSections.AutoSize = true;
            this.lblDocSections.BackColor = System.Drawing.Color.Transparent;
            this.lblDocSections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDocSections.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocSections.ForeColor = System.Drawing.Color.White;
            this.lblDocSections.Location = new System.Drawing.Point(34, 9);
            this.lblDocSections.Name = "lblDocSections";
            this.lblDocSections.Size = new System.Drawing.Size(99, 21);
            this.lblDocSections.TabIndex = 1;
            this.lblDocSections.Text = "Doc Sections";
            this.lblDocSections.Click += new System.EventHandler(this.Pnl_DocSections_Click);
            this.lblDocSections.MouseEnter += new System.EventHandler(this.Pnl_DocSections_MouseEnter);
            this.lblDocSections.MouseLeave += new System.EventHandler(this.Pnl_DocSections_MouseLeave);
            // 
            // lblTypeAssociations
            // 
            this.lblTypeAssociations.AutoSize = true;
            this.lblTypeAssociations.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeAssociations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTypeAssociations.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTypeAssociations.ForeColor = System.Drawing.Color.White;
            this.lblTypeAssociations.Location = new System.Drawing.Point(3, 250);
            this.lblTypeAssociations.Name = "lblTypeAssociations";
            this.lblTypeAssociations.Size = new System.Drawing.Size(123, 19);
            this.lblTypeAssociations.TabIndex = 1;
            this.lblTypeAssociations.Text = "Types/Associations";
            // 
            // Pnl_SectionTypes
            // 
            this.Pnl_SectionTypes.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_SectionTypes.Controls.Add(this.pictureBox7);
            this.Pnl_SectionTypes.Controls.Add(this.lblDocSectionTypes);
            this.Pnl_SectionTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_SectionTypes.Location = new System.Drawing.Point(0, 302);
            this.Pnl_SectionTypes.Name = "Pnl_SectionTypes";
            this.Pnl_SectionTypes.Size = new System.Drawing.Size(166, 35);
            this.Pnl_SectionTypes.TabIndex = 65;
            this.Pnl_SectionTypes.Click += new System.EventHandler(this.Pnl_SectionTypes_Click);
            this.Pnl_SectionTypes.MouseEnter += new System.EventHandler(this.Pnl_SectionTypes_MouseEnter);
            this.Pnl_SectionTypes.MouseLeave += new System.EventHandler(this.Pnl_SectionTypes_MouseLeave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox7.Enabled = false;
            this.pictureBox7.Image = global::LibrMgr.Properties.Resources.window_with_different_sections;
            this.pictureBox7.Location = new System.Drawing.Point(15, 9);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            // 
            // lblDocSectionTypes
            // 
            this.lblDocSectionTypes.AutoSize = true;
            this.lblDocSectionTypes.BackColor = System.Drawing.Color.Transparent;
            this.lblDocSectionTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDocSectionTypes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDocSectionTypes.ForeColor = System.Drawing.Color.White;
            this.lblDocSectionTypes.Location = new System.Drawing.Point(34, 8);
            this.lblDocSectionTypes.Name = "lblDocSectionTypes";
            this.lblDocSectionTypes.Size = new System.Drawing.Size(135, 21);
            this.lblDocSectionTypes.TabIndex = 1;
            this.lblDocSectionTypes.Text = "Doc Section Types";
            this.lblDocSectionTypes.Click += new System.EventHandler(this.Pnl_SectionTypes_Click);
            this.lblDocSectionTypes.MouseEnter += new System.EventHandler(this.Pnl_SectionTypes_MouseEnter);
            this.lblDocSectionTypes.MouseLeave += new System.EventHandler(this.Pnl_SectionTypes_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 7F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 576);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 15);
            this.label5.TabIndex = 56;
            this.label5.Text = "®Copyright. All rights reserved. ";
            // 
            // lblLibraryManager
            // 
            this.lblLibraryManager.AutoSize = true;
            this.lblLibraryManager.BackColor = System.Drawing.Color.Transparent;
            this.lblLibraryManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLibraryManager.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLibraryManager.ForeColor = System.Drawing.Color.White;
            this.lblLibraryManager.Location = new System.Drawing.Point(3, 93);
            this.lblLibraryManager.Name = "lblLibraryManager";
            this.lblLibraryManager.Size = new System.Drawing.Size(110, 19);
            this.lblLibraryManager.TabIndex = 1;
            this.lblLibraryManager.Text = "Library Manager";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrMgr.Properties.Resources.Logo_transparent;
            this.pictureBox1.Location = new System.Drawing.Point(14, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // Navbar
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(166, 600);
            this.Controls.Add(this.lblTypeAssociations);
            this.Controls.Add(this.Pnl_OutputTypes);
            this.Controls.Add(this.lblLibraryManager);
            this.Controls.Add(this.Pnl_StructuredProposal);
            this.Controls.Add(this.Pnl_ItemCats);
            this.Controls.Add(this.Pnl_DocTemplates);
            this.Controls.Add(this.Pnl_DocSections);
            this.Controls.Add(this.Pnl_SectionTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Navbar";
            this.Text = "Navbar";
            this.Load += new System.EventHandler(this.Navbar_Load);
            this.Pnl_OutputTypes.ResumeLayout(false);
            this.Pnl_OutputTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.Pnl_StructuredProposal.ResumeLayout(false);
            this.Pnl_StructuredProposal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.Pnl_DocTemplates.ResumeLayout(false);
            this.Pnl_DocTemplates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.Pnl_ItemCats.ResumeLayout(false);
            this.Pnl_ItemCats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.Pnl_DocSections.ResumeLayout(false);
            this.Pnl_DocSections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.Pnl_SectionTypes.ResumeLayout(false);
            this.Pnl_SectionTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }      
    }
}

