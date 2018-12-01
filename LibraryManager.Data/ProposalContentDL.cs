﻿namespace LibraryManager.Data
{
    using LibraryManager.Common;
    using LibraryManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.Linq;

    public class ProposalContentDL : BaseDL
    {
        public ProposalContentDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        private List<ProposalContent> Convert(DataTable dataTable)
        {
            List<ProposalContent> list = new List<ProposalContent>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    ProposalContent item = new ProposalContent {
                        PartNumber = (row["PartNumber"] != DBNull.Value) ? row["PartNumber"].ToString() : string.Empty,
                        VendorName = (row["VendorName"] != DBNull.Value) ? row["VendorName"].ToString() : string.Empty,
                        ProductName = (row["ProductName"] != DBNull.Value) ? row["ProductName"].ToString() : string.Empty,
                        MarketingInfo = (row["MarketingInfo"] != DBNull.Value) ? row["MarketingInfo"].ToString() : string.Empty,
                        FeatureBullets = (row["FeatureBullets"] != DBNull.Value) ? row["FeatureBullets"].ToString() : string.Empty,
                        TechnicalInfo = (row["TechnicalInfo"] != DBNull.Value) ? row["TechnicalInfo"].ToString() : string.Empty,
                        ProductPicturePath = (row["ProductPicturePath"] != DBNull.Value) ? row["ProductPicturePath"].ToString() : string.Empty,
                        ProductPictureURL = (row["ProductPictureURL"] != DBNull.Value) ? row["ProductPictureURL"].ToString() : string.Empty,
                        MfgPartNumber = (row["MfgPartNumber"] != DBNull.Value) ? row["MfgPartNumber"].ToString() : string.Empty,
                        MfgName = (row["MfgName"] != DBNull.Value) ? row["MfgName"].ToString() : string.Empty,
                        DownloadDT = string.IsNullOrEmpty(row["DownloadDT"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["DownloadDT"].ToString()),
                        UserUpdDT = string.IsNullOrEmpty(row["UserUpdDT"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["UserUpdDT"].ToString())
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public void Create(ProposalContent proposalContent)
        {
            try
            {
                OleDbCommand command = new OleDbCommand {
                    CommandText = string.Format("INSERT INTO ProposalContentByPart(PartNumber, VendorName, ProductName, FeatureBullets, MarketingInfo, TechnicalInfo, ProductPicturePath, MfgPartNumber, MfgName, UserUpdDT) VALUES(@PartNumber, @VendorName, @ProductName, @FeatureBullets, @MarketingInfo, @TechnicalInfo, @ProductPicturePath, @MfgPartNumber, @MfgName, @UserUpdDT)", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@PartNumber", Utilitary.CleanInput(proposalContent.PartNumber));
                command.Parameters.AddWithValue("@VendorName", Utilitary.CleanInput(proposalContent.VendorName));
                command.Parameters.AddWithValue("@ProductName", Utilitary.CleanInput(proposalContent.ProductName));
                command.Parameters.AddWithValue("@FeatureBullets", proposalContent.FeatureBullets);
                command.Parameters.AddWithValue("@MarketingInfo", proposalContent.MarketingInfo);
                command.Parameters.AddWithValue("@TechnicalInfo", proposalContent.TechnicalInfo);
                command.Parameters.AddWithValue("@ProductPicturePath", proposalContent.ProductPicturePath);
                command.Parameters.AddWithValue("@MfgPartNumber", Utilitary.CleanInput(proposalContent.PartNumber));
                command.Parameters.AddWithValue("@MfgName", Utilitary.CleanInput(proposalContent.VendorName));
                command.Parameters.AddWithValue("@UserUpdDT", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
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

        public void Delete(string PartNumber)
        {
            try
            {
                base.OpenDbConnection();
                DataTable table1 = new DataTable();
                new OleDbCommand(string.Format("DELETE FROM ProposalContentByPart WHERE PartNumber = '{0}'", PartNumber), base.DbConnection).ExecuteNonQuery();
                base.CloseDbConnection();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        public List<ProposalContent> GetAll()
        {
            List<ProposalContent> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT PartNumber, VendorName, ProductName, FeatureBullets, MarketingInfo, TechnicalInfo, ProductPicturePath, ProductPictureURL, MfgPartNumber, MfgName, DownloadDT, UserUpdDT FROM ProposalContentByPart;", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }

        public List<ProposalContent> GetByKeyWord(string keyWord)
        {
            List<ProposalContent> list;
            try
            {
                keyWord = Utilitary.CleanInput(keyWord);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter(string.Format("SELECT PartNumber, VendorName, ProductName, FeatureBullets, MarketingInfo, TechnicalInfo, ProductPicturePath, ProductPictureURL, MfgPartNumber, MfgName, DownloadDT, UserUpdDT FROM ProposalContentByPart WHERE PartNumber LIKE '%{0}%' OR VendorName LIKE '%{0}%' OR ProductName LIKE '%{0}%'", keyWord), base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }

        public ProposalContent GetByPartNumber(string PartNumber)
        {
            ProposalContent content;
            try
            {
                PartNumber = Utilitary.CleanInput(PartNumber);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT PartNumber, VendorName, ProductName, FeatureBullets, MarketingInfo, TechnicalInfo, ProductPicturePath, ProductPictureURL, MfgPartNumber, MfgName, DownloadDT, UserUpdDT FROM ProposalContentByPart WHERE PartNumber = '" + PartNumber + "'", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                content = this.Convert(dataTable).FirstOrDefault<ProposalContent>();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return content;
        }

        public List<string> GetVendors()
        {
            List<string> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT VendorName FROM ProposalContentByPart GROUP BY VendorName ORDER BY VendorName", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = (from value in dataTable.Rows.OfType<DataRow>() select value[0].ToString()).ToList<string>();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }

        public void Update(ProposalContent proposalContent)
        {
            try
            {
                OleDbCommand command = new OleDbCommand {
                    CommandText = string.Format("Update ProposalContentByPart Set VendorName = @VendorName, ProductName = @ProductName, FeatureBullets = @FeatureBullets, MarketingInfo = @MarketingInfo, TechnicalInfo = @TechnicalInfo, ProductPicturePath =  @ProductPicturePath, MfgPartNumber = @MfgPartNumber, MfgName = @MfgName, UserUpdDT = @UserUpdDT Where PartNumber = @PartNumber", new object[0]),
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@VendorName", Utilitary.CleanInput(proposalContent.VendorName));
                command.Parameters.AddWithValue("@ProductName", Utilitary.CleanInput(proposalContent.ProductName));
                command.Parameters.AddWithValue("@FeatureBullets", proposalContent.FeatureBullets);
                command.Parameters.AddWithValue("@MarketingInfo", proposalContent.MarketingInfo);
                command.Parameters.AddWithValue("@TechnicalInfo", proposalContent.TechnicalInfo);
                command.Parameters.AddWithValue("@ProductPicturePath", proposalContent.ProductPicturePath);
                command.Parameters.AddWithValue("@MfgPartNumber", Utilitary.CleanInput(proposalContent.PartNumber));
                command.Parameters.AddWithValue("@MfgName", Utilitary.CleanInput(proposalContent.VendorName));
                command.Parameters.AddWithValue("@UserUpdDT", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                command.Parameters.AddWithValue("@PartNumber", proposalContent.PartNumber);
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
    }
}

