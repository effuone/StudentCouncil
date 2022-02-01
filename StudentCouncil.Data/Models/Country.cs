using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Locations = new HashSet<Location>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
