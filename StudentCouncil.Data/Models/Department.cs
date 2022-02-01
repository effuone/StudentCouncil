using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            Curators = new HashSet<Curator>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Curator> Curators { get; set; }
    }
}
