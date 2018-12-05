using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFP.Models
{
    public class RFPContent
    {
        public int ID { get; set; }
        public string Name { get;set;}
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public DateTime CreateDT { get; set; }
        public DateTime UpdateDT { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] FileData { get; set; }
    }
}
