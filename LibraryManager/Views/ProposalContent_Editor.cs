namespace LibraryManager.Views
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ProposalContent_Editor : BasePartialView
    {
        private string TxbOpenName;
        public string RTFString;
        private KeyEventArgs previewKeyEnter;
        private IContainer components;
        private Label label6;
        private RichTextBox EditorBox;
        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton EditorControl_Bold;
        private ToolStripButton EditorControl_Italic;
        private ToolStripButton EditorControl_Underline;
        private Button BtnCancel;
        private Button BtnSave;
        private Label LblAction;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton EditorControl_Bullet;
        private Label LblOpenTxb;
            
        public ProposalContent_Editor()
        {
            this.previewKeyEnter = new KeyEventArgs(Keys.Back);
            this.InitializeComponent();
        }

        public ProposalContent_Editor(Panel Panel, BasePartialView Preview = null) : base(Panel, Preview)
        {
            this.previewKeyEnter = new KeyEventArgs(Keys.Back);
            this.InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.ClosePartialView();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.RTFString = this.EditorBox.Rtf;
            base.PreviewForm.SetRTFText(this.RTFString);
            base.ClosePartialView();
        }

        private void DecorateSelectedText()
        {
            int selectionStart = this.EditorBox.SelectionStart;
            this.EditorBox.SelectionFont = this.GetSelectedFont();
            this.EditorBox.SelectionStart += this.EditorBox.SelectionLength;
            this.EditorBox.SelectionLength = 0;
            this.EditorBox.SelectionFont = this.EditorBox.Font;
            this.EditorBox.Select(selectionStart, this.EditorBox.SelectionLength);
            this.EditorBox.SelectionBullet = this.EditorControl_Bullet.Checked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditorBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.EditorBox.SelectionFont = this.GetSelectedFont();
        }

        private void EditorBox_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && !this.EditorBox.SelectionBullet)
            {
                this.EditorBox.SelectionIndent = 0;
                this.EditorControl_Bullet.Checked = false;
                this.previewKeyEnter = new KeyEventArgs(Keys.Back);
            }
            this.EditorControl_Bullet.Checked = this.EditorBox.SelectionBullet;
            this.EditorControl_Bold.Checked = this.EditorBox.SelectionFont.Bold;
            this.EditorControl_Italic.Checked = this.EditorBox.SelectionFont.Italic;
            this.EditorControl_Underline.Checked = this.EditorBox.SelectionFont.Underline;
            this.previewKeyEnter = e;
            e.Handled = false;
        }

        private void EditorBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.EditorControl_Bullet.Checked = this.EditorBox.SelectionBullet;
            this.EditorControl_Bold.Checked = this.EditorBox.SelectionFont.Bold;
            this.EditorControl_Italic.Checked = this.EditorBox.SelectionFont.Italic;
            this.EditorControl_Underline.Checked = this.EditorBox.SelectionFont.Underline;
        }

        private void EditorControl_Bold_Click(object sender, EventArgs e)
        {
            this.EditorControl_Bold.Checked = !this.EditorControl_Bold.Checked;
            this.DecorateSelectedText();
        }

        private void EditorControl_Bullet_Click(object sender, EventArgs e)
        {
            this.EditorBox.SelectionIndent = this.EditorControl_Bullet.Checked ? 0 : 15;
            this.EditorControl_Bullet.Checked = !this.EditorControl_Bullet.Checked;
            this.EditorBox.SelectionBullet = this.EditorControl_Bullet.Checked;
        }

        private void EditorControl_Italic_Click(object sender, EventArgs e)
        {
            this.EditorControl_Italic.Checked = !this.EditorControl_Italic.Checked;
            this.DecorateSelectedText();
        }

        private void EditorControl_Underline_Click(object sender, EventArgs e)
        {
            this.EditorControl_Underline.Checked = !this.EditorControl_Underline.Checked;
            this.DecorateSelectedText();
        }

        private Font GetSelectedFont()
        {
            return new Font(this.EditorBox.Font, ((this.EditorControl_Bold.Checked ? FontStyle.Bold : FontStyle.Regular) | (this.EditorControl_Italic.Checked ? FontStyle.Italic : FontStyle.Regular)) | (this.EditorControl_Underline.Checked ? FontStyle.Underline : FontStyle.Regular));
        }

        private void InitializeComponent()
        {
            this.LblOpenTxb = new System.Windows.Forms.Label();
            this.LblAction = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EditorControl_Bold = new System.Windows.Forms.ToolStripButton();
            this.EditorControl_Italic = new System.Windows.Forms.ToolStripButton();
            this.EditorControl_Underline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditorControl_Bullet = new System.Windows.Forms.ToolStripButton();
            this.EditorBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblOpenTxb
            // 
            this.LblOpenTxb.AutoSize = true;
            this.LblOpenTxb.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.LblOpenTxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.LblOpenTxb.Location = new System.Drawing.Point(69, 45);
            this.LblOpenTxb.Name = "LblOpenTxb";
            this.LblOpenTxb.Size = new System.Drawing.Size(0, 25);
            this.LblOpenTxb.TabIndex = 42;
            // 
            // LblAction
            // 
            this.LblAction.AutoSize = true;
            this.LblAction.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.LblAction.Location = new System.Drawing.Point(11, 45);
            this.LblAction.Name = "LblAction";
            this.LblAction.Size = new System.Drawing.Size(77, 25);
            this.LblAction.TabIndex = 41;
            this.LblAction.Text = "Editing:";
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
            this.BtnCancel.TabIndex = 40;
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
            this.BtnSave.TabIndex = 39;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.EditorBox);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 453);
            this.panel1.TabIndex = 20;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditorControl_Bold,
            this.EditorControl_Italic,
            this.EditorControl_Underline,
            this.toolStripSeparator1,
            this.EditorControl_Bullet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(704, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EditorControl_Bold
            // 
            this.EditorControl_Bold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EditorControl_Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditorControl_Bold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorControl_Bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditorControl_Bold.Name = "EditorControl_Bold";
            this.EditorControl_Bold.Size = new System.Drawing.Size(23, 24);
            this.EditorControl_Bold.Text = "B";
            this.EditorControl_Bold.ToolTipText = "Bold";
            this.EditorControl_Bold.Click += new System.EventHandler(this.EditorControl_Bold_Click);
            // 
            // EditorControl_Italic
            // 
            this.EditorControl_Italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditorControl_Italic.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorControl_Italic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditorControl_Italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditorControl_Italic.Name = "EditorControl_Italic";
            this.EditorControl_Italic.Size = new System.Drawing.Size(23, 24);
            this.EditorControl_Italic.Text = "I";
            this.EditorControl_Italic.ToolTipText = "Italic";
            this.EditorControl_Italic.Click += new System.EventHandler(this.EditorControl_Italic_Click);
            // 
            // EditorControl_Underline
            // 
            this.EditorControl_Underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditorControl_Underline.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorControl_Underline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EditorControl_Underline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditorControl_Underline.Name = "EditorControl_Underline";
            this.EditorControl_Underline.Size = new System.Drawing.Size(24, 24);
            this.EditorControl_Underline.Text = "U";
            this.EditorControl_Underline.ToolTipText = "Undeline";
            this.EditorControl_Underline.Click += new System.EventHandler(this.EditorControl_Underline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // EditorControl_Bullet
            // 
            this.EditorControl_Bullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditorControl_Bullet.Image = global::AddEditProposalContent.Properties.Resources.bullets;
            this.EditorControl_Bullet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditorControl_Bullet.Name = "EditorControl_Bullet";
            this.EditorControl_Bullet.Size = new System.Drawing.Size(23, 24);
            this.EditorControl_Bullet.Text = "Bullets";
            this.EditorControl_Bullet.Click += new System.EventHandler(this.EditorControl_Bullet_Click);
            // 
            // EditorBox
            // 
            this.EditorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorBox.BackColor = System.Drawing.Color.White;
            this.EditorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorBox.BulletIndent = 15;
            this.EditorBox.DetectUrls = false;
            this.EditorBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.EditorBox.ForeColor = System.Drawing.Color.Black;
            this.EditorBox.Location = new System.Drawing.Point(3, 28);
            this.EditorBox.Name = "EditorBox";
            this.EditorBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.EditorBox.Size = new System.Drawing.Size(701, 422);
            this.EditorBox.TabIndex = 0;
            this.EditorBox.TabStop = false;
            this.EditorBox.Text = "";
            this.EditorBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditorBox_MouseClick);
            this.EditorBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditorBox_KeyPress);
            this.EditorBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditorBox_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(561, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Library Manager > Structured Proposal Content for Products > Add/Edit > Editor";
            // 
            // ProposalContent_Editor
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.LblOpenTxb);
            this.Controls.Add(this.LblAction);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProposalContent_Editor";
            this.Text = "ProposalContent_Editor";
            this.Load += new System.EventHandler(this.ProposalContent_Editor_Load);
            this.Shown += new System.EventHandler(this.ProposalContent_Editor_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ProposalContent_Editor_Load(object sender, EventArgs e)
        {
            this.EditorBox.AcceptsTab = true;
        }

        public void SetRTFString(string RTF)
        {
            this.RTFString = RTF;
            this.SetRTFToTextRichBox(this.RTFString);
        }

        private void SetRTFToTextRichBox(string RTFtext)
        {
            this.EditorBox.Rtf = RTFtext;
            float emSize = 10.5f;
            this.EditorBox.Font = new Font(this.EditorBox.Font.Name, emSize);
        }

        public void SetTxbOpenName(string TbxName)
        {
            this.TxbOpenName = TbxName;
            this.LblOpenTxb.Text = this.TxbOpenName;
        }

        private void ProposalContent_Editor_Shown(object sender, EventArgs e)
        {
            this.EditorBox.Focus();
        }

    }
}

