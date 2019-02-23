using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class DocTypeGroup : BaseEntity
    {
        public string DocTypeGroupName { get; set; }
        public int AssociatedDocSectionTypes { get; set; }
    }
}
