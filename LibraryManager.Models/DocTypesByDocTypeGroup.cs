using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Models
{
    public class DocTypesByDocTypeGroup : BaseEntity
    {
        public string DocTypeGroupName { get; set; }

        public string DocType { get;set;}

    }
}
