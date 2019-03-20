using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class VendorContentController :  BaseController 
    {
        private VendorContentDL _vendorContentDL;

        public VendorContentController()
        {
            this._vendorContentDL = new VendorContentDL(base.DBConnectionPath)
            {
                DbPwd = base.DBPW
            };
        }

        public bool CheckIfVendorNameExist(string vendorName) 
        {
            try
            {
                VendorContent vendorContent = this._vendorContentDL.GetByName(vendorName);
                if (vendorContent != null) 
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

    }
}
