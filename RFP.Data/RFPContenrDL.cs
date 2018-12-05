namespace RFP.Data
{
    using LibraryManager.Common;
    using RFP.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class RFPContentDL : BaseDL
    {

        
        public RFPContentDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
          
        }

        /// <summary>
        /// check here
        /// </summary>
        /// <returns></returns>
        public List<RFPContent> GetAll()
        {
            List<RFPContent> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ID, Name, Description, Keywords, Content, CreateDT, UpdateDT, UpdatedBy, FileData FROM RFPContent;", base.DbConnection)
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


        public void UpdateRFPByID(int RFPID, string stringContent, byte[] ByteDocx)
        {
            try
            {
                OleDbCommand command = new OleDbCommand
                {
                    CommandText = string.Format("Update RFPContent Set Content = @Content, UpdateDT = @UpdateDT, FileData = @FileData Where ID = @ID", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@Content", stringContent);
                command.Parameters.AddWithValue("@UpdateDT", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@FileData", ByteDocx);
                command.Parameters.AddWithValue("@ID", RFPID);

                base.OpenDbConnection();
                command.Connection = base.DbConnection;
                command.ExecuteNonQuery();
                base.CloseDbConnection();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="rfpContent"></param>
        public void Create(RFPContent rfpContent)
        {
            try
            {
                //OleDbCommand command = new OleDbCommand {
                //    CommandText = string.Format("INSERT INTO ProposalContentByPart(PartNumber, VendorName, ProductName, FeatureBullets, MarketingInfo, TechnicalInfo, ProductPicturePath, MfgPartNumber, MfgName, UserUpdDT) VALUES(@PartNumber, @VendorName, @ProductName, @FeatureBullets, @MarketingInfo, @TechnicalInfo, @ProductPicturePath, @MfgPartNumber, @MfgName, @UserUpdDT)", new object[0]),
                //    CommandType = CommandType.Text
                //};
                //command.Parameters.AddWithValue("@PartNumber", Utilitary.CleanInput(proposalContent.PartNumber));
                //command.Parameters.AddWithValue("@VendorName", Utilitary.CleanInput(proposalContent.VendorName));
                //command.Parameters.AddWithValue("@ProductName", Utilitary.CleanInput(proposalContent.ProductName));
                //command.Parameters.AddWithValue("@FeatureBullets", proposalContent.FeatureBullets);
                //command.Parameters.AddWithValue("@MarketingInfo", proposalContent.MarketingInfo);
                //command.Parameters.AddWithValue("@TechnicalInfo", proposalContent.TechnicalInfo);
                //command.Parameters.AddWithValue("@ProductPicturePath", proposalContent.ProductPicturePath);
                //command.Parameters.AddWithValue("@MfgPartNumber", Utilitary.CleanInput(proposalContent.PartNumber));
                //command.Parameters.AddWithValue("@MfgName", Utilitary.CleanInput(proposalContent.VendorName));
                //command.Parameters.AddWithValue("@UserUpdDT", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                //base.OpenDbConnection();
                //command.Connection = base.DbConnection;
                //command.ExecuteNonQuery();
                //base.CloseDbConnection();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="PartNumber"></param>
        public void Delete(string PartNumber)
        {
            try
            {
                //base.OpenDbConnection();
                //DataTable table1 = new DataTable();
                //new OleDbCommand(string.Format("DELETE FROM ProposalContentByPart WHERE PartNumber = '{0}'", PartNumber), base.DbConnection).ExecuteNonQuery();
                //base.CloseDbConnection();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

       

        /// <summary>
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public List<RFPContent> GetByKeyWord(string keyWord)
        {
            List<RFPContent> list;
            try
            {
                keyWord = Utilitary.CleanInput(keyWord);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT ID, Name, Description, Keywords, Content, CreateDT, UpdateDT, UpdatedBy, FileData FROM RFPContent WHERE Name LIKE '%{0}%' OR Description LIKE '%{0}%' OR Keywords LIKE '%{0}%' OR Content LIKE '%{0}%'", keyWord), base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }

        /// <summary>
        /// </summary>
        /// <param name="PartNumber"></param>
        /// <returns></returns>
        public RFPContent GetBySomething(string PartNumber)
        {
            RFPContent content;
            try
            {
                PartNumber = Utilitary.CleanInput(PartNumber);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT PartNumber, VendorName, ProductName, FeatureBullets, MarketingInfo, TechnicalInfo, ProductPicturePath, ProductPictureURL, MfgPartNumber, MfgName, DownloadDT, UserUpdDT FROM ProposalContentByPart WHERE PartNumber = '" + PartNumber + "'", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                content = this.Convert(dataTable).FirstOrDefault<RFPContent>();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return content;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<string> GetVendors()
        {
            List<string> list = null;
            try
            {
                //base.OpenDbConnection();
                //DataTable dataTable = new DataTable();
                //new OleDbDataAdapter("SELECT VendorName FROM ProposalContentByPart GROUP BY VendorName ORDER BY VendorName", base.DbConnection).Fill(dataTable);
                //base.CloseDbConnection();
                //list = (from value in dataTable.Rows.OfType<DataRow>() select value[0].ToString()).ToList<string>();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }

        /// <summary>
        /// </summary>
        /// <param name="proposalContent"></param>
        public void Update(RFPContent proposalContent)
        {
            try
            {
                //OleDbCommand command = new OleDbCommand {
                //    CommandText = string.Format("Update ProposalContentByPart Set VendorName = @VendorName, ProductName = @ProductName, FeatureBullets = @FeatureBullets, MarketingInfo = @MarketingInfo, TechnicalInfo = @TechnicalInfo, ProductPicturePath =  @ProductPicturePath, MfgPartNumber = @MfgPartNumber, MfgName = @MfgName, UserUpdDT = @UserUpdDT Where PartNumber = @PartNumber", new object[0]),
                //    CommandType = CommandType.Text
                //};
                ////command.Parameters.AddWithValue("@VendorName", Utilitary.CleanInput(proposalContent.VendorName));
                ////command.Parameters.AddWithValue("@ProductName", Utilitary.CleanInput(proposalContent.ProductName));
                ////command.Parameters.AddWithValue("@FeatureBullets", proposalContent.FeatureBullets);
                ////command.Parameters.AddWithValue("@MarketingInfo", proposalContent.MarketingInfo);
                ////command.Parameters.AddWithValue("@TechnicalInfo", proposalContent.TechnicalInfo);
                ////command.Parameters.AddWithValue("@ProductPicturePath", proposalContent.ProductPicturePath);
                ////command.Parameters.AddWithValue("@MfgPartNumber", Utilitary.CleanInput(proposalContent.PartNumber));
                ////command.Parameters.AddWithValue("@MfgName", Utilitary.CleanInput(proposalContent.VendorName));
                ////command.Parameters.AddWithValue("@UserUpdDT", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                ////command.Parameters.AddWithValue("@PartNumber", proposalContent.PartNumber);
                //base.OpenDbConnection();
                //command.Connection = base.DbConnection;
                //command.ExecuteNonQuery();
                //base.CloseDbConnection();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<RFPContent> Convert(DataTable dataTable)
        {
            List<RFPContent> list = new List<RFPContent>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    RFPContent item = new RFPContent
                    {
                        ID = (row["ID"] != DBNull.Value) ? Int32.Parse(row["ID"].ToString()) : 0,
                        Name = (row["Name"] != DBNull.Value) ? row["Name"].ToString() : string.Empty,
                        Description = (row["Description"] != DBNull.Value) ? row["Description"].ToString() : string.Empty,
                        Keywords = (row["Keywords"] != DBNull.Value) ? row["Keywords"].ToString() : string.Empty,
                        Content = (row["Content"] != DBNull.Value) ? row["Content"].ToString() : string.Empty,
                        CreateDT = string.IsNullOrEmpty(row["CreateDT"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["CreateDT"].ToString()),
                        UpdateDT = string.IsNullOrEmpty(row["UpdateDT"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["UpdateDT"].ToString()),
                        UpdatedBy = (row["Content"] != DBNull.Value) ? row["Content"].ToString() : string.Empty,
                        FileData = (row["FileData"] != DBNull.Value) ? Encoding.UTF8.GetBytes(row["FileData"].ToString()) : null
                    };
                    list.Add(item);
                }
            }
            return list;
        }
    }
}

