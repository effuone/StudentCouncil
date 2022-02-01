using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Curator
    {
        public Curator()
        {
            Reports = new HashSet<Report>();
        }

        public int CuratorId { get; set; }
        public int DepartmentId { get; set; }
        public int MemberId { get; set; }
        public string BecameReason { get; set; }
        public DateTime BecameDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
