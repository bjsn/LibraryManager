namespace LibraryManager.Data
{
    using LibraryManager.Common;
    using LibraryManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;

    public class DocSectionDL : BaseDL
    {
        public DocSectionDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        private List<DocSection> Convert(DataTable dataTable)
        {
            List<DocSection> list = new List<DocSection>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row1 in dataTable.Rows)
                {
                    list.Add(new DocSection());
                }
            }
            return list;
        }

        public List<DocSection> GetAll()
        {
            List<DocSection> list;
            try
            {
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT Order_Number, Section_Name, Object_Type, DocType, Description, RecSource, ProductPicturePath, ProductPictureURL, MfgPartNumber, MfgName, DownloadDT, UserUpdDT FROM Section_tbl;", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                list = this.Convert(dataTable);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list;
        }

        public List<DocSection> GetByKeyWord(string keyWord)
        {
            List<DocSection> list;
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
    }
}

