using System;
using System.Runtime.CompilerServices;

namespace LibraryManager.Models
{
    public class DocSection : BaseEntity
    {
        public double Order { get; set; }

        public string Section { get; set; }

        public string Location { get; set; }

        public string DocType { get; set; }

        public string Description { get; set; }

        public string RecSource { get; set; }

        public DateTime UpdatedDT { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime ClientUpdatedDT { get; set; }

        public byte[] WordDoc { get; set; }
    }
}

