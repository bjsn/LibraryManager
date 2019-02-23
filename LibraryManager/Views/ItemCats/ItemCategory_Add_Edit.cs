using LibraryManager.Core;
using LibraryManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddEditProposalContent.Views.ItemCats
{
    public partial class ItemCategory_Add_Edit : BasePartialView
    {
        private ItemCategoryController _itemCategoryController;
        private DocSectionController _docSectionController;
        private List<string> deletedDocSectionList;

        private string itemCategoryName;

        public ItemCategory_Add_Edit(Panel panel, BasePartialView preview = null, string itemCategoryName = "")
        : base(panel, preview)
        {
            InitializeComponent();
            this._itemCategoryController = new ItemCategoryController();
            this._docSectionController = new DocSectionController();
            this.deletedDocSectionList = new List<string>();
            this.itemCategoryName = itemCategoryName;

            LoadItemCategoryList();
            LoadItemCategoryInformation();
            LoadDocSectionList();
        }

        #region bussiness 
        private void LoadItemCategoryInformation() 
        {
            this.CbxCategoryList.Enabled = string.IsNullOrEmpty(this.itemCategoryName);
            if (!string.IsNullOrEmpty(this.itemCategoryName)) 
            {
                //subscribe and unsubscribe to avoid duplicate calls
                this.CbxCategoryList.SelectedIndexChanged -= CbxCategoryList_SelectedIndexChanged;
                this.CbxCategoryList.Text = this.itemCategoryName;
                this.CbxCategoryList.SelectedIndexChanged += CbxCategoryList_SelectedIndexChanged;
            }
            LoadItemCategoryInformationByName(this.itemCategoryName);
        }


        private void LoadItemCategoryInformationByName(string itemCategoryName)
        {
            this.DTSectionType.Rows.Clear();
            if (!string.IsNullOrEmpty(itemCategoryName))
            {
                var itemCategory = this._itemCategoryController.GetByName(itemCategoryName);
                if (itemCategory != null)
                {
                     var sectionsByCategory = this._docSectionController.GetSectionsByItemCategory(itemCategory.ItemCategoryName)
                                             .OrderBy(x => x.SOWSection).ToList();
                     foreach (var sectionByCategory in sectionsByCategory)
                     {
                         object[] values = new object[] 
                         {
                             sectionByCategory.SOWSection,  
                             string.IsNullOrEmpty(sectionByCategory.Include) || sectionByCategory.ToString().ToLower().Equals("y") ? "Y" : "N"
                         };
                         this.DTSectionType.Rows.Add(values);
                     }
                }
            }
        }


        private void LoadDocSectionList() 
        {
            try
            {
                var docSectionList = this._docSectionController.GetAll().OrderBy(x => x.Section);
                foreach (var docSection in docSectionList)
                {
                    this.CbxSections.Items.Add(docSection.Section);
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadItemCategoryList() 
        {
            try
            {
                var itemCategoryList = this._itemCategoryController.GetAll().OrderBy(x => x.ItemCategoryName);
                foreach (var itemCategory in itemCategoryList)
                {
                    this.CbxCategoryList.Items.Add(itemCategory.ItemCategoryName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
        #endregion


        #region events
        private void BtnAdd_Click(object sender, EventArgs e)
        {
             var selectedSection = this.CbxSections.SelectedItem == null ? "" : this.CbxSections.SelectedItem;
             if (!string.IsNullOrEmpty(selectedSection.ToString()))
             {
                 bool newSection = true;
                 foreach (DataGridViewRow row in this.DTSectionType.Rows)
                 {
                     var addedRow = row.Cells[0].Value;
                     if (addedRow.Equals(selectedSection))
                     {
                         newSection = false;
                         break;
                     }
                 }
                 if (newSection)
                 {
                     object[] values = new object[] 
                     { 
                         selectedSection,
                         (RbtIncluded_Yes.Checked) ? "Y" : "N"
                     };
                     this.DTSectionType.Rows.Add(values);
                     this.LblAlertSection.Visible = false;
                 }
                 else
                 {
                     this.LblAlertSection.Visible = true;
                 }
             }

            //remove the added item to the delete list
             if (!string.IsNullOrEmpty(selectedSection.ToString())) 
             {
                 foreach (var deletedDocSection in this.deletedDocSectionList)
                 {
                     if (deletedDocSection.Equals(selectedSection.ToString()))
                     {
                         deletedDocSectionList.Remove(selectedSection.ToString());
                         break;
                     }
                 }
             }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string docSection = this.DTSectionType.SelectedRows[0].Cells[0].Value.ToString();
            bool exist = false;
            foreach (var deletedDocSection in this.deletedDocSectionList) 
            {
                if (docSection.Equals(deletedDocSection)) 
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                this.deletedDocSectionList.Add(docSection);
            }
            
            this.DTSectionType.Rows.RemoveAt(this.DTSectionType.SelectedRows[0].Index);
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.CloseCurrentView();
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.deletedDocSectionList.Count > 0) 
                {
                    this._docSectionController.DeleteDocSectionByItem(this.itemCategoryName, this.deletedDocSectionList);
                }

                Dictionary<string, string> docSectionList = new Dictionary<string, string>();
                foreach (DataGridViewRow row in this.DTSectionType.Rows)
                {
                    docSectionList.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }

                if (docSectionList.Count > 0) 
                {
                    this._docSectionController.AddEditDocSectionsByItem(this.CbxCategoryList.SelectedItem.ToString(), docSectionList);
                }

                this.CloseCurrentView();
            }
            catch (Exception exception) 
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void DTSectionType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnDelete.Enabled = true;
            }
            else
            {
                BtnDelete.Enabled = false;
            }
        }


        private void CbxCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = this.CbxCategoryList.SelectedItem == null ? "" : this.CbxCategoryList.SelectedItem.ToString();
            this.LoadItemCategoryInformationByName(selectedCategory);
            this.deletedDocSectionList = new List<string>();
        }
        #endregion


    }
}
