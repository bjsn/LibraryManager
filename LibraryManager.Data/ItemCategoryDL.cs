using LibraryManager.Common;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public class ItemCategoryDL : BaseDL
    {
        public ItemCategoryDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public List<ItemCategory> GetAll()
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT itemCategories.ItemCategory, itemCategories.Comment, itemCategories.RecSource, itemCategories.RecSourceUpdatedDate, COUNT(docSectionsByItem.ItemCategory) AS DocSectionByItemCount " +
                                     "FROM ItemCategories itemCategories " +
                                     "LEFT JOIN DocSectionsByItem docSectionsByItem ON itemCategories.ItemCategory = docSectionsByItem.ItemCategory " +
                                     "WHERE itemCategories.DeleteMarkDate IS NULL AND docSectionsByItem.DeleteMarkDate IS NULL " +
                                     "GROUP BY itemCategories.ItemCategory, itemCategories.Comment, itemCategories.RecSource, itemCategories.RecSourceUpdatedDate"
                                    ,base.DbConnection)
                                    .Fill(dataTable);
                base.CloseDbConnection();
                return this.Convert(dataTable);
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
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT itemCategories.ItemCategory, itemCategories.Comment, itemCategories.RecSource, itemCategories.RecSourceUpdatedDate, COUNT(docSectionsByItem.ItemCategory) AS DocSectionByItemCount " +
                                     "FROM ItemCategories itemCategories " +
                                     "LEFT JOIN DocSectionsByItem docSectionsByItem ON itemCategories.ItemCategory = docSectionsByItem.ItemCategory " +
                                     "WHERE itemCategories.DeleteMarkDate IS NULL AND docSectionsByItem.DeleteMarkDate IS NULL AND itemCategories.ItemCategory LIKE '%{0}%'" +
                                     "GROUP BY itemCategories.ItemCategory, itemCategories.Comment, itemCategories.RecSource, itemCategories.RecSourceUpdatedDate", keyWord)
                                    ,base.DbConnection)
                                    .Fill(dataTable);
                base.CloseDbConnection();
                return this.Convert(dataTable);
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
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ItemCategory, Comment, RecSource, RecSourceUpdatedDate, DeleteMarkDate " +
                                     "FROM ItemCategories "+
                                     "WHERE ItemCategory = '" + Utilitary.CleanInput(itemCategoryName) + "' AND DeleteMarkDate IS NULL;"
                                     , base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                return this.Convert(dataTable)
                        .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Add(ItemCategory itemCategory)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO ItemCategories(ItemCategory, Comment, RecSource, RecSourceUpdatedDate) " +
                                                "VALUES (@ItemCategory, @Comment, @RecSource, @RecSourceUpdatedDate) ",
                                                new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(itemCategory.ItemCategoryName));
                command.Parameters.AddWithValue("@Comment", Utilitary.CleanInput(itemCategory.Comment));
                command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(itemCategory.RecSource));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", itemCategory.RecSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));
                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                int result = command.ExecuteNonQuery();
                base.CloseDbConnection();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(ItemCategory itemCategory)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {

                    CommandText = string.Format("UPDATE ItemCategories " +
                                                "SET Comment = @Comment, " +
                                                "RecSource = @RecSource, " +
                                                "RecSourceUpdatedDate = @RecSourceUpdatedDate " +
                                                "WHERE ItemCategory = @ItemCategory;", new object[0]),
                    CommandType = CommandType.Text
                };
                
                command.Parameters.AddWithValue("@Comment", Utilitary.CleanInput(itemCategory.Comment));
                command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(itemCategory.RecSource));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", itemCategory.RecSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(itemCategory.ItemCategoryName));



                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                int result = command.ExecuteNonQuery();
                base.CloseDbConnection();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Delete(ItemCategory itemCategory)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE ItemCategories " +
                                                "SET DeleteMarkDate = @DeleteMarkDate, " +
                                                "RecSourceUpdatedDate = @RecSourceUpdatedDate " +
                                                "WHERE ItemCategory = @ItemCategory;", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DeleteMarkDate", itemCategory.DeleteMarkDate.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", itemCategory.DeleteMarkDate.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(itemCategory.ItemCategoryName));
               
                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                int result = command.ExecuteNonQuery();
                base.CloseDbConnection();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<ItemCategory> Convert(DataTable dataTable)
        {
            List<ItemCategory> list = new List<ItemCategory>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Add(new ItemCategory()
                        {
                            ItemCategoryName = (row["ItemCategory"] != DBNull.Value) ? row["ItemCategory"].ToString() : string.Empty,
                            Comment = (row["Comment"] != DBNull.Value) ? row["Comment"].ToString() : string.Empty,
                            RecSource = (row["RecSource"] != DBNull.Value) ? row["RecSource"].ToString() : string.Empty,
                            RecSourceUpdatedDate = string.IsNullOrEmpty(row["RecSourceUpdatedDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["RecSourceUpdatedDate"].ToString()),
                            DocSectionByItemCount = (row.Table.Columns.Contains("DocSectionByItemCount") ? string.IsNullOrEmpty(row["DocSectionByItemCount"].ToString()) ? 0 : Int32.Parse(row["DocSectionByItemCount"].ToString()) : 0)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

    }
}
