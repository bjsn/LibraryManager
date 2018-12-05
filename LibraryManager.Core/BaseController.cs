﻿using LibraryManager.Common;
using LibraryManager.Data;
using System;
using System.Configuration;
using System.Globalization;

namespace LibraryManager.Core
{
    public class BaseController
    {
        protected readonly string ProposalContentDBConnectionPath;
        protected readonly string DIRECTORY_ROOT;
        protected readonly string DIRECTORY_COMPANY;
        protected LibraryManager.Data.ProposalContentDL ProposalContentDL;
        protected string DBPW;
       

        public BaseController()
        {
            string regKey = ConfigurationManager.AppSettings["RegKey"].ToString(CultureInfo.InvariantCulture);
            string str3 = ConfigurationManager.AppSettings["DefaultSubKeyDir"].ToString(CultureInfo.InvariantCulture);
            this.DIRECTORY_ROOT = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["SubKeyDir"].ToString(CultureInfo.InvariantCulture));
            this.DIRECTORY_COMPANY = Utilitary.ReadValueFromRegistry(regKey, ConfigurationManager.AppSettings["Directory_Company"].ToString(CultureInfo.InvariantCulture));
            this.ProposalContentDBConnectionPath = str3 + ConfigurationManager.AppSettings["ProposalContentDB"].ToString(CultureInfo.InvariantCulture);
            this.DBPW = Utilitary.Decrypt(ConfigurationManager.AppSettings["dwpbd"].ToString(CultureInfo.InvariantCulture));
        }
    }
}

