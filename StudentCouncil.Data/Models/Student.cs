using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Members = new HashSet<Member>();
        }

        public int StudentId { get; set; }
        public int CouncilUserId { get; set; }
        public int SchoolId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
