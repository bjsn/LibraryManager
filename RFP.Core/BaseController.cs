using LibraryManager.Common;
using RFP.Data;
using System;
using System.Configuration;
using System.Globalization;

namespace RFP.Core
{
    public class BaseController
    {
        protected readonly string DBConnectionPath;
        protected readonly string DIRECTORY_ROOT;
        protected readonly string DIRECTORY_COMPANY;
        protected readonly string SubDir_LocalDB;
        protected string DBPW;


        public BaseController()
        {
            string regKey = ConfigurationManager.AppSettings["RegKey"].ToString(CultureInfo.InvariantCulture);
            string str3 = ConfigurationManager.AppSettings["DefaultSubKeyDir"].ToString(CultureInfo.InvariantCulture);
            this.DIRECTORY_ROOT = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["SubKeyDir"].ToString(CultureInfo.InvariantCulture));
            this.DIRECTORY_COMPANY = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["Directory_Company"].ToString(CultureInfo.InvariantCulture));
            this.SubDir_LocalDB = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["SubDir_LocalDB"].ToString(CultureInfo.InvariantCulture));
            this.DBConnectionPath = str3 + SubDir_LocalDB;
            this.DBPW = Utilitary.Decrypt(ConfigurationManager.AppSettings["dwpbd"].ToString(CultureInfo.InvariantCulture));
        }

    }
}

