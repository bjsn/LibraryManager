using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class DocTypeGroupController: BaseController
    {
        private DocTypeGroupDL _docTypeGroupDL;
        private DocTypesByDocTypeGroupDL _docTypesByDocTypeGroupDL;

        public DocTypeGroupController()
            : base()
        {
            this._docTypeGroupDL = new DocTypeGroupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
            this._docTypesByDocTypeGroupDL = new DocTypesByDocTypeGroupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
        }

        public List<DocTypeGroup> GetAll() 
        {
            try
            {
                return _docTypeGroupDL.GetAll();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public DocTypeGroup GetByName(string docTypeGroupName)
        {
            try
            {
                return _docTypeGroupDL.GetByName(docTypeGroupName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool IsValidName(string docTypeGroupName) 
        {
            try
            {
                return _docTypeGroupDL.GetByName(docTypeGroupName) != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Add(string docTypeGroupName, List<string> docTypeList) 
        {
            try
            {
                DocTypeGroup docTypeGroup = new DocTypeGroup() 
                {
                    DocTypeGroupName = docTypeGroupName
                };
                this._docTypeGroupDL.Add(docTypeGroup);
                
                List<DocTypesByDocTypeGroup> docTypesByDocTypeGroupList = new List<DocTypesByDocTypeGroup>();
                foreach (var docSectionType in docTypeList) 
                {
                    docTypesByDocTypeGroupList.Add(new DocTypesByDocTypeGroup() 
                    {
                        DocType = docSectionType,
                        DocTypeGroupName = docTypeGroupName 
                    });
                }

                foreach (var docTypesByDocTypeGroup in docTypesByDocTypeGroupList)
                {
                    this._docTypesByDocTypeGroupDL.Add(docTypesByDocTypeGroup);
                }
                return 1;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(string docTypeGroupName, List<string> docTypeList) 
        {
            try
            {
                //delete old elements
                var docTypesByDocTypeGroupList = this._docTypesByDocTypeGroupDL.GetByDocTypeGroup(docTypeGroupName);
                foreach (var docTypesByDocTypeGroup in docTypesByDocTypeGroupList) 
                {
                    this._docTypesByDocTypeGroupDL.Delete(docTypesByDocTypeGroup);
                }
                
                List<DocTypesByDocTypeGroup> docTypesByDocTypeGroupNewList = new List<DocTypesByDocTypeGroup>();
                foreach (var docSectionType in docTypeList)
                {
                    docTypesByDocTypeGroupNewList.Add(new DocTypesByDocTypeGroup()
                    {
                        DocType = docSectionType,
                        DocTypeGroupName = docTypeGroupName
                    });
                }

                //add new references
                foreach (var docTypesByDocTypeGroup in docTypesByDocTypeGroupNewList)
                {
                    this._docTypesByDocTypeGroupDL.Add(docTypesByDocTypeGroup);
                }
                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Delete(string OutPutName) 
        {
            try
            {
                var docTypeByDocTypeGroupList = _docTypesByDocTypeGroupDL.GetByDocType(OutPutName);
                foreach (var docTypeByDocTypeGroup in docTypeByDocTypeGroupList) 
                {
                    this._docTypesByDocTypeGroupDL.Delete(docTypeByDocTypeGroup);
                }
                //delete elements in other table either
                return _docTypeGroupDL.Delete(OutPutName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
