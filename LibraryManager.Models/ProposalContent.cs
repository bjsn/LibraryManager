using System;
using System.Runtime.CompilerServices;


namespace LibraryManager.Models
{
    public class ProposalContent : BaseEntity
    {
        public string PartNumber { get; set; }

        public string VendorName { get; set; }

        public string ProductName { get; set; }

        public string FeatureBullets { get; set; }

        public string MarketingInfo { get; set; }

        public string TechnicalInfo { get; set; }

        public string ProductPicturePath { get; set; }

        public string ProductPictureURL { get; set; }

        public byte[] ProductPicture { get; set; }

        public string MfgPartNumber { get; set; }

        public string MfgName { get; set; }

        public DateTime UserCreatedDT { get; set; }

        public DateTime DownloadDT { get; set; }

        public DateTime UserUpdDT { get; set; }
    }
}

