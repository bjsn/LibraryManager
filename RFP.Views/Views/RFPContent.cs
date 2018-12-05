namespace RFP.Views
{
    using RFP.Core;
    using RFP.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;

    public class RFPContent : BasePartialView
    {
        private IContainer components;
        private Label label7;
        private TextBox TbxSearch;
        private Button BtnViewContent;
        private Label label6;
        internal DataGridView DTContent;
        private Label label1;
        private Label LblTotalRows;
        private PictureBox btnSeach;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn DGName;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn KeyWords;
        private DataGridViewTextBoxColumn RTF;
        private DataGridViewTextBoxColumn Name;
        private Button button1;
        private Core.RFPController RFPController;

        public RFPContent(Panel Panel) : base(Panel)
        {
            this.InitializeComponent();
            this.RFPController = new RFPController();
        }

        private void RFPContent_Load(object sender, EventArgs e)
        {
            List<Models.RFPContent> RFPContentList = this.RFPController.GetAll();
            this.DTContent.Rows.Clear();
            foreach (Models.RFPContent content in RFPContentList)
            {
                object[] values = new object[] { content.ID, content.Name, content.Description, content.Keywords, content.Content };
                this.DTContent.Rows.Add(values);
            }
            this.LblTotalRows.Text = RFPContentList.Count + " Rows";
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblTotalRows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTContent = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyWords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RTF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.TbxSearch = new System.Windows.Forms.TextBox();
            this.BtnViewContent = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSeach = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DTContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeach)).BeginInit();
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
            // DTContent
            // 
            this.DTContent.AllowUserToAddRows = false;
            this.DTContent.AllowUserToDeleteRows = false;
            this.DTContent.AllowUserToOrderColumns = true;
            this.DTContent.AllowUserToResizeColumns = false;
            this.DTContent.AllowUserToResizeRows = false;
            this.DTContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTContent.BackgroundColor = System.Drawing.Color.White;
            this.DTContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DTContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DTContent.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DTContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DTContent.ColumnHeadersHeight = 25;
            this.DTContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DTContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.Description,
            this.KeyWords,
            this.RTF});
            this.DTContent.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTContent.DefaultCellStyle = dataGridViewCellStyle2;
            this.DTContent.EnableHeadersVisualStyles = false;
            this.DTContent.GridColor = System.Drawing.Color.White;
            this.DTContent.Location = new System.Drawing.Point(13, 119);
            this.DTContent.MultiSelect = false;
            this.DTContent.Name = "DTContent";
            this.DTContent.ReadOnly = true;
            this.DTContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DTContent.RowHeadersVisible = false;
            this.DTContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DTContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DTContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DTContent.Size = new System.Drawing.Size(705, 425);
            this.DTContent.TabIndex = 24;
            this.DTContent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTContent_CellClick);
            this.DTContent.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DTContent_CellMouseDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 200;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 350;
            // 
            // KeyWords
            // 
            this.KeyWords.HeaderText = "KeyWords";
            this.KeyWords.Name = "KeyWords";
            this.KeyWords.ReadOnly = true;
            this.KeyWords.Width = 155;
            // 
            // RTF
            // 
            this.RTF.HeaderText = "RTF";
            this.RTF.Name = "RTF";
            this.RTF.ReadOnly = true;
            this.RTF.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.Location = new System.Drawing.Point(14, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Search:";
            // 
            // TbxSearch
            // 
            this.TbxSearch.BackColor = System.Drawing.Color.White;
            this.TbxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.TbxSearch.Location = new System.Drawing.Point(17, 74);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new System.Drawing.Size(199, 29);
            this.TbxSearch.TabIndex = 20;
            this.TbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxSearch_KeyDown);
            // 
            // BtnViewContent
            // 
            this.BtnViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnViewContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.BtnViewContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnViewContent.Enabled = false;
            this.BtnViewContent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.BtnViewContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewContent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.BtnViewContent.ForeColor = System.Drawing.Color.White;
            this.BtnViewContent.Location = new System.Drawing.Point(428, 71);
            this.BtnViewContent.Name = "BtnViewContent";
            this.BtnViewContent.Size = new System.Drawing.Size(142, 32);
            this.BtnViewContent.TabIndex = 19;
            this.BtnViewContent.Text = "View Content";
            this.BtnViewContent.UseVisualStyleBackColor = false;
            this.BtnViewContent.Click += new System.EventHandler(this.BtnViewContent_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Insert RFP response content";
            // 
            // btnSeach
            // 
            this.btnSeach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnSeach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeach.Image = global::RFPView.Properties.Resources.search4;
            this.btnSeach.Location = new System.Drawing.Point(216, 74);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(24, 24);
            this.btnSeach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSeach.TabIndex = 28;
            this.btnSeach.TabStop = false;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(190)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(576, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 32);
            this.button1.TabIndex = 29;
            this.button1.Text = "Add Content";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // RFPContent
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(730, 580);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.LblTotalRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTContent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbxSearch);
            this.Controls.Add(this.BtnViewContent);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Load += new System.EventHandler(this.RFPContent_Load);
            this.Shown += new System.EventHandler(this.RFPContent_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DTContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewContent_Click(object sender, EventArgs e)
        {
            RFP_Editor newView = new RFP_Editor(base.MainPanel, this);
            newView.SetRTFString(this.DTContent.SelectedRows[0].Cells[4].Value.ToString());
            newView.SetRTFId(Int32.Parse(this.DTContent.SelectedRows[0].Cells[0].Value.ToString()));
            newView.SetRTFName(this.DTContent.SelectedRows[0].Cells[1].Value.ToString());
            base.OpenPartialView(newView);
        }

        //private void DTContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    BtnViewContent.Enabled = true;
        //}

        public override void Reload() 
        {
            this.DTContent.Rows.Clear();
            List<Models.RFPContent> RFPContentList = this.RFPController.GetAll();
            this.DTContent.Rows.Clear();
            foreach (Models.RFPContent content in RFPContentList)
            {
                object[] values = new object[] { content.ID, content.Name, content.Description, content.Keywords, content.Content };
                this.DTContent.Rows.Add(values);
            }
            this.LblTotalRows.Text = RFPContentList.Count + " Rows";
        }

        private void RFPContent_Shown(object sender, EventArgs e)
        {
            this.Reload();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            ExecuteSearch(this.TbxSearch.Text);
        }

        private void ExecuteSearch(string Search) 
        {
            this.DTContent.Rows.Clear();
            List<Models.RFPContent> RFPContentList = null;

            if (!String.IsNullOrEmpty(Search))
            {
                RFPContentList = RFPController.GetByCoincidence(Search);
            }
            else
            {
                RFPContentList = this.RFPController.GetAll();
            }
            this.DTContent.Rows.Clear();
            foreach (Models.RFPContent content in RFPContentList)
            {
                object[] values = new object[] { content.ID, content.Name, content.Description, content.Keywords, content.Content };
                this.DTContent.Rows.Add(values);
            }
            this.LblTotalRows.Text = RFPContentList.Count + " Rows";
        }

        private void TbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ExecuteSearch(this.TbxSearch.Text);
            }    
        }

        //private void DTContent_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (this.DTContent.RowCount > 0)
        //    {
        //        Excel.Application xlApp = new Excel.Application();
        //        Excel.Workbook xlWorkBook;
        //        //~~> Start Excel and open the workbook.
        //        xlWorkBook = xlApp.Workbooks.Open(@"C:\CorsPro\Test.xls");
        //        //~~> Run the macros by supplying the necessary arguments
        //        xlApp.Run("ShowMsg", this.DTContent.SelectedRows[0].Cells[1].Value.ToString());
        //        //~~> Clean-up: Close the workbook
        //        xlWorkBook.Close(false);
        //        //~~> Quit the Excel Application
        //        xlApp.Quit();
        //        //~~> Clean Up
        //        releaseObject(xlApp);
        //        releaseObject(xlWorkBook);
        //        System.Windows.Forms.Application.Exit();
        //    }
        //}

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void DTContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DTContent.RowCount > 0)
            {
                BtnViewContent.Enabled = true;
            }
        }

        private void DTContent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string XLAPath = RFPController.GetXLAPath();
                if (this.DTContent.RowCount > 0)
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkBook;
                    //~~> Start Excel and open the workbook.
                    xlWorkBook = xlApp.Workbooks.Open(XLAPath);
                    //~~> Run the macros by supplying the necessary arguments
                    xlApp.Run("InsertRFPContent", this.DTContent.SelectedRows[0].Cells[1].Value.ToString());
                    //~~> Clean-up: Close the workbook
                    xlWorkBook.Close(false);
                    //~~> Quit the Excel Application
                    xlApp.Quit();
                    //~~> Clean Up
                    releaseObject(xlApp);
                    releaseObject(xlWorkBook);
                    System.Windows.Forms.Application.Exit();
                }
            }
            catch (Exception exception) 
            {
                MessageBox.Show(exception.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error 
               );
               System.Windows.Forms.Application.Exit();
            }
        }

    }
}

