using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class DocSectionByItem
    {
        public string ItemCategory { get; set; }

        public string SOWSection { get; set; }

        public string Include { get; set; }

        public string RecSource { get; set; }

        public DateTime RecSourceUpdatedDate { get; set; }

        public string ModSource { get; set; }

        public DateTime ModSourceUpdatedDate { get; set; }

        public DateTime? DeleteMarkDate { get; set; }
    }
}
