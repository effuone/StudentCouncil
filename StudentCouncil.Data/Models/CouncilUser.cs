using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class CouncilUser
    {
        public int CouncilUserId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FileId { get; set; }

        public virtual Document File { get; set; }
    }
}
