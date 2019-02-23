using LibraryManager.Common;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public class DocTypeGroupDL : BaseDL
    {
        public DocTypeGroupDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public List<DocTypeGroup> GetAll()
        {
            List<DocTypeGroup> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT docTypeGroup.DocTypeGroup, COUNT(docTypesByDocTypeGroup.DocTypeGroup) AS AssociatedDocSectionTypes " +
                                     "FROM DocTypeGroups docTypeGroup " +
                                     "LEFT JOIN DocTypesByDocTypeGroup docTypesByDocTypeGroup ON docTypeGroup.DocTypeGroup = docTypesByDocTypeGroup.DocTypeGroup " +
                                     "GROUP BY docTypeGroup.DocTypeGroup", base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }


        public DocTypeGroup GetByName(string docTypeName)
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                string command = string.Format("SELECT docTypeGroup.DocTypeGroup, COUNT(docTypesByDocTypeGroup.DocTypeGroup) AS AssociatedDocSectionTypes " +
                                     "FROM DocTypeGroups docTypeGroup " +
                                     "LEFT JOIN DocTypesByDocTypeGroup docTypesByDocTypeGroup ON docTypeGroup.DocTypeGroup = docTypesByDocTypeGroup.DocTypeGroup " +
                                     "WHERE docTypeGroup.DocTypeGroup = '" + docTypeName + "' " +
                                     "GROUP BY docTypeGroup.DocTypeGroup",
                                     new object[0]);

                new OleDbDataAdapter(command, base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                return this.Convert(dataTable)
                    .FirstOrDefault();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }


        public int Add(DocTypeGroup docTypeGroup)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO DocTypeGroups(DocTypeGroup) " +
                                                "VALUES (@DocTypeGroup) ",
                                                new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DocTypeGroup", Utilitary.CleanInput(docTypeGroup.DocTypeGroupName));
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

        public int Update(DocTypeGroup docTypeGroup)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE DocTypeGroups " +
                                                "SET DocTypeGroup = @DocTypeGroup, " +
                                                "WHERE DocTypeGroup = @DocTypeGroup", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DocTypeGroup", Utilitary.CleanInput(docTypeGroup.DocTypeGroupName));


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

        public int Delete(string outputName)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("DELETE " +
                                                "FROM DocTypeGroups " +
                                                "WHERE DocTypeGroup = @DocTypeGroups", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DocTypeGroup", Utilitary.CleanInput(outputName));

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

        private List<DocTypeGroup> Convert(DataTable dataTable)
        {
            List<DocTypeGroup> list = new List<DocTypeGroup>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Add(new DocTypeGroup()
                        {
                            DocTypeGroupName = (row["DocTypeGroup"] != DBNull.Value) ? row["DocTypeGroup"].ToString() : string.Empty,
                            AssociatedDocSectionTypes = (row.Table.Columns.Contains("AssociatedDocSectionTypes") ? string.IsNullOrEmpty(row["AssociatedDocSectionTypes"].ToString()) ? 0 : Int32.Parse(row["AssociatedDocSectionTypes"].ToString()) : 0)
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
