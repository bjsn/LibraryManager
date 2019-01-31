using LibraryManager.Data;
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
        private DocSectionDL docSectionDL;

        public DocSectionController(bool adminContent = true) : base(adminContent) 
        {
            this.docSectionDL = new DocSectionDL(base.DBConnectionPath)
            {
                DbPwd = base.DBPW
            };
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
                    Console.WriteLine(section.Order);
                }
            }
            catch (Exception e)
            {
            }
        }


        public void UpdateSectionFile(string sectionName, byte[] fileUpdated) 
        {
            try
            {
                SetupDL setupDL = new SetupDL(base.DBConnectionPath)
                {
                    DbPwd = base.DBPW
                };

                string clientName = setupDL.GetClientName();
                DocSection section = this.docSectionDL.GetByName(sectionName);
                //if ClientName in setup able is equal than RecSource in Section_tbl update RecSourceUpdated if not, update ModSource and ModSourceUpdatedDate in Section_tbl
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

