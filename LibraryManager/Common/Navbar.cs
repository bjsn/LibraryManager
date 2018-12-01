namespace LibraryManager
{
    using LibraryManager.Properties;
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
        private Label label15;
        private PictureBox pictureBox8;
        private Panel Pnl_StructuredProposal;
        private PictureBox pictureBox3;
        private Label label3;
        private Label label4;
        private Panel Pnl_DocTemplates;
        private Label label7;
        private PictureBox pictureBox4;
        private Panel Pnl_ItemCats;
        private PictureBox pictureBox6;
        private Label label11;
        private Panel Pnl_DocSections;
        private PictureBox pictureBox5;
        private Label label9;
        private Panel Pnl_TypesAssociations;
        private Panel panel2;
        private PictureBox pictureBox9;
        private Label label16;
        private Panel Pnl_SectionTypes;
        private PictureBox pictureBox7;
        private Label label13;
        private Label label5;
        private Panel Pnl_LibrayManager;
        private PictureBox pictureBox2;
        private Label label2;
        private Panel panel3;
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

        private void InitializeComponent()
        {
            this.Pnl_OutputTypes = new Panel();
            this.label15 = new Label();
            this.pictureBox8 = new PictureBox();
            this.Pnl_StructuredProposal = new Panel();
            this.pictureBox3 = new PictureBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.Pnl_DocTemplates = new Panel();
            this.label7 = new Label();
            this.pictureBox4 = new PictureBox();
            this.Pnl_ItemCats = new Panel();
            this.pictureBox6 = new PictureBox();
            this.label11 = new Label();
            this.Pnl_DocSections = new Panel();
            this.pictureBox5 = new PictureBox();
            this.label9 = new Label();
            this.Pnl_TypesAssociations = new Panel();
            this.panel2 = new Panel();
            this.pictureBox9 = new PictureBox();
            this.label16 = new Label();
            this.Pnl_SectionTypes = new Panel();
            this.pictureBox7 = new PictureBox();
            this.label13 = new Label();
            this.label5 = new Label();
            this.Pnl_LibrayManager = new Panel();
            this.pictureBox2 = new PictureBox();
            this.label2 = new Label();
            this.panel3 = new Panel();
            this.pictureBox1 = new PictureBox();
            this.Pnl_OutputTypes.SuspendLayout();
            ((ISupportInitialize) this.pictureBox8).BeginInit();
            this.Pnl_StructuredProposal.SuspendLayout();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            this.Pnl_DocTemplates.SuspendLayout();
            ((ISupportInitialize) this.pictureBox4).BeginInit();
            this.Pnl_ItemCats.SuspendLayout();
            ((ISupportInitialize) this.pictureBox6).BeginInit();
            this.Pnl_DocSections.SuspendLayout();
            ((ISupportInitialize) this.pictureBox5).BeginInit();
            this.Pnl_TypesAssociations.SuspendLayout();
            ((ISupportInitialize) this.pictureBox9).BeginInit();
            this.Pnl_SectionTypes.SuspendLayout();
            ((ISupportInitialize) this.pictureBox7).BeginInit();
            this.Pnl_LibrayManager.SuspendLayout();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.Pnl_OutputTypes.BackColor = Color.Transparent;
            this.Pnl_OutputTypes.Controls.Add(this.label15);
            this.Pnl_OutputTypes.Controls.Add(this.pictureBox8);
            this.Pnl_OutputTypes.Cursor = Cursors.Hand;
            this.Pnl_OutputTypes.Location = new Point(0, 0x10d);
            this.Pnl_OutputTypes.Name = "Pnl_OutputTypes";
            this.Pnl_OutputTypes.Size = new Size(0xa3, 40);
            this.Pnl_OutputTypes.TabIndex = 0x3f;
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.Transparent;
            this.label15.FlatStyle = FlatStyle.Flat;
            this.label15.Font = new Font("Segoe UI", 8f);
            this.label15.ForeColor = Color.White;
            this.label15.Location = new Point(0x30, 14);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x4b, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Output Types";
            this.pictureBox8.Anchor = AnchorStyles.None;
            this.pictureBox8.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox8.Image = Resources.text_editor;
            this.pictureBox8.Location = new Point(0x18, 11);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new Size(0x15, 0x11);
            this.pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            this.Pnl_StructuredProposal.BackColor = Color.Transparent;
            this.Pnl_StructuredProposal.Controls.Add(this.pictureBox3);
            this.Pnl_StructuredProposal.Controls.Add(this.label3);
            this.Pnl_StructuredProposal.Controls.Add(this.label4);
            this.Pnl_StructuredProposal.Cursor = Cursors.Hand;
            this.Pnl_StructuredProposal.Location = new Point(0, 0x6f);
            this.Pnl_StructuredProposal.Name = "Pnl_StructuredProposal";
            this.Pnl_StructuredProposal.Size = new Size(0xa3, 40);
            this.Pnl_StructuredProposal.TabIndex = 0x3b;
            this.Pnl_StructuredProposal.Click += new EventHandler(this.Pnl_StructuredProposal_Click);
            this.pictureBox3.Anchor = AnchorStyles.None;
            this.pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox3.Image = Resources.flyer;
            this.pictureBox3.Location = new Point(0x13, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(0x13, 0x11);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.FlatStyle = FlatStyle.Flat;
            this.label3.Font = new Font("Segoe UI", 8f);
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(0x2a, 7);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x6d, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Structured Proposal";
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.FlatStyle = FlatStyle.Flat;
            this.label4.Font = new Font("Segoe UI", 8f);
            this.label4.ForeColor = Color.White;
            this.label4.Location = new Point(0x2c, 20);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x73, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Content for Products";
            this.Pnl_DocTemplates.BackColor = Color.Transparent;
            this.Pnl_DocTemplates.Controls.Add(this.label7);
            this.Pnl_DocTemplates.Controls.Add(this.pictureBox4);
            this.Pnl_DocTemplates.Cursor = Cursors.Hand;
            this.Pnl_DocTemplates.Location = new Point(0, 150);
            this.Pnl_DocTemplates.Name = "Pnl_DocTemplates";
            this.Pnl_DocTemplates.Size = new Size(0xa3, 40);
            this.Pnl_DocTemplates.TabIndex = 0x3d;
            this.Pnl_DocTemplates.Click += new EventHandler(this.Pnl_DocTemplates_Click);
            this.label7.AutoSize = true;
            this.label7.BackColor = Color.Transparent;
            this.label7.FlatStyle = FlatStyle.Flat;
            this.label7.Font = new Font("Segoe UI", 8f);
            this.label7.ForeColor = Color.White;
            this.label7.Location = new Point(40, 15);
            this.label7.Name = "label7";
            this.label7.Size = new Size(80, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Doc templates";
            this.pictureBox4.Anchor = AnchorStyles.None;
            this.pictureBox4.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox4.Image = Resources.tex_template;
            this.pictureBox4.Location = new Point(20, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(0x13, 0x11);
            this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.Pnl_ItemCats.BackColor = Color.Transparent;
            this.Pnl_ItemCats.Controls.Add(this.pictureBox6);
            this.Pnl_ItemCats.Controls.Add(this.label11);
            this.Pnl_ItemCats.Cursor = Cursors.Hand;
            this.Pnl_ItemCats.Location = new Point(0, 0x15c);
            this.Pnl_ItemCats.Name = "Pnl_ItemCats";
            this.Pnl_ItemCats.Size = new Size(0xa3, 40);
            this.Pnl_ItemCats.TabIndex = 0x40;
            this.Pnl_ItemCats.Click += new EventHandler(this.Pnl_ItemCats_Click);
            this.pictureBox6.Anchor = AnchorStyles.None;
            this.pictureBox6.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox6.Image = Resources.category;
            this.pictureBox6.Location = new Point(0x18, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new Size(0x15, 0x11);
            this.pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.label11.AutoSize = true;
            this.label11.BackColor = Color.Transparent;
            this.label11.FlatStyle = FlatStyle.Flat;
            this.label11.Font = new Font("Segoe UI", 8f);
            this.label11.ForeColor = Color.White;
            this.label11.Location = new Point(0x30, 14);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x61, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Docs  - Items Cats";
            this.Pnl_DocSections.BackColor = Color.Transparent;
            this.Pnl_DocSections.Controls.Add(this.pictureBox5);
            this.Pnl_DocSections.Controls.Add(this.label9);
            this.Pnl_DocSections.Cursor = Cursors.Hand;
            this.Pnl_DocSections.Location = new Point(0, 0xbd);
            this.Pnl_DocSections.Name = "Pnl_DocSections";
            this.Pnl_DocSections.Size = new Size(0xa3, 40);
            this.Pnl_DocSections.TabIndex = 60;
            this.Pnl_DocSections.Click += new EventHandler(this.Pnl_DocSections_Click);
            this.pictureBox5.Anchor = AnchorStyles.None;
            this.pictureBox5.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox5.Image = Resources.file1;
            this.pictureBox5.Location = new Point(0x18, 13);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(0x13, 0x11);
            this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.label9.AutoSize = true;
            this.label9.BackColor = Color.Transparent;
            this.label9.FlatStyle = FlatStyle.Flat;
            this.label9.Font = new Font("Segoe UI", 8f);
            this.label9.ForeColor = Color.White;
            this.label9.Location = new Point(0x2d, 15);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x49, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Doc Sections";
            this.Pnl_TypesAssociations.BackColor = Color.FromArgb(0x27, 0x27, 0x27);
            this.Pnl_TypesAssociations.Controls.Add(this.panel2);
            this.Pnl_TypesAssociations.Controls.Add(this.pictureBox9);
            this.Pnl_TypesAssociations.Controls.Add(this.label16);
            this.Pnl_TypesAssociations.Cursor = Cursors.Hand;
            this.Pnl_TypesAssociations.Location = new Point(0, 0xe5);
            this.Pnl_TypesAssociations.Name = "Pnl_TypesAssociations";
            this.Pnl_TypesAssociations.Size = new Size(0xa3, 40);
            this.Pnl_TypesAssociations.TabIndex = 0x3e;
            this.panel2.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.panel2.Location = new Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0xa5, 2);
            this.panel2.TabIndex = 0x1b;
            this.pictureBox9.Anchor = AnchorStyles.None;
            this.pictureBox9.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox9.Image = Resources.link;
            this.pictureBox9.Location = new Point(6, 12);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new Size(20, 0x12);
            this.pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 0;
            this.pictureBox9.TabStop = false;
            this.label16.AutoSize = true;
            this.label16.BackColor = Color.Transparent;
            this.label16.FlatStyle = FlatStyle.Flat;
            this.label16.Font = new Font("Segoe UI", 8.5f);
            this.label16.ForeColor = Color.White;
            this.label16.Location = new Point(0x1c, 13);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x6c, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Types/Associations";
            this.Pnl_SectionTypes.BackColor = Color.Transparent;
            this.Pnl_SectionTypes.Controls.Add(this.pictureBox7);
            this.Pnl_SectionTypes.Controls.Add(this.label13);
            this.Pnl_SectionTypes.Cursor = Cursors.Hand;
            this.Pnl_SectionTypes.Location = new Point(0, 0x135);
            this.Pnl_SectionTypes.Name = "Pnl_SectionTypes";
            this.Pnl_SectionTypes.Size = new Size(0xa3, 40);
            this.Pnl_SectionTypes.TabIndex = 0x41;
            this.Pnl_SectionTypes.Click += new EventHandler(this.Pnl_SectionTypes_Click);
            this.pictureBox7.Anchor = AnchorStyles.None;
            this.pictureBox7.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox7.Image = Resources.brochure_with_three_sections;
            this.pictureBox7.Location = new Point(0x18, 10);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new Size(0x15, 0x11);
            this.pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            this.label13.AutoSize = true;
            this.label13.BackColor = Color.Transparent;
            this.label13.FlatStyle = FlatStyle.Flat;
            this.label13.Font = new Font("Segoe UI", 8f);
            this.label13.ForeColor = Color.White;
            this.label13.Location = new Point(0x30, 13);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x62, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Doc Section Types";
            this.label5.AutoSize = true;
            this.label5.FlatStyle = FlatStyle.Flat;
            this.label5.Font = new Font("Segoe UI Semibold", 7f, FontStyle.Bold);
            this.label5.ForeColor = Color.White;
            this.label5.Location = new Point(5, 0x22f);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x9a, 12);
            this.label5.TabIndex = 0x38;
            this.label5.Text = "\x00aeCopyright. All rights reserved. ";
            this.Pnl_LibrayManager.BackColor = Color.FromArgb(0x27, 0x27, 0x27);
            this.Pnl_LibrayManager.Controls.Add(this.pictureBox2);
            this.Pnl_LibrayManager.Controls.Add(this.label2);
            this.Pnl_LibrayManager.Controls.Add(this.panel3);
            this.Pnl_LibrayManager.Cursor = Cursors.Hand;
            this.Pnl_LibrayManager.Location = new Point(0, 70);
            this.Pnl_LibrayManager.Name = "Pnl_LibrayManager";
            this.Pnl_LibrayManager.Size = new Size(0xa3, 40);
            this.Pnl_LibrayManager.TabIndex = 0x3a;
            this.pictureBox2.Anchor = AnchorStyles.None;
            this.pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox2.Image = Resources.library;
            this.pictureBox2.Location = new Point(7, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(20, 0x12);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.FlatStyle = FlatStyle.Flat;
            this.label2.Font = new Font("Segoe UI", 8.5f);
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(0x1d, 14);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5d, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Library Manager";
            this.panel3.BackColor = Color.FromArgb(0, 0x72, 0xc6);
            this.panel3.Location = new Point(-4, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0xa5, 2);
            this.panel3.TabIndex = 0x1a;
            //this.pictureBox1.Image = Resources.Logo_Transparent__white_;
            this.pictureBox1.Location = new Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x7c, 0x22);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0x39;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0x33, 0x33, 0x33);
            base.ClientSize = new Size(0xa3, 580);
            base.Controls.Add(this.Pnl_OutputTypes);
            base.Controls.Add(this.Pnl_StructuredProposal);
            base.Controls.Add(this.Pnl_DocTemplates);
            base.Controls.Add(this.Pnl_ItemCats);
            base.Controls.Add(this.Pnl_DocSections);
            base.Controls.Add(this.Pnl_TypesAssociations);
            base.Controls.Add(this.Pnl_SectionTypes);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.Pnl_LibrayManager);
            base.Controls.Add(this.pictureBox1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "Navbar";
            this.Text = "Navbar";
            base.Load += new EventHandler(this.Navbar_Load);
            this.Pnl_OutputTypes.ResumeLayout(false);
            this.Pnl_OutputTypes.PerformLayout();
            ((ISupportInitialize) this.pictureBox8).EndInit();
            this.Pnl_StructuredProposal.ResumeLayout(false);
            this.Pnl_StructuredProposal.PerformLayout();
            ((ISupportInitialize) this.pictureBox3).EndInit();
            this.Pnl_DocTemplates.ResumeLayout(false);
            this.Pnl_DocTemplates.PerformLayout();
            ((ISupportInitialize) this.pictureBox4).EndInit();
            this.Pnl_ItemCats.ResumeLayout(false);
            this.Pnl_ItemCats.PerformLayout();
            ((ISupportInitialize) this.pictureBox6).EndInit();
            this.Pnl_DocSections.ResumeLayout(false);
            this.Pnl_DocSections.PerformLayout();
            ((ISupportInitialize) this.pictureBox5).EndInit();
            this.Pnl_TypesAssociations.ResumeLayout(false);
            this.Pnl_TypesAssociations.PerformLayout();
            ((ISupportInitialize) this.pictureBox9).EndInit();
            this.Pnl_SectionTypes.ResumeLayout(false);
            this.Pnl_SectionTypes.PerformLayout();
            ((ISupportInitialize) this.pictureBox7).EndInit();
            this.Pnl_LibrayManager.ResumeLayout(false);
            this.Pnl_LibrayManager.PerformLayout();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Navbar_Load(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new ProposalContent(base.MainPanel);
            this.SelectOption(this.Pnl_StructuredProposal, proposalContentView);
        }

        private void Pnl_DocSections_Click(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new DocSection(base.MainPanel);
            this.SelectOption(this.Pnl_DocSections, proposalContentView);
        }

        private void Pnl_DocTemplates_Click(object sender, EventArgs e)
        {
            this.SelectOption(this.Pnl_DocTemplates, null);
        }

        private void Pnl_ItemCats_Click(object sender, EventArgs e)
        {
            this.SelectOption(this.Pnl_ItemCats, null);
        }

        private void Pnl_OutputTypes_Click(object sender, EventArgs e)
        {
            this.SelectOption(this.Pnl_OutputTypes, null);
        }

        private void Pnl_SectionTypes_Click(object sender, EventArgs e)
        {
            this.SelectOption(this.Pnl_SectionTypes, null);
        }

        private void Pnl_StructuredProposal_Click(object sender, EventArgs e)
        {
            BasePartialView proposalContentView = new ProposalContent(base.MainPanel);
            this.SelectOption(this.Pnl_StructuredProposal, proposalContentView);
        }

        private void SelectOption(Panel panel, BasePartialView proposalContentView = null)
        {
            if (panel.BackColor != Color.FromArgb(0x1f, 0x1f, 0x1f))
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
                    control.BackColor = Color.FromArgb(0x33, 0x33, 0x33);
                    IEnumerator enumerator = control.Controls.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Control current = (Control) enumerator.Current;
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
            Panel panel2 = new Panel {
                Location = new Point(0, 0),
                Size = new Size(4, 40),
                MaximumSize = new Size(4, 40),
                BackColor = Color.FromArgb(0, 0x72, 0xc6)
            };
            panel.Controls.Add(panel2);
            panel.BackColor = Color.FromArgb(0x1f, 0x1f, 0x1f);
        }
    }
}

