using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Location
    {
        public Location()
        {
            Schools = new HashSet<School>();
        }

        public int LocationId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}
