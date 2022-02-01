using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Member
    {
        public Member()
        {
            Curators = new HashSet<Curator>();
            Plans = new HashSet<Plan>();
        }

        public int MemberId { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<Curator> Curators { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
