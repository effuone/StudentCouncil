using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Plan
    {
        public int PlanId { get; set; }
        public string PlanShort { get; set; }
        public string PlanDescription { get; set; }
        public decimal? Investments { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
