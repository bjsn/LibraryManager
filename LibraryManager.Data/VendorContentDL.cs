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
    public class VendorContentDL : BaseDL
    {
        public VendorContentDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public VendorContent GetByName(string vendorName) 
        {
            try
            {
                vendorName = Utilitary.CleanInput(vendorName);
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                
                //the query chages if the database is PQDB o proposalCOntent
                new OleDbDataAdapter(string.Format("SELECT VendorName, Comments, PricingUpdateDate, Status " +
                                     "FROM VendorContent " +
                                     "WHERE (Status <> '{0}' OR Status IS NULL) AND VendorName = '{1}';", 
                                     "Remove", vendorName),  base.DbConnection)
                                    .Fill(dataTable);
                base.CloseDbConnection();
                return Convert(dataTable)
                      .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<VendorContent> Convert(DataTable dataTable)
        {
            List<VendorContent> list = new List<VendorContent>();
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        list.Add(new VendorContent()
                        {
                            VendorName = (row["VendorName"] != DBNull.Value) ? row["VendorName"].ToString() : string.Empty,
                            Comments = (row["Comments"] != DBNull.Value) ? row["Comments"].ToString() : string.Empty,
                            PricingUpdateDate = string.IsNullOrEmpty(row["PricingUpdateDate"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["PricingUpdateDate"].ToString()),
                            Status = (row["Status"] != DBNull.Value) ? row["Status"].ToString() : string.Empty
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
