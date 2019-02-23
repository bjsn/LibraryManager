using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class DocTypesByDocTypeGroupController : BaseController
    {
        private DocTypesByDocTypeGroupDL _docTypesByDocTypeGroupDL;

        public DocTypesByDocTypeGroupController()
            : base()
        {
            this._docTypesByDocTypeGroupDL = new DocTypesByDocTypeGroupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
        }

        public List<DocTypesByDocTypeGroup> GetAll()
        {
            try
            {
                return this._docTypesByDocTypeGroupDL.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<DocTypesByDocTypeGroup> GetByDocType(string DocType) 
        {
            try
            {
                return this._docTypesByDocTypeGroupDL.GetByDocTypeGroup(DocType);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


    }
}
