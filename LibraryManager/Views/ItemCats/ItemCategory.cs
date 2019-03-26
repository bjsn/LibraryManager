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
    public partial class ItemCategory : BasePartialView
    {
        private ItemCategoryController _itemCategoryController;
        private SetupController _setupController;
        private string ClientName;

        public ItemCategory(Panel panel)
            : base(panel)
        {
            InitializeComponent();
            _itemCategoryController = new ItemCategoryController();
            _setupController = new SetupController();
            LoadItemCategoryList();
            LoadClientName();
        }

        private void LoadClientName()
        {
            try
            {
                this.ClientName = _setupController.GetClientName();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
        }

        #region events
        private void DTItemCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                BtnDelete.Enabled = this.DTItemCategory.SelectedRows[0].Cells[2].Value.ToString().ToUpper().Contains(this.ClientName.ToUpper());
                BtnEdit.Enabled = true;
            }
            else
            {
                BtnDelete.Enabled = false;
                BtnEdit.Enabled = false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            BasePartialView newView = new ItemCategory_Add_Edit(base.MainPanel, this, "");
            base.OpenPartialView(newView);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            string itemName = this.DTItemCategory.SelectedRows[0].Cells[0].Value.ToString();
            BasePartialView newView = new ItemCategory_Add_Edit(base.MainPanel, this, itemName);
            base.OpenPartialView(newView);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string itemName = this.DTItemCategory.SelectedRows[0].Cells[0].Value.ToString();
            Delete_Alert newView = new Delete_Alert(base.MainPanel, this);
            newView.SetText("the item category: '" + itemName + "'");
            base.OpenPartialAlert(newView);
        }

        public override void Delete()
        {
            try
            {
                string itemName = this.DTItemCategory.SelectedRows[0].Cells[0].Value.ToString();
                this._itemCategoryController.Delete(itemName);
                this.LoadItemCategoryList();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

        public override void ReloadGrid()
        {
            int selectedIndex = this.DTItemCategory.CurrentCell.RowIndex;
            this.LoadItemCategoryList();
            this.DTItemCategory.Rows[selectedIndex].Selected = true;
        }
        #endregion


        #region bussiness
        private void LoadItemCategoryList()
        {
            var itemCategoryList = this._itemCategoryController.GetAll();
            this.DTItemCategory.Rows.Clear();
            foreach (var itemCategory in itemCategoryList)
            {
                object[] templateObject = new object[] 
                {
                       itemCategory.ItemCategoryName,
                       itemCategory.DocSectionByItemCount,
                       itemCategory.RecSource
                };

                if (itemCategory.DocSectionByItemCount > 0) 
                {
                    this.DTItemCategory.Rows.Add(templateObject);
                }
            }
        }


        private void LoadItemCategoryListFiltered(string itemCategoryName)
        {
            var itemCategoryList = this._itemCategoryController.GetByKeyword(itemCategoryName);
            this.DTItemCategory.Rows.Clear();
            foreach (var itemCategory in itemCategoryList)
            {
                object[] templateObject = new object[] 
                {
                       itemCategory.ItemCategoryName,
                       itemCategory.DocSectionByItemCount,
                       itemCategory.RecSource
                };
                if (itemCategory.DocSectionByItemCount > 0)
                {
                    this.DTItemCategory.Rows.Add(templateObject);
                }
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string textToSearch = TbxSearch.Text;
            if (string.IsNullOrEmpty(textToSearch))
            {
                this.LoadItemCategoryList();
            }
            else 
            {
                LoadItemCategoryListFiltered(textToSearch);
            }
        }
        #endregion

        private void DTItemCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string itemName = this.DTItemCategory.SelectedRows[0].Cells[0].Value.ToString();
                BasePartialView newView = new ItemCategory_Add_Edit(base.MainPanel, this, itemName);
                base.OpenPartialView(newView);
            }
        }


    }
}
