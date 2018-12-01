namespace LibraryManager.Core
{
    using LibraryManager.Data;
    using LibraryManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class ProposalContentController : BaseController
    {
        public void Delete(string PartNumber)
        {
            try
            {
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                base.ProposalContentDL.Delete(PartNumber);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        public List<ProposalContent> Get()
        {
            List<ProposalContent> all;
            try
            {
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                all = base.ProposalContentDL.GetAll();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return all;
        }

        public ProposalContent Get(string PartNumber)
        {
            ProposalContent byPartNumber;
            try
            {
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                byPartNumber = base.ProposalContentDL.GetByPartNumber(PartNumber);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return byPartNumber;
        }

        public List<ProposalContent> GetByKeyWord(string keyWord)
        {
            ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                DbPwd = base.DBPW
            };
            base.ProposalContentDL = tdl;
            return (string.IsNullOrEmpty(keyWord) ? base.ProposalContentDL.GetAll() : base.ProposalContentDL.GetByKeyWord(keyWord));
        }

        public List<ProposalContent> GetFiltered(bool userAddedOnly, string vendorFilterName, string keyWord = "")
        {
            List<ProposalContent> list2;
            try
            {
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                List<ProposalContent> source = null;
                source = !string.IsNullOrEmpty(keyWord) ? base.ProposalContentDL.GetByKeyWord(keyWord) : base.ProposalContentDL.GetAll();
                foreach (ProposalContent content in source.ToList<ProposalContent>())
                {
                    bool flag = content.DownloadDT.Equals(DateTime.MinValue);
                    if (userAddedOnly && !flag)
                    {
                        source.Remove(content);
                    }
                    if (!string.IsNullOrEmpty(vendorFilterName) && !content.VendorName.Equals(vendorFilterName))
                    {
                        source.Remove(content);
                    }
                }
                list2 = source;
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return list2;
        }

        public List<string> GetVendors()
        {
            List<string> vendors;
            try
            {
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                vendors = base.ProposalContentDL.GetVendors();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return vendors;
        }

        public void Save(ProposalContent proposalContent)
        {
            try
            {
                proposalContent.ProductPicturePath = this.SaveImage(proposalContent.ProductPicturePath, proposalContent.PartNumber);
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                base.ProposalContentDL.Create(proposalContent);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        private string SaveImage(string imagePath, string partNumber)
        {
            string str3;
            try
            {
                string str = "";
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string path = base.DIRECTORY_ROOT + ConfigurationManager.AppSettings["SaveFilesPath"].ToString(CultureInfo.InvariantCulture);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    str = path + partNumber + Path.GetExtension(imagePath);
                    if (!imagePath.Equals(str))
                    {
                        File.Copy(imagePath, str, true);
                    }
                }
                str3 = str;
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return str3;
        }

        public void Update(ProposalContent proposalContent)
        {
            try
            {
                proposalContent.ProductPicturePath = this.SaveImage(proposalContent.ProductPicturePath, proposalContent.PartNumber);
                ProposalContentDL tdl = new ProposalContentDL(base.ProposalContentDBConnectionPath) {
                    DbPwd = base.DBPW
                };
                base.ProposalContentDL = tdl;
                base.ProposalContentDL.Update(proposalContent);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }
    }
}

