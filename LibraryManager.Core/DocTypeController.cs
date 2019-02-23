using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class DocTypeController : BaseController
    {
        private DocTypeDL _docTypeDL;
        private DocTypesByDocTypeGroupDL _docTypesByDocTypeGroupDL;

        public DocTypeController() : base()
        {
            this._docTypeDL = new DocTypeDL(base.DBConnectionPath) { DbPwd = base.DBPW };
            this._docTypesByDocTypeGroupDL = new DocTypesByDocTypeGroupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
        }

        public List<DocType> GetAll() 
        {
            try
            {
                return this._docTypeDL.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DocType GetByName(string docTypeName)
        {
            try
            {
                return this._docTypeDL.GetByName(docTypeName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool IsValidName(string docTypeName)
        {
            try
            {
                return (this._docTypeDL.GetByName(docTypeName) == null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Add(string docTypeName)
        {
            try
            {
                DocType docType = new DocType()
                {
                    DocTypeName = docTypeName
                };
                return this._docTypeDL.Add(docType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public int AddWithDocTypesByDocTypeGroup(string docTypeName, List<string> docSectionTypeList)
        //{
        //    try
        //    {
        //        DocType docType = new DocType()
        //        {
        //            DocTypeName = docTypeName
        //        };
        //        this._docTypeDL.Add(docType);

        //        List<DocTypesByDocTypeGroup> docTypesByDocTypeGroupList = new List<DocTypesByDocTypeGroup>();
        //        foreach (var docSectionType in docSectionTypeList)
        //        {
        //            docTypesByDocTypeGroupList.Add(new DocTypesByDocTypeGroup()
        //            {
        //                DocType = docTypeName,
        //                DocTypeGroupName = docSectionType
        //            });
        //        }

        //        foreach (var docTypesByDocTypeGroup in docTypesByDocTypeGroupList)
        //        {
        //            this._docTypesByDocTypeGroupDL.Add(docTypesByDocTypeGroup);
        //        }
        //        return 1;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public int Delete(string docTypeName) 
        {
            try
            {
                DocType docType = new DocType() 
                {
                    DocTypeName = docTypeName
                };
                _docTypeDL.Delete(docType);
                return this._docTypeDL.Delete(docType);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
