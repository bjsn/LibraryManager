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
    public class DocTemplateDL : BaseDL
    {

        public DocTemplateDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }


        public List<DocTemplate> GetAll() 
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Template_Name, RecSource, RecSourceUpdatedDate " +
                                     "FROM  Temp_tbl " +
                                      "ORDER BY Template_Name", base.DbConnection)
                                     .Fill(dataTable);
                base.CloseDbConnection();
                return this.Convert(dataTable);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        public DocTemplate GetByName(string templateName) 
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Template_Name, Word_Doc, RecSource, RecSourceUpdatedDate " +
                                     "FROM  Temp_tbl " +
                                     "WHERE Template_Name = '"+ Utilitary.CleanInput(templateName) + "' "+
                                     "ORDER BY Template_Name", base.DbConnection)
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


        public int Add(DocTemplate docTemplate) 
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO Temp_tbl(Template_Name, Word_Doc, RecSource, RecSourceUpdatedDate) " +
                                                "VALUES (@Template_Name, @Word_Doc, @RecSource, @RecSourceUpdatedDate) ",
                                                new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@Template_Name", Utilitary.CleanInput(docTemplate.Template_Name));
                command.Parameters.AddWithValue("@Word_Doc", docTemplate.Word_Doc);
                command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(docTemplate.RecSource));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", docTemplate.RecSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));

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


        public int Update(DocTemplate docTemplate) 
        {
            try
            {
                OleDbCommand command = null;
                 command = new OleDbCommand
                 {
                     CommandText = string.Format("UPDATE Temp_tbl " +
                                                 "SET Word_Doc = @Word_Doc, " +
                                                 "RecSource = @RecSource, " +
                                                 "RecSourceUpdatedDate = @RecSourceUpdatedDate " +
                                                 "WHERE Template_Name = @Template_Name", new object[0]),
                     CommandType = CommandType.Text
                 };
                 command.Parameters.AddWithValue("@Word_Doc", docTemplate.Word_Doc);
                 command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(docTemplate.RecSource));
                 command.Parameters.AddWithValue("@RecSourceUpdatedDate", docTemplate.RecSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));
                 command.Parameters.AddWithValue("@Template_Name", Utilitary.CleanInput(docTemplate.Template_Name));

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


        public int Delete(string templateName) 
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("DELETE " + 
                                                "FROM Temp_tbl " +
                                                "WHERE Template_Name = @Template_Name", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@Template_Name", Utilitary.CleanInput(templateName));

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

        private List<DocTemplate> Convert(DataTable dataTable) 
        {
            try
            {
                List<DocTemplate> docTemplateList = new List<DocTemplate>();
                if (dataTable.Rows.Count > 0) 
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        docTemplateList.Add(new DocTemplate() 
                        {
                            Template_Name = (row["Template_Name"] != DBNull.Value) ? row["Template_Name"].ToString() : string.Empty,
                            Word_Doc = row.Table.Columns.Contains("Word_Doc") ? (string.IsNullOrEmpty(row["Word_Doc"].ToString()) ? null : (byte[])row["Word_Doc"]) : null,
                            RecSource = (row["RecSource"] != DBNull.Value) ? row["RecSource"].ToString() : string.Empty,
                            RecSourceUpdatedDate = string.IsNullOrEmpty(row["RecSourceUpdatedDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["RecSourceUpdatedDate"].ToString()),
                        });
                    }
                }
                return docTemplateList;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

    }
}
