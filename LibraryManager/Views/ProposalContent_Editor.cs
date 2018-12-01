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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ProposalContent_Editor));
            this.LblOpenTxb = new Label();
            this.LblAction = new Label();
            this.BtnCancel = new Button();
            this.BtnSave = new Button();
            this.panel1 = new Panel();
            this.toolStrip1 = new ToolStrip();
            this.EditorControl_Bold = new ToolStripButton();
            this.EditorControl_Italic = new ToolStripButton();
            this.EditorControl_Underline = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.EditorControl_Bullet = new ToolStripButton();
            this.EditorBox = new RichTextBox();
            this.label6 = new Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            base.SuspendLayout();
            this.LblOpenTxb.AutoSize = true;
            this.LblOpenTxb.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            this.LblOpenTxb.ForeColor = Color.FromArgb(0xfe, 0x35, 0x47);
            this.LblOpenTxb.Location = new Point(0x45, 0x2d);
            this.LblOpenTxb.Name = "LblOpenTxb";
            this.LblOpenTxb.Size = new Size(0, 20);
            this.LblOpenTxb.TabIndex = 0x2a;
            this.LblAction.AutoSize = true;
            this.LblAction.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            this.LblAction.Location = new Point(11, 0x2d);
            this.LblAction.Name = "LblAction";
            this.LblAction.Size = new Size(0x3d, 20);
            this.LblAction.TabIndex = 0x29;
            this.LblAction.Text = "Editing:";
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
            this.BtnCancel.TabIndex = 40;
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
            this.BtnSave.TabIndex = 0x27;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new EventHandler(this.BtnSave_Click);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.EditorBox);
            this.panel1.Location = new Point(12, 0x4d);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x2c0, 0x1c5);
            this.panel1.TabIndex = 20;
            ToolStripItem[] toolStripItems = new ToolStripItem[] { this.EditorControl_Bold, this.EditorControl_Italic, this.EditorControl_Underline, this.toolStripSeparator1, this.EditorControl_Bullet };
            this.toolStrip1.Items.AddRange(toolStripItems);
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(0x2c0, 0x19);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.EditorControl_Bold.BackgroundImageLayout = ImageLayout.Center;
            this.EditorControl_Bold.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.EditorControl_Bold.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            //this.EditorControl_Bold.Image = (Image) manager.GetObject("EditorControl_Bold.Image");
            this.EditorControl_Bold.ImageTransparentColor = Color.Magenta;
            this.EditorControl_Bold.Name = "EditorControl_Bold";
            this.EditorControl_Bold.Size = new Size(0x17, 0x16);
            this.EditorControl_Bold.Text = "B";
            this.EditorControl_Bold.ToolTipText = "Bold";
            this.EditorControl_Bold.Click += new EventHandler(this.EditorControl_Bold_Click);
            this.EditorControl_Italic.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.EditorControl_Italic.Font = new Font("Segoe UI", 9f, FontStyle.Italic | FontStyle.Bold, GraphicsUnit.Point, 0);
            //this.EditorControl_Italic.Image = (Image) manager.GetObject("EditorControl_Italic.Image");
            this.EditorControl_Italic.ImageScaling = ToolStripItemImageScaling.None;
            this.EditorControl_Italic.ImageTransparentColor = Color.Magenta;
            this.EditorControl_Italic.Name = "EditorControl_Italic";
            this.EditorControl_Italic.Size = new Size(0x17, 0x16);
            this.EditorControl_Italic.Text = "I";
            this.EditorControl_Italic.ToolTipText = "Italic";
            this.EditorControl_Italic.Click += new EventHandler(this.EditorControl_Italic_Click);
            this.EditorControl_Underline.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.EditorControl_Underline.Font = new Font("Segoe UI", 9f, FontStyle.Underline | FontStyle.Bold, GraphicsUnit.Point, 0);
            this.EditorControl_Underline.ForeColor = SystemColors.ActiveCaptionText;
            //this.EditorControl_Underline.Image = (Image) manager.GetObject("EditorControl_Underline.Image");
            this.EditorControl_Underline.ImageTransparentColor = Color.Magenta;
            this.EditorControl_Underline.Name = "EditorControl_Underline";
            this.EditorControl_Underline.Size = new Size(0x17, 0x16);
            this.EditorControl_Underline.Text = "U";
            this.EditorControl_Underline.ToolTipText = "Undeline";
            this.EditorControl_Underline.Click += new EventHandler(this.EditorControl_Underline_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 0x19);
            this.EditorControl_Bullet.DisplayStyle = ToolStripItemDisplayStyle.Image;
            //this.EditorControl_Bullet.Image = (Image) manager.GetObject("EditorControl_Bullet.Image");
            this.EditorControl_Bullet.ImageTransparentColor = Color.Magenta;
            this.EditorControl_Bullet.Name = "EditorControl_Bullet";
            this.EditorControl_Bullet.Size = new Size(0x17, 0x16);
            this.EditorControl_Bullet.Text = "Bullets";
            this.EditorControl_Bullet.Click += new EventHandler(this.EditorControl_Bullet_Click);
            this.EditorBox.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.EditorBox.BackColor = Color.White;
            this.EditorBox.BorderStyle = BorderStyle.FixedSingle;
            this.EditorBox.BulletIndent = 15;
            this.EditorBox.DetectUrls = false;
            this.EditorBox.Font = new Font("Segoe UI", 11f);
            this.EditorBox.ForeColor = Color.Black;
            this.EditorBox.Location = new Point(3, 0x1c);
            this.EditorBox.Name = "EditorBox";
            this.EditorBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.EditorBox.Size = new Size(0x2bd, 0x1a6);
            this.EditorBox.TabIndex = 0;
            this.EditorBox.TabStop = false;
            this.EditorBox.Text = "";
            this.EditorBox.MouseClick += new MouseEventHandler(this.EditorBox_MouseClick);
            this.EditorBox.KeyPress += new KeyPressEventHandler(this.EditorBox_KeyPress);
            this.EditorBox.KeyUp += new KeyEventHandler(this.EditorBox_KeyUp);
            this.label6.AutoSize = true;
            this.label6.FlatStyle = FlatStyle.Flat;
            this.label6.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label6.ForeColor = Color.FromArgb(0x26, 0x26, 0x26);
            this.label6.Location = new Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1af, 15);
            this.label6.TabIndex = 0x12;
            this.label6.Text = "Library Manager > Structured Proposal Content for Products > Add/Edit > Editor";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.WhiteSmoke;
            base.ClientSize = new Size(730, 580);
            base.Controls.Add(this.LblOpenTxb);
            base.Controls.Add(this.LblAction);
            base.Controls.Add(this.BtnCancel);
            base.Controls.Add(this.BtnSave);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.label6);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "ProposalContent_Editor";
            this.Text = "ProposalContent_Editor";
            base.Load += new EventHandler(this.ProposalContent_Editor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
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
    }
}

