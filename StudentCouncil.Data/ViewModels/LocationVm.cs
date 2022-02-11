using System.ComponentModel.DataAnnotations;

namespace StudentCouncil.Data.ViewModels
{
    public class LocationVm
    {
        public LocationVm(int locationId, string countryName, string cityName)
        {
            LocationId = locationId;
            CountryName = countryName;
            CityName = cityName;
        }
        public LocationVm()
        {
            
        }

        public int LocationId { get; set; }
        public string CountryName { get; set; }
        public string CityName {get; set;}
    }
    public class CreateLocationVm
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int CityId { get; set; }
    }
    public class UpdateLocationVm
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}