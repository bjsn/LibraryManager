namespace LibraryManager.Data
{
    using LibraryManager.Common;
    using LibraryManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.Linq;

    public class DocSectionDL : BaseDL
    {
        public DocSectionDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public List<DocSection> GetAll()
        {
            List<DocSection> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, RecSourceUpdatedDate, ModSource, ModSourceUpdatedDate " +
                                     "FROM Section_tbl " +
                                     "WHERE DeleteMarkDate IS NULL;", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
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


        public DocSection GetByName(string sectionName)
        {
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, RecSourceUpdatedDate, Word_Doc,  ModSource, ModSourceUpdatedDate FROM Section_tbl WHERE Section_Name = '" + sectionName + "' AND DeleteMarkDate IS NULL;", base.DbConnection).Fill(dataTable);
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
                byte[] docSectionFile = null;
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT Word_Doc FROM Section_tbl WHERE Section_Name = '{0}'", docSectionName), base.DbConnection).Fill(dataTable);
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
            List<DocSection> list;
            try
            {
                keyWord = Utilitary.CleanInput(keyWord);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, RecSourceUpdatedDate, Word_Doc, ModSource, ModSourceUpdatedDate FROM Section_tbl WHERE Section_Name LIKE '%{0}%' OR DocType LIKE '%{0}%' OR Description LIKE '%{0}%' ", keyWord), base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }


        public void UpdateSectionOrder(DocSection section)
        {
            try
            {
                if (section != null)
                {
                    OleDbCommand command = null;
                    command = new OleDbCommand
                    {
                        CommandText = string.Format("Update Section_tbl Set Order_Number = @Order_Number WHERE Section_Name = @Section_Name", new object[0]),
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@Order_Number", section.ReOrdered_Number);
                    command.Parameters.AddWithValue("@Section_Name", section.Section);

                    base.OpenDbConnection();
                    command.Connection = base.DbConnection;
                    command.ExecuteNonQuery();
                    base.CloseDbConnection();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateSectionFileDocRecSource(string sectionName, byte[] fileDoc) 
        {
            try
            {
                if (fileDoc != null) 
                {

                    OleDbCommand command = null;
                    command = new OleDbCommand
                    {
                        CommandText = string.Format("Update Section_tbl Set Word_Doc = @Word_Doc, RecSourceUpdatedDate = @RecSourceUpdatedDate WHERE Section_Name = @Section_Name", new object[0]),
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@Word_Doc", fileDoc);
                    command.Parameters.AddWithValue("@RecSourceUpdatedDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@Section_Name", sectionName);

                    base.OpenDbConnection();
                    command.Connection = base.DbConnection;
                    command.ExecuteNonQuery();
                    base.CloseDbConnection();
                }
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        public void UpdateSectionFileDeleteMarkDate(string sectionName)
        {
            try
            {
                OleDbCommand command = null;
                command = new OleDbCommand
                {
                    CommandText = string.Format("Update Section_tbl Set DeleteMarkDate = @DeleteMarkDate WHERE Section_Name = @Section_Name", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@DeleteMarkDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@Section_Name", sectionName);

                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                command.ExecuteNonQuery();
                base.CloseDbConnection();
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //update client name and date
        public void UpdateSectionFileDocModSource(string sectionName, byte[] fileDoc, string clientName)
        {
            try
            {
                if (fileDoc != null)
                {

                    OleDbCommand command = null;
                    command = new OleDbCommand
                    {
                        CommandText = string.Format("Update Section_tbl Set Word_Doc = @Word_Doc, ModSource = @ModSource, ModSourceUpdatedDate = @ModSourceUpdatedDate  WHERE Section_Name = @Section_Name", new object[0]),
                        CommandType = CommandType.Text
                    };
                    command.Parameters.AddWithValue("@Word_Doc", fileDoc);
                    command.Parameters.AddWithValue("@ModSource", clientName);
                    command.Parameters.AddWithValue("@ModSourceUpdatedDate", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    command.Parameters.AddWithValue("@Section_Name", sectionName);

                    base.OpenDbConnection();
                    command.Connection = base.DbConnection;
                    command.ExecuteNonQuery();
                    base.CloseDbConnection();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<DocSection> Convert(DataTable dataTable)
        {
            int c = 0;
            List<DocSection> list = new List<DocSection>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        c++;
                        double orderId = 0;
                        Double.TryParse(row["Order_Number"].ToString(), out orderId);
                        list.Add(new DocSection()
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
            list = list.OrderBy(x => x.Order).ToList();
            return list;
        }


        private List<double> ConvertIndexes(DataTable dataTable)
        {
            int c = 0;
            List<Double> list = new List<Double>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        c++;
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

