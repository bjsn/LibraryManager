using LibraryManager.Data;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core
{
    public class DocTemplateController : BaseController
    {
        private DocTemplateDL _docTemplateDL;
        private FileController _fileController;
        private SetupController _setupController;

        public DocTemplateController()
            : base()
        {
            this._docTemplateDL = new DocTemplateDL(base.DBConnectionPath) { DbPwd = base.DBPW};
            this._fileController = new FileController();
            this._setupController = new SetupController();
        }

        public List<DocTemplate> Get() 
        {
            try
            {
                return this._docTemplateDL.GetAll();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public DocTemplate GetByName(string Name)
        {
            try
            {
                return this._docTemplateDL.GetByName(Name);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public bool IsTemplateNameValid(string templateName) 
        {
            try
            {
                return (this._docTemplateDL.GetByName(templateName) == null);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        public int Add(string templateName, string filePath) 
        {
            try
            {
                string clientName = this._setupController.GetClientName();
                byte[] word_doc = this._fileController.GetBinaryFile(filePath);
                DocTemplate docTemplate = new DocTemplate() 
                {
                    Template_Name = templateName, 
                    Word_Doc = word_doc,
                    RecSource = clientName,
                    RecSourceUpdatedDate = DateTime.Now
                };
                return this._docTemplateDL.Add(docTemplate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Update(string templateName, string filePath) 
        {
            try
            {
                DocTemplate docTemplate = this._docTemplateDL.GetByName(templateName);
                docTemplate.Word_Doc = this._fileController.GetBinaryFile(filePath);
                docTemplate.RecSourceUpdatedDate = DateTime.Now;
                return this._docTemplateDL.Update(docTemplate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Delete(string templateName)
        {
            try
            {
                return this._docTemplateDL.Delete(templateName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //move this to fileController
        public string GetDocTemplateFile(string sectionName)
        {
            try
            {
                byte[] docSectionFile = this._docTemplateDL.GetByName(sectionName).Word_Doc;
                return DownloadFileFromByteArray(sectionName, docSectionFile);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //move this to fileController
        private string DownloadFileFromByteArray(string templateName, byte[] fileBytes)
        {
            var tmpFile = Path.GetTempPath() + templateName;
            string filePath = "";
            try
            {
                filePath = TempPartFileFromByteArray(fileBytes, tmpFile + ".dot");
            }
            catch (Exception)
            {
                filePath = TempPartFileFromByteArray(fileBytes, tmpFile + ".dotx");
            }
            return filePath;
        }


        //move this to fileController
        private string TempPartFileFromByteArray(byte[] fileBytes, string tempFileSave)
        {
            string str;
            try
            {
                using (FileStream output = new FileStream(tempFileSave, FileMode.Create, FileAccess.ReadWrite))
                {
                    new BinaryWriter(output).Write(fileBytes);
                    str = tempFileSave;
                }
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return str;
        }


        //pending to implemente
        public int UpdateTemplateFile(string templateName, byte[] fileBynary)
        {
            try
            {
                string clientName = this._setupController.GetClientName();
                DocTemplate docTemplate = this._docTemplateDL.GetByName(templateName);
                docTemplate.Word_Doc = fileBynary;
                docTemplate.RecSource = clientName;
                docTemplate.RecSourceUpdatedDate = DateTime.Now;
                return this._docTemplateDL.Update(docTemplate);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

    }
}
