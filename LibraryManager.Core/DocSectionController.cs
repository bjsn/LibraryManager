﻿using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LibraryManager.Core
{
    public class DocSectionController : BaseController
    {
        private FileController _fileController;
        private DocSectionDL docSectionDL;
        private DocSectionsByItemDL _docSectionsByItemDL;
        private SetupController _setupController;

        public DocSectionController(bool adminContent = true) : base(adminContent) 
        {
            this.docSectionDL = new DocSectionDL(base.DBConnectionPath) { DbPwd = base.DBPW };
            this._docSectionsByItemDL = new DocSectionsByItemDL(base.DBConnectionPath) { DbPwd = base.DBPW };
            this._setupController = new SetupController();

            this._fileController = new FileController();
        }

        public List<DocSection> GetAll() 
        {
            try
            {
                return this.docSectionDL.GetAll();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public List<double> GetAllIndexes()
        {
            try
            {
                return this.docSectionDL.GetAllIndexes();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DocSection GetByName(string docSectionName)
        {
            try
            {
                return this.docSectionDL.GetByName(docSectionName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<DocSection> GetByKeyWord(string keyWord)
        {
            try
            {
                return this.docSectionDL.GetByKeyWord(keyWord);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<DocSectionByItem> GetSectionsByItemCategory(string categoryName) 
        {
            try
            {
                return this._docSectionsByItemDL.GetByItemCategory(categoryName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int AddEditDocSectionsByItem(string itemCategoryName, Dictionary<string, string> docSectionList) 
        {
            try
            {
                var clientName = this._setupController.GetClientName();
                var savedSectionItemList = this._docSectionsByItemDL.GetByItemCategory(itemCategoryName);
                
                foreach (var docSectionItem in docSectionList) 
                {
                    DocSectionByItem docSectionByItem = new DocSectionByItem()
                    {
                        ItemCategory = itemCategoryName,
                        SOWSection = docSectionItem.Key,
                        Include = docSectionItem.Value,
                        RecSource = clientName,
                        RecSourceUpdatedDate = DateTime.Now
                    };

                    var savedSectionItem = savedSectionItemList.Where(x => x.SOWSection.Equals(docSectionByItem.SOWSection)).FirstOrDefault();
                    if (savedSectionItem == null)
                    {
                        //insert 
                        int result = this._docSectionsByItemDL.Add(docSectionByItem);
                    }
                    else 
                    {
                        //update
                        if (!savedSectionItem.Include.Equals(docSectionByItem.Include)) 
                        {
                            int result = this._docSectionsByItemDL.Update(docSectionByItem);
                        }
                    }
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int DeleteDocSectionByItem(string itemCategoryName, List<string> docSectionList) 
        {
            try
            {
                foreach (var deletedDocSection in docSectionList) 
                {
                    this._docSectionsByItemDL.Delete(itemCategoryName, deletedDocSection);
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ValidDocSectionName(string docSectionName) 
        {
            try
            {
                return this.docSectionDL.GetByName(docSectionName) == null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ReIndexAllSections(List<double> FullSectionIndexListWithNewOrder) 
        {
            try
            {
                List<DocSection> SectionList = this.docSectionDL.GetAll();
                List<DocSection> ReorderedList = new List<DocSection>();
                for (int i = 0; i < FullSectionIndexListWithNewOrder.Count; i++) 
                {
                    DocSection SectionByIndex = SectionList.Where(x => x.Order == FullSectionIndexListWithNewOrder[i]).FirstOrDefault();
                    if (SectionByIndex != null && SectionByIndex.Order != ((double)i + 1))
                    {
                        SectionByIndex.ReOrdered_Number = (double)i + 1;
                        ReorderedList.Add(SectionByIndex);
                    }
                }

                foreach (var section in ReorderedList)
                {
                    this.docSectionDL.UpdateSectionOrder(section);
                }
            }
            catch (Exception e)
            {
            }
        }

        public bool IsDocSectionNameValid(string sectionName) 
        {
            try
            {
                var DocSection = this.docSectionDL.GetByName(sectionName);
                return (DocSection == null);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public int Add(string sectionName, string locationType, string docLocation, string documentType, string description)
        {
            try
            {
                SetupDL setupDL = new SetupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
                string clientName = setupDL.GetClientName();
                DocSection docSection = new DocSection() 
                {
                    Order = this.docSectionDL.GetLastSectionOrder_Number() + 1,
                    Section = sectionName,
                    Location = locationType,
                    DocType = documentType,
                    KeepStyle = "Yes",
                    Description = description,
                    WordDoc = (string.IsNullOrEmpty(docLocation) ? null : _fileController.GetBinaryFile(docLocation)),
                    RecSource = clientName,
                    RecSourceUpdateDate = DateTime.Now
                };
                return this.docSectionDL.Add(docSection);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(string sectionName, string locationType, string docLocation, string documentType, string description)
        {
            try
            {
                SetupDL setupDL = new SetupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
                string clientName = setupDL.GetClientName();

                DocSection savedSection = this.docSectionDL.GetByName(sectionName);

                DocSection updatedSection = new DocSection()
                {
                    Section = sectionName,
                    Location = locationType,
                    DocType = documentType,
                    Description = description,
                    WordDoc = (string.IsNullOrEmpty(docLocation) ? null : _fileController.GetBinaryFile(docLocation)),
                    ModSource = clientName,
                    ModSourceUpdatedDate = DateTime.Now
                };
                bool documentUpdated = false;

                //if there is any update
                byte[] originalDoc = this.docSectionDL.GetDocSectionFile(updatedSection.Section);
                if (updatedSection.WordDoc == null)
                {
                    updatedSection.WordDoc = originalDoc;
                }
                else if (!_fileController.AreFilesEqual(updatedSection.WordDoc, originalDoc))
                {
                    documentUpdated = true;
                }

                this.docSectionDL.Update(updatedSection);

                if (documentUpdated) 
                {
                    if (clientName.Equals(savedSection.RecSource))
                    {
                        updatedSection.RecSource = clientName;
                        this.docSectionDL.UpdateRecSource(updatedSection);
                    }
                    else 
                    {
                        updatedSection.ModSource = clientName;
                        this.docSectionDL.UpdateModSource(updatedSection);
                    }
                }
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            return 0;
        }

        public void UpdateSectionFile(string sectionName, byte[] fileUpdated) 
        {
            try
            {
                SetupDL setupDL = new SetupDL(base.DBConnectionPath) { DbPwd = base.DBPW };
                string clientName = setupDL.GetClientName();

                DocSection section = this.docSectionDL.GetByName(sectionName);
                //if ClientName in setup is equal than RecSource in Section_tbl update RecSourceUpdated if not, update ModSource and ModSourceUpdatedDate in Section_tbl
                bool UpdateClientOwner = clientName.ToUpper().Equals(section.RecSource.ToUpper());
                if (UpdateClientOwner)
                {
                    this.docSectionDL.UpdateSectionFileDocRecSource(sectionName, fileUpdated);
                }
                else 
                {
                    this.docSectionDL.UpdateSectionFileDocModSource(sectionName, fileUpdated, clientName);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            } 
        }


        public void DeleteBySectionName(string sectionName) 
        {
            try
            {
                this.docSectionDL.UpdateSectionFileDeleteMarkDate(sectionName);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        public string GetDocSectionFile(string sectionName)
        {
            try
            {
                byte[] docSectionFile = this.docSectionDL.GetDocSectionFile(sectionName);
                return DownloadFileFromByteArray(sectionName, docSectionFile);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        private string DownloadFileFromByteArray(string sectionName, byte[] fileBytes)
        {
            var tmpFile = Path.GetTempPath() + sectionName;
            string filePath = "";
            try
            {
                filePath = TempPartFileFromByteArray(fileBytes, tmpFile + ".doc");
            }
            catch (Exception)
            {
                filePath = TempPartFileFromByteArray(fileBytes, tmpFile + ".docx");
            }
            return filePath;
        }

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
    }
}

