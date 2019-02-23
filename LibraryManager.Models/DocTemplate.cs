using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class DocTemplate
    {
        public string  Template_Name { get; set; }

        public byte[] Word_Doc { get; set; }

        public string RecSource { get; set; }

        public DateTime RecSourceUpdatedDate { get; set; }

    }
}
