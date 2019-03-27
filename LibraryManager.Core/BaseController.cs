using LibraryManager.Common;
using LibraryManager.Data;
using System;
using System.Configuration;
using System.Globalization;

namespace LibraryManager.Core
{
    public class BaseController
    {
        protected string DBConnectionPath;
        protected string DIRECTORY_ROOT;
        protected string DIRECTORY_COMPANY;
        protected string DBPW;
        protected bool AdminContent;

        public BaseController(bool requireAdminContent = true)
        {
            LoadContent(requireAdminContent);
        }

        private void LoadContent(bool requireAdminContent)
        {
            this.AdminContent = requireAdminContent;
            string regKey = ConfigurationManager.AppSettings["RegKey"].ToString(CultureInfo.InvariantCulture);
            string str3 = ConfigurationManager.AppSettings["DefaultSubKeyDir"].ToString(CultureInfo.InvariantCulture);

            this.DIRECTORY_ROOT = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["Directory_Root"].ToString(CultureInfo.InvariantCulture));
            this.DIRECTORY_COMPANY = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["Directory_Company"].ToString(CultureInfo.InvariantCulture));

            if (requireAdminContent)
            {
                this.DBConnectionPath = DIRECTORY_COMPANY + ConfigurationManager.AppSettings["PQDBDB"].ToString(CultureInfo.InvariantCulture);
            }
            else 
            {
                this.DBConnectionPath = DIRECTORY_ROOT + ConfigurationManager.AppSettings["ProposalContentDB"].ToString(CultureInfo.InvariantCulture);
            }
            this.DBPW = Utilitary.Decrypt(ConfigurationManager.AppSettings["dwpbd"].ToString(CultureInfo.InvariantCulture));
        }
    }
}

