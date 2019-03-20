using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class VendorContent
    {
        public string VendorName { get; set; }
        public string Comments { get; set; }
        public DateTime PricingUpdateDate { get; set; }
        public string Status { get; set; }

    }
}
