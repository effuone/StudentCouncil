using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
        }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public DateTime OpeningDate { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
