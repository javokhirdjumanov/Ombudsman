using System;
using System.Collections.Generic;

namespace Ombudsman.API.Models
{
    public partial class DocFileModel
    {
        public DocFileModel()
        {
            DocDocuments = new HashSet<DocDocument>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string FileName { get; set; } = null!;

        public virtual ICollection<DocDocument> DocDocuments { get; set; }
    }
}
