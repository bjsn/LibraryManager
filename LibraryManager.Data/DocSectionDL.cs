using LibraryManager.Common;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;

namespace LibraryManager.Data
{
    public class DocSectionDL : BaseDL
    {
        public DocSectionDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }


        public List<DocSection> GetAll()
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, RecSourceUpdatedDate, ModSource, ModSourceUpdatedDate " +
                                     "FROM Section_tbl " +
                                     "WHERE DeleteMarkDate IS NULL;", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                return this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
           
        }


        public List<Double> GetAllIndexes()
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Order_Number " +
                                     "FROM Section_tbl " + 
                                     "WHERE DeleteMarkDate IS NULL " +
                                     "ORDER BY Order_Number;", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                return this.ConvertIndexes(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }


        public double GetLastSectionOrder_Number() 
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT TOP 1 Order_Number " +
                                     "FROM Section_tbl " + 
                                     "WHERE DeleteMarkDate IS NULL " +
                                     "ORDER BY Order_Number Desc;", base.DbConnection)
                                     .Fill(dataTable);
                base.CloseDbConnection();
                return this.ConvertIndexes(dataTable).FirstOrDefault();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public DocSection GetByName(string sectionName)
        {
            try
            {
                sectionName = Utilitary.CleanInput(sectionName);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, RecSourceUpdatedDate, Word_Doc,  ModSource, ModSourceUpdatedDate " + 
                                     "FROM Section_tbl " + 
                                     "WHERE Section_Name = '" + sectionName + "' AND DeleteMarkDate IS NULL;", base.DbConnection)
                                     .Fill(dataTable);
                base.CloseDbConnection();
                return this.Convert(dataTable).FirstOrDefault();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }


        public byte[] GetDocSectionFile(string docSectionName) 
        {
            try
            {
                docSectionName = Utilitary.CleanInput(docSectionName);
                byte[] docSectionFile = null;
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT Word_Doc " + 
                                                   "FROM Section_tbl " +
                                                   "WHERE Section_Name = '{0}'", docSectionName), base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        docSectionFile = !string.IsNullOrEmpty(row["Word_Doc"].ToString()) ? (byte[])row["Word_Doc"] : null;
                        break;
                    }
                }
                return docSectionFile;
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }


        public List<DocSection> GetByKeyWord(string keyWord)
        {
            try
            {
                keyWord = Utilitary.CleanInput(keyWord);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, RecSourceUpdatedDate, Word_Doc, ModSource, ModSourceUpdatedDate  " + 
                                                   "FROM Section_tbl " + 
                                                   "WHERE Section_Name LIKE '%{0}%' OR DocType LIKE '%{0}%' OR Description LIKE '%{0}%' ", keyWord), base.DbConnection)
                                                   .Fill(dataTable);
                base.CloseDbConnection();
                return this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }


        public int UpdateSectionOrder(DocSection section)
        {
            try
            {
                if (section != null)
                {
                    OleDbCommand command = null;
                    command = new OleDbCommand
                    {
                        CommandText = string.Format("UPDATE Section_tbl  " + 
                                                    "SET Order_Number = @Order_Number " + 
                                                    "WHERE Section_Name = @Section_Name", new object[0]),
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@Order_Number", section.ReOrdered_Number);
                    command.Parameters.AddWithValue("@Section_Name", section.Section);

                    base.OpenDbConnection();
                    command.Connection = base.DbConnection;
                    int result = command.ExecuteNonQuery();
                    base.CloseDbConnection();
                    return result;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Add(DocSection docSection) 
        {
            try 
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("INSERT INTO Section_tbl(Section_Name, Order_Number, Object_Type, DocType, Word_Doc, Keep_Style, Description, RecSource, RecSourceUpdatedDate)" +
                                                "VALUES (@Section_Name, @Order_Number, @Object_Type, @DocType, @Word_Doc, @Keep_Style, @Description, @RecSource, @RecSourceUpdatedDate) ", 
                                                new object[0]),
                    CommandType = CommandType.Text
                };


                byte[] fileStream = new byte[0];
                command.Parameters.AddWithValue("@Section_Name", Utilitary.CleanInput(docSection.Section));
                command.Parameters.AddWithValue("@Order_Number", Utilitary.CleanInput(docSection.Order.ToString()));
                command.Parameters.AddWithValue("@Object_Type", Utilitary.CleanInput(docSection.Location));
                command.Parameters.AddWithValue("@DocType", Utilitary.CleanInput(docSection.DocType));
                command.Parameters.AddWithValue("@Word_Doc", docSection.WordDoc);
                command.Parameters.AddWithValue("@Keep_Style", Utilitary.CleanInput(docSection.KeepStyle));
                command.Parameters.AddWithValue("@Description", Utilitary.CleanInput(docSection.Description));
                command.Parameters.AddWithValue("@RecSource", Utilitary.CleanInput(docSection.RecSource));
                command.Parameters.AddWithValue("@RecSourceUpdatedDate", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));

                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                int result = command.ExecuteNonQuery();
                base.CloseDbConnection();
                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Update(DocSection docSection)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE Section_tbl " +
                                                "SET Object_Type = @Object_Type, " +
                                                "DocType = @DocType, " +
                                                "Description = @Description, " +
                                                "Word_Doc = @Word_Doc, " +
                                                "ModSource = @ModSource, " +
                                                "ModSourceUpdatedDate = @ModSourceUpdatedDate " +
                                                "WHERE Section_Name = @Section_Name", new object[0]),
                    CommandType = CommandType.Text
                };
              
                byte[] fileStream = new byte[0];
                command.Parameters.AddWithValue("@Object_Type", Utilitary.CleanInput(docSection.Location));
                command.Parameters.AddWithValue("@DocType", Utilitary.CleanInput(docSection.DocType));
                command.Parameters.AddWithValue("@Description", Utilitary.CleanInput(docSection.Description));
                command.Parameters.AddWithValue("@Word_Doc", docSection.WordDoc);
                command.Parameters.AddWithValue("@ModSource", Utilitary.CleanInput(docSection.ModSource));
                command.Parameters.AddWithValue("@ModSourceUpdatedDate", docSection.ModSourceUpdatedDate.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@Section_Name", Utilitary.CleanInput(docSection.Section));
     
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


        public int UpdateSectionFileDocRecSource(string sectionName, byte[] fileDoc) 
        {
            try
            {
                if (fileDoc != null) 
                {
                    OleDbCommand command = null;
                    command = new OleDbCommand
                    {
                        CommandText = string.Format("UPDATE Section_tbl " +
                                                    "SET Word_Doc = @Word_Doc, " + 
                                                    "RecSourceUpdatedDate = @RecSourceUpdatedDate "+
                                                    "WHERE Section_Name = @Section_Name", new object[0]),
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@Word_Doc", fileDoc);
                    command.Parameters.AddWithValue("@RecSourceUpdatedDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@Section_Name", sectionName);

                    base.OpenDbConnection();
                    command.Connection = base.DbConnection;
                    int result = command.ExecuteNonQuery();
                    base.CloseDbConnection();
                    return result;
                }
                return 0;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public int UpdateSectionFileDeleteMarkDate(string sectionName)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("UPDATE Section_tbl " + 
                                                "SET DeleteMarkDate = @DeleteMarkDate " +
                                                "WHERE Section_Name = @Section_Name", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DeleteMarkDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@Section_Name", sectionName);

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


        public int UpdateSectionFileDocModSource(string sectionName, byte[] fileDoc, string clientName)
        {
            try
            {
                if (fileDoc != null)
                {
                    OleDbCommand command = null;
                    command = new OleDbCommand
                    {
                        CommandText = string.Format("UPDATE Section_tbl " + 
                                                    "SET Word_Doc = @Word_Doc,"+ 
                                                        "ModSource = @ModSource, " + 
                                                        "ModSourceUpdatedDate = @ModSourceUpdatedDate " + 
                                                    "WHERE Section_Name = @Section_Name", new object[0]),
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@Word_Doc", fileDoc);
                    command.Parameters.AddWithValue("@ModSource", clientName);
                    command.Parameters.AddWithValue("@ModSourceUpdatedDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@Section_Name", sectionName);

                    base.OpenDbConnection();
                    command.Connection = base.DbConnection;
                    int result = command.ExecuteNonQuery();
                    base.CloseDbConnection();
                    return result;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<DocSection> Convert(DataTable dataTable)
        {
            
            List<DocSection> listDocSection = new List<DocSection>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        double orderId = 0;
                        Double.TryParse(row["Order_Number"].ToString(), out orderId);
                        listDocSection.Add(new DocSection()
                        {
                            Order = orderId,
                            Section = (row["Section_Name"] != DBNull.Value) ? row["Section_Name"].ToString() : string.Empty,
                            Location = (row["Object_Type"] != DBNull.Value) ? row["Object_Type"].ToString() : string.Empty,
                            DocType = (row["DocType"] != DBNull.Value) ? row["DocType"].ToString() : string.Empty,
                            Description = (row["Description"] != DBNull.Value) ? row["Description"].ToString() : string.Empty,
                            RecSource = (row["RecSource"] != DBNull.Value) ? row["RecSource"].ToString() : string.Empty,
                            UpdatedDT = string.IsNullOrEmpty(row["RecSourceUpdatedDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["RecSourceUpdatedDate"].ToString()),
                            UpdatedBy = (row["ModSource"] != DBNull.Value) ? row["ModSource"].ToString() : string.Empty,
                            ClientUpdatedDT = string.IsNullOrEmpty(row["ModSourceUpdatedDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["ModSourceUpdatedDate"].ToString()),
                        });
                    }
                }
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            listDocSection = listDocSection.OrderBy(x => x.Order).ToList();
            return listDocSection;
        }


        private List<double> ConvertIndexes(DataTable dataTable)
        {
            List<Double> list = new List<Double>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        double orderId = 0;
                        Double.TryParse(row["Order_Number"].ToString(), out orderId);
                        list.Add(orderId);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            list = list.OrderBy(x => x).ToList();
            return list;
        }

    }
}

