namespace LibraryManager.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class DocSection : BaseEntity
    {
        public int Order { get; set; }

        public string Section { get; set; }

        public string Location { get; set; }

        public string DocType { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime ClientUpdated { get; set; }
    }
}

