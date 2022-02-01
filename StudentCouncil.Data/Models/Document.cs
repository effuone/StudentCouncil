using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Document
    {
        public Document()
        {
            CouncilUsers = new HashSet<CouncilUser>();
        }

        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string Extension { get; set; }

        public virtual ICollection<CouncilUser> CouncilUsers { get; set; }
    }
}
