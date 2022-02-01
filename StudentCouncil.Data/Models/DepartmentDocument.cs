using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class DepartmentDocument
    {
        public int DepartmentId { get; set; }
        public int FileId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Document File { get; set; }
    }
}
