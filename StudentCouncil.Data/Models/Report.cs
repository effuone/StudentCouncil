using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int CuratorId { get; set; }
        public string ReportName { get; set; }
        public string Description { get; set; }

        public virtual Curator Curator { get; set; }
    }
}
