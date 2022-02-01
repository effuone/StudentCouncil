using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class ReportDocument
    {
        public int ReportId { get; set; }
        public int FileId { get; set; }
        public DateTime LastChangedTime { get; set; }

        public virtual Document File { get; set; }
        public virtual Report Report { get; set; }
    }
}
