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
    public class DocTypesByDocTypeGroupDL :  BaseDL
    {
        public DocTypesByDocTypeGroupDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public List<DocTypesByDocTypeGroup> GetAll()
        {
            List<DocTypesByDocTypeGroup> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT DocTypeGroup, DocType " +
                                     "FROM DocTypesByDocTypeGroup ", base.DbConnection)
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

        public List<DocTypesByDocTypeGroup> GetByDocTypeGroup(string DocType)
        {
            List<DocTypesByDocTypeGroup> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT DocTypeGroup, DocType " +
                                     "FROM DocTypesByDocTypeGroup " +
                                     "WHERE DocTypeGroup =  '" + DocType + "'", base.DbConnection)
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

        public int Add(DocTypesByDocTypeGroup docTypesByDocTypeGroup)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO DocTypesByDocTypeGroup(DocTypeGroup, DocType) " +
                                                "VALUES (@DocTypeGroup, @DocType) ",
                                                new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DocTypeGroup", Utilitary.CleanInput(docTypesByDocTypeGroup.DocTypeGroupName));
                command.Parameters.AddWithValue("@DocType", Utilitary.CleanInput(docTypesByDocTypeGroup.DocType));

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

        public int Delete(DocTypesByDocTypeGroup docTypesByDocTypeGroup)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("DELETE " +
                                                "FROM DocTypesByDocTypeGroup " +
                                                "WHERE DocTypeGroup = @DocTypeGroup AND DocType = @DocType", new object[0]),
                    CommandType = CommandType.Text
                };
                
                command.Parameters.AddWithValue("@DocTypeGroup", Utilitary.CleanInput(docTypesByDocTypeGroup.DocTypeGroupName));
                command.Parameters.AddWithValue("@DocType", Utilitary.CleanInput(docTypesByDocTypeGroup.DocType));

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

        private List<DocTypesByDocTypeGroup> Convert(DataTable dataTable)
        {
            List<DocTypesByDocTypeGroup> list = new List<DocTypesByDocTypeGroup>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Add(new DocTypesByDocTypeGroup()
                        {
                            DocTypeGroupName = (row["DocTypeGroup"] != DBNull.Value) ? row["DocTypeGroup"].ToString() : string.Empty,
                            DocType = (row["DocType"] != DBNull.Value) ? row["DocType"].ToString() : string.Empty
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
