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
    public class DocSectionsByItemDL : BaseDL
    {
        public DocSectionsByItemDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public List<DocSectionByItem> GetAll() 
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ItemCategory, SOWSection, Include, RecSource, RecSourceUpdatedDate, ModSource, ModSourceUpdatedDate " +
                                     "FROM DocSectionsByItem " +
                                     "WHERE DeleteMarkDate IS NULL;", base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                return this.Convert(dataTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetCountRowsByItemCategory(string itemCategoryName)
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ItemCategory " +
                                     "FROM DocSectionsByItem " +
                                     "WHERE DeleteMarkDate IS NULL AND ItemCategory = '" + Utilitary.CleanInput(itemCategoryName) + ";'", base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                return dataTable.Rows.Count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<DocSectionByItem> GetByItemCategory(string itemCategoryName)
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ItemCategory, SOWSection, Include, RecSource, RecSourceUpdatedDate, ModSource, ModSourceUpdatedDate " +
                                     "FROM DocSectionsByItem " +
                                     "WHERE DeleteMarkDate IS NULL AND ItemCategory = '" + Utilitary.CleanInput(itemCategoryName) + "'", base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                return this.Convert(dataTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DocSectionByItem GetByItemCategoryAndSection(string itemCategoryName, string setionName)
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ItemCategory, SOWSection, Include, RecSource, RecSourceUpdatedDate, ModSource, ModSourceUpdatedDate " +
                                     "FROM DocSectionsByItem " +
                                     "WHERE DeleteMarkDate IS NULL AND ItemCategory = '" + Utilitary.CleanInput(itemCategoryName) + "' AND SOWSection = '" + Utilitary.CleanInput(setionName) + "'", base.DbConnection)
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

        public int Add(DocSectionByItem docSectionByItem)
        {
            try
            {
                base.OpenDbConnection();
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO DocSectionsByItem(ItemCategory, SOWSection, Include, RecSource, RecSourceUpdatedDate) " +
                                                "VALUES (@ItemCategory, @SOWSection, @Include, @RecSource, @RecSourceUpdatedDate) ",
                                                new object[0]),
                    CommandType = CommandType.Text
                };

                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(docSectionByItem.ItemCategory));
                command.Parameters.AddWithValue("@SOWSection", Utilitary.CleanInput(docSectionByItem.SOWSection));
                command.Parameters.AddWithValue("@Include", Utilitary.CleanInput(docSectionByItem.Include));
                command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(docSectionByItem.RecSource));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", docSectionByItem.RecSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));

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

        public int Update(DocSectionByItem docSectionByItem)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE DocSectionsByItem " +
                                                "SET Include = @Include " +
                                                "WHERE ItemCategory = @ItemCategory AND SOWSection = @SOWSection", new object[0]),
                    CommandType = CommandType.Text
                };

                command.Parameters.AddWithValue("@Include", Utilitary.CleanInput(docSectionByItem.Include));
              
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(docSectionByItem.ItemCategory));
                command.Parameters.AddWithValue("@SOWSection", Utilitary.CleanInput(docSectionByItem.SOWSection));
               
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


        public int UpdateRecSource(DocSectionByItem docSectionByItem)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE DocSectionsByItem " +
                                                "SET RecSource = @RecSource, " +
                                                "RecSourceUpdatedDate = @RecSourceUpdatedDate " +
                                                "WHERE ItemCategory = @ItemCategory AND SOWSection = @SOWSection", new object[0]),
                    CommandType = CommandType.Text
                };

                command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(docSectionByItem.RecSource));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", docSectionByItem.RecSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(docSectionByItem.ItemCategory));
                command.Parameters.AddWithValue("@SOWSection", Utilitary.CleanInput(docSectionByItem.SOWSection));

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


        public int UpdateModSource(DocSectionByItem docSectionByItem)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE DocSectionsByItem " +
                                                "SET ModSource = @ModSource, " +
                                                "ModSourceUpdatedDate = @ModSourceUpdatedDate " +
                                                "WHERE ItemCategory = @ItemCategory AND SOWSection = @SOWSection", new object[0]),
                    CommandType = CommandType.Text
                };

                command.Parameters.AddWithValue("@ModSource", Utilitary.CleanInput(docSectionByItem.ModSource));
                command.Parameters.AddWithValue("@ModSourceUpdatedDate", docSectionByItem.ModSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(docSectionByItem.ItemCategory));
                command.Parameters.AddWithValue("@SOWSection", Utilitary.CleanInput(docSectionByItem.SOWSection));

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


        public int Delete(DocSectionByItem docSectionByItem) 
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE DocSectionsByItem " +
                                                "SET DeleteMarkDate = @DeleteMarkDate " +
                                                "WHERE ItemCategory = @ItemCategory AND SOWSection = @SOWSection", new object[0]),
                    CommandType = CommandType.Text
                };
                
                command.Parameters.AddWithValue("@DeleteMarkDate", docSectionByItem.DeleteMarkDate.Value.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@ItemCategory", Utilitary.CleanInput(docSectionByItem.ItemCategory));
                command.Parameters.AddWithValue("@SOWSection", Utilitary.CleanInput(docSectionByItem.SOWSection));
                
                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                int result = command.ExecuteNonQuery();
                base.CloseDbConnection();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<DocSectionByItem> Convert(DataTable dataTable)
        {
            List<DocSectionByItem> list = new List<DocSectionByItem>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Add(new DocSectionByItem()
                        {
                            ItemCategory = (row["ItemCategory"] != DBNull.Value) ? row["ItemCategory"].ToString() : string.Empty,
                            SOWSection = (row["SOWSection"] != DBNull.Value) ? row["SOWSection"].ToString() : string.Empty,
                            Include = (row["Include"] != DBNull.Value) ? row["Include"].ToString() : string.Empty,
                            RecSource = (row["RecSource"] != DBNull.Value) ? row["RecSource"].ToString() : string.Empty,
                            RecSourceUpdatedDate = string.IsNullOrEmpty(row["RecSourceUpdatedDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["RecSourceUpdatedDate"].ToString()),
                            ModSource = (row["ModSource"] != DBNull.Value) ? row["ModSource"].ToString() : string.Empty,
                            ModSourceUpdatedDate = string.IsNullOrEmpty(row["ModSourceUpdatedDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["ModSourceUpdatedDate"].ToString())
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
