namespace LibraryManager
{
    using AddEditProposalContent.Properties;
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
            this.Pnl_OutputTypes = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.Pnl_StructuredProposal = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Pnl_DocTemplates = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Pnl_ItemCats = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Pnl_DocSections = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.Pnl_TypesAssociations = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.Pnl_SectionTypes = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Pnl_LibrayManager = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pnl_OutputTypes.SuspendLayout();
            this.Pnl_StructuredProposal.SuspendLayout();
            this.Pnl_DocTemplates.SuspendLayout();
            this.Pnl_ItemCats.SuspendLayout();
            this.Pnl_DocSections.SuspendLayout();
            this.Pnl_TypesAssociations.SuspendLayout();
            this.Pnl_SectionTypes.SuspendLayout();
            this.Pnl_LibrayManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_OutputTypes
            // 
            this.Pnl_OutputTypes.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_OutputTypes.Controls.Add(this.label15);
            this.Pnl_OutputTypes.Controls.Add(this.pictureBox8);
            this.Pnl_OutputTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_OutputTypes.Location = new System.Drawing.Point(0, 269);
            this.Pnl_OutputTypes.Name = "Pnl_OutputTypes";
            this.Pnl_OutputTypes.Size = new System.Drawing.Size(163, 40);
            this.Pnl_OutputTypes.TabIndex = 63;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(48, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 19);
            this.label15.TabIndex = 1;
            this.label15.Text = "Output Types";
            // 
            // Pnl_StructuredProposal
            // 
            this.Pnl_StructuredProposal.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_StructuredProposal.Controls.Add(this.pictureBox3);
            this.Pnl_StructuredProposal.Controls.Add(this.label3);
            this.Pnl_StructuredProposal.Controls.Add(this.label4);
            this.Pnl_StructuredProposal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_StructuredProposal.Location = new System.Drawing.Point(0, 111);
            this.Pnl_StructuredProposal.Name = "Pnl_StructuredProposal";
            this.Pnl_StructuredProposal.Size = new System.Drawing.Size(163, 40);
            this.Pnl_StructuredProposal.TabIndex = 59;
            this.Pnl_StructuredProposal.Click += new System.EventHandler(this.Pnl_StructuredProposal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Structured Proposal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Content for Products";
            // 
            // Pnl_DocTemplates
            // 
            this.Pnl_DocTemplates.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_DocTemplates.Controls.Add(this.label7);
            this.Pnl_DocTemplates.Controls.Add(this.pictureBox4);
            this.Pnl_DocTemplates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_DocTemplates.Location = new System.Drawing.Point(0, 150);
            this.Pnl_DocTemplates.Name = "Pnl_DocTemplates";
            this.Pnl_DocTemplates.Size = new System.Drawing.Size(163, 40);
            this.Pnl_DocTemplates.TabIndex = 61;
            this.Pnl_DocTemplates.Click += new System.EventHandler(this.Pnl_DocTemplates_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(40, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Doc templates";
            // 
            // Pnl_ItemCats
            // 
            this.Pnl_ItemCats.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_ItemCats.Controls.Add(this.pictureBox6);
            this.Pnl_ItemCats.Controls.Add(this.label11);
            this.Pnl_ItemCats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_ItemCats.Location = new System.Drawing.Point(0, 348);
            this.Pnl_ItemCats.Name = "Pnl_ItemCats";
            this.Pnl_ItemCats.Size = new System.Drawing.Size(163, 40);
            this.Pnl_ItemCats.TabIndex = 64;
            this.Pnl_ItemCats.Click += new System.EventHandler(this.Pnl_ItemCats_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(48, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Docs  - Items Cats";
            // 
            // Pnl_DocSections
            // 
            this.Pnl_DocSections.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_DocSections.Controls.Add(this.pictureBox5);
            this.Pnl_DocSections.Controls.Add(this.label9);
            this.Pnl_DocSections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_DocSections.Location = new System.Drawing.Point(0, 189);
            this.Pnl_DocSections.Name = "Pnl_DocSections";
            this.Pnl_DocSections.Size = new System.Drawing.Size(163, 40);
            this.Pnl_DocSections.TabIndex = 60;
            this.Pnl_DocSections.Click += new System.EventHandler(this.Pnl_DocSections_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(45, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Doc Sections";
            // 
            // Pnl_TypesAssociations
            // 
            this.Pnl_TypesAssociations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.Pnl_TypesAssociations.Controls.Add(this.panel2);
            this.Pnl_TypesAssociations.Controls.Add(this.pictureBox9);
            this.Pnl_TypesAssociations.Controls.Add(this.label16);
            this.Pnl_TypesAssociations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_TypesAssociations.Location = new System.Drawing.Point(0, 229);
            this.Pnl_TypesAssociations.Name = "Pnl_TypesAssociations";
            this.Pnl_TypesAssociations.Size = new System.Drawing.Size(163, 40);
            this.Pnl_TypesAssociations.TabIndex = 62;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 2);
            this.panel2.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(28, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Types/Associations";
            // 
            // Pnl_SectionTypes
            // 
            this.Pnl_SectionTypes.BackColor = System.Drawing.Color.Transparent;
            this.Pnl_SectionTypes.Controls.Add(this.pictureBox7);
            this.Pnl_SectionTypes.Controls.Add(this.label13);
            this.Pnl_SectionTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_SectionTypes.Location = new System.Drawing.Point(0, 309);
            this.Pnl_SectionTypes.Name = "Pnl_SectionTypes";
            this.Pnl_SectionTypes.Size = new System.Drawing.Size(163, 40);
            this.Pnl_SectionTypes.TabIndex = 65;
            this.Pnl_SectionTypes.Click += new System.EventHandler(this.Pnl_SectionTypes_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(48, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 19);
            this.label13.TabIndex = 1;
            this.label13.Text = "Doc Section Types";
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
            // Pnl_LibrayManager
            // 
            this.Pnl_LibrayManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.Pnl_LibrayManager.Controls.Add(this.pictureBox2);
            this.Pnl_LibrayManager.Controls.Add(this.label2);
            this.Pnl_LibrayManager.Controls.Add(this.panel3);
            this.Pnl_LibrayManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pnl_LibrayManager.Location = new System.Drawing.Point(0, 70);
            this.Pnl_LibrayManager.Name = "Pnl_LibrayManager";
            this.Pnl_LibrayManager.Size = new System.Drawing.Size(163, 40);
            this.Pnl_LibrayManager.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Library Manager";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.panel3.Location = new System.Drawing.Point(-4, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 2);
            this.panel3.TabIndex = 26;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox8.Image = global::AddEditProposalContent.Properties.Resources.list1;
            this.pictureBox8.Location = new System.Drawing.Point(24, 11);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(21, 17);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = global::AddEditProposalContent.Properties.Resources.content;
            this.pictureBox3.Location = new System.Drawing.Point(19, 10);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = global::AddEditProposalContent.Properties.Resources.contract;
            this.pictureBox4.Location = new System.Drawing.Point(20, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 17);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Image = global::AddEditProposalContent.Properties.Resources.item_connections;
            this.pictureBox6.Location = new System.Drawing.Point(24, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(21, 17);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Image = global::AddEditProposalContent.Properties.Resources.screen_with_news_sections;
            this.pictureBox5.Location = new System.Drawing.Point(24, 13);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 17);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox9.Image = global::AddEditProposalContent.Properties.Resources.list;
            this.pictureBox9.Location = new System.Drawing.Point(6, 12);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(20, 18);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 0;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox7.Image = global::AddEditProposalContent.Properties.Resources.window_with_different_sections;
            this.pictureBox7.Location = new System.Drawing.Point(24, 10);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(21, 17);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::AddEditProposalContent.Properties.Resources.text_editor;
            this.pictureBox2.Location = new System.Drawing.Point(7, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AddEditProposalContent.Properties.Resources.Logo_transparent;
            this.pictureBox1.Location = new System.Drawing.Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // Navbar
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(166, 600);
            this.Controls.Add(this.Pnl_OutputTypes);
            this.Controls.Add(this.Pnl_StructuredProposal);
            this.Controls.Add(this.Pnl_DocTemplates);
            this.Controls.Add(this.Pnl_ItemCats);
            this.Controls.Add(this.Pnl_DocSections);
            this.Controls.Add(this.Pnl_TypesAssociations);
            this.Controls.Add(this.Pnl_SectionTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Pnl_LibrayManager);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Navbar";
            this.Text = "Navbar";
            this.Load += new System.EventHandler(this.Navbar_Load);
            this.Pnl_OutputTypes.ResumeLayout(false);
            this.Pnl_OutputTypes.PerformLayout();
            this.Pnl_StructuredProposal.ResumeLayout(false);
            this.Pnl_StructuredProposal.PerformLayout();
            this.Pnl_DocTemplates.ResumeLayout(false);
            this.Pnl_DocTemplates.PerformLayout();
            this.Pnl_ItemCats.ResumeLayout(false);
            this.Pnl_ItemCats.PerformLayout();
            this.Pnl_DocSections.ResumeLayout(false);
            this.Pnl_DocSections.PerformLayout();
            this.Pnl_TypesAssociations.ResumeLayout(false);
            this.Pnl_TypesAssociations.PerformLayout();
            this.Pnl_SectionTypes.ResumeLayout(false);
            this.Pnl_SectionTypes.PerformLayout();
            this.Pnl_LibrayManager.ResumeLayout(false);
            this.Pnl_LibrayManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

