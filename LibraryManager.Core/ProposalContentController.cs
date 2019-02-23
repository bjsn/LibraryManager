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
    using System.Text;

    public class ProposalContentController : BaseController
    {
        ProposalContentDL ProposalContentDL { get; set; }
        public ProposalContentController(bool requireAdminContent)
            : base(requireAdminContent)
        {
            this.AdminContent = requireAdminContent;
            this.ProposalContentDL = new ProposalContentDL(base.DBConnectionPath, requireAdminContent)
            {
                DbPwd = base.DBPW
            };
        }

        public List<ProposalContent> Get()
        {
            List<ProposalContent> all = null;
            try
            {
                all = this.ProposalContentDL.GetAll();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return all;
        }


        public ProposalContent Get(string PartNumber)
        {
            ProposalContent byPartNumber = null;
            try
            {
                byPartNumber = this.ProposalContentDL.GetByPartNumber(PartNumber);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
            return byPartNumber;
        }


        public List<ProposalContent> GetByKeyWord(string keyWord)
        {
            return (string.IsNullOrEmpty(keyWord) ? this.ProposalContentDL.GetAll() : this.ProposalContentDL.GetByKeyWord(keyWord));
        }


        public List<ProposalContent> GetFiltered(bool userAddedOnly, string vendorFilterName, string keyWord = "")
        {
            List<ProposalContent> list2 = null;
            try
            {
                List<ProposalContent> source = null;
                source = !string.IsNullOrEmpty(keyWord) ? this.ProposalContentDL.GetByKeyWord(keyWord) : this.ProposalContentDL.GetAll();
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
                return source;
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        public List<string> GetVendors()
        {
            List<string> vendors = null;
            try
            {
                vendors = this.ProposalContentDL.GetVendors();
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
                this.ProposalContentDL.Create(proposalContent);
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
                this.ProposalContentDL.Update(proposalContent);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }
        
        public void Delete(string PartNumber)
        {
            try
            {
                this.ProposalContentDL.Delete(PartNumber);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

    }
}

