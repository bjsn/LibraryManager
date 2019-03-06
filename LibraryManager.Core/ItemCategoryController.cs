using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class ItemCategoryController : BaseController
    {
        private ItemCategoryDL _itemCategortDL;
        private DocSectionsByItemDL _docSectionByItem;

        public ItemCategoryController() : base()
        {
            _itemCategortDL = new ItemCategoryDL(base.DBConnectionPath) { DbPwd = base.DBPW };
            _docSectionByItem = new DocSectionsByItemDL(base.DBConnectionPath) { DbPwd = base.DBPW };
        }

        public List<ItemCategory> GetAll() 
        {
            try
            {
                var itemCategoryList = this._itemCategortDL.GetAll();
                return itemCategoryList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ItemCategory> GetByKeyword(string keyWord)
        {
            try
            {
                return this._itemCategortDL.GetByKeyword(keyWord);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ItemCategory GetByName(string itemCategoryName)
        {
            try
            {
                var itemCategory = this._itemCategortDL.GetByName(itemCategoryName);
                itemCategory.DocSectionByItem = this._docSectionByItem.GetByItemCategory(itemCategory.ItemCategoryName);
                return itemCategory;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool IsValidName(string itemCategoryName) 
        {
            try
            {
                return this._itemCategortDL.GetByName(itemCategoryName) == null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Add() 
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int Update() 
        {
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
            return 0;
        }

        public int Delete(string itemCategoryName) 
        {
            try
            {
                ItemCategory itemCategory = this.GetByName(itemCategoryName);
                itemCategory.DeleteMarkDate = DateTime.Now;
                return this._itemCategortDL.Delete(itemCategory);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
