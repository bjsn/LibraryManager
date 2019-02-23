using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class ItemCategory
    {
        public string ItemCategoryName { get; set; }

        public string Comment { get; set; }

        public string RecSource { get; set; }

        public DateTime RecSourceUpdatedDate { get; set; }

        public DateTime DeleteMarkDate { get; set; }

        public int DocSectionByItemCount { get; set; }

        public List<DocSectionByItem> DocSectionByItem { get; set; }
    }
}
