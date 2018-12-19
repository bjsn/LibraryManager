using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public class SetupDL : BaseDL
    {
        public SetupDL(string connectionValue)
        {
            base.ConnectionValue = connectionValue;
        }

        public string GetClientName() 
        {
            try
            {
                string ClientName = "";
                base.OpenDbConnection();
                DataTable dataTable = new DataTable();
                new OleDbDataAdapter("SELECT ClientName FROM Setup;", base.DbConnection).Fill(dataTable);
                base.CloseDbConnection();
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ClientName = (row["ClientName"] != DBNull.Value) ? row["ClientName"].ToString() : string.Empty;
                        break;
                    }
                }
                return ClientName;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
    }
}
