using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public int GroupId { get; set; }
        public int Grade { get; set; }
        public string GroupChar { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
