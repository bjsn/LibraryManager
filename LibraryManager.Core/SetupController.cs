using LibraryManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class SetupController : BaseController
    {
        private SetupDL setupDL;

        public SetupController(bool adminContent = true) : base(adminContent) 
        {
            this.setupDL = new SetupDL(base.DBConnectionPath)
            {
                DbPwd = base.DBPW
            };
        }


        public string GetClientName() 
        {
            try
            {
                return this.setupDL.GetClientName();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }
    }
}
