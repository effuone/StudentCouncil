using System;
using System.Collections.Generic;

namespace StudentCouncil.Data.Models
{
    public partial class City
    {
        public City()
        {
            Locations = new HashSet<Location>();
        }

        public City(int countryId, string cityName)
        {
            CountryId = countryId;
            CityName = cityName;
        }

        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
