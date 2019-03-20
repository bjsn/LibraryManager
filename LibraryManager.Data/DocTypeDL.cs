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
    public class DocTypeDL : BaseDL
    {
        public DocTypeDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public List<DocType> GetAll()
        {
            List<DocType> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT DocType " +
                                     "FROM DocTypes " +
                                      "ORDER BY DocType;", base.DbConnection)
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


        public DocType GetByName(string docType)
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT DocType " +
                                     "FROM DocTypes " +
                                     "WHERE DocType = '" + Utilitary.CleanFileName(docType) + "' "+
                                      "ORDER BY DocType", base.DbConnection)
                                    .Fill(dataTable);

                base.CloseDbConnection();
                return this.Convert(dataTable).FirstOrDefault();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        public int Add(DocType docType) 
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO DocTypes(DocType) " +
                                                "VALUES (@DocType) ",
                                                new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DocType", Utilitary.CleanInput(docType.DocTypeName));

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

        public int Delete(DocType docType)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("DELETE " +
                                                "FROM DocTypes " +
                                                "WHERE DocType = @DocType", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DocType", Utilitary.CleanInput(docType.DocTypeName));

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

        
        private List<DocType> Convert(DataTable dataTable)
        {
            List<DocType> list = new List<DocType>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Add(new DocType()
                        {
                            DocTypeName = (row["DocType"] != DBNull.Value) ? row["DocType"].ToString() : string.Empty
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
