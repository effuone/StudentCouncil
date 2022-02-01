using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class DepartmentMember
    {
        public int DepartmentId { get; set; }
        public int MemberId { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Member Member { get; set; }
    }
}
