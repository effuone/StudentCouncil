using System.ComponentModel.DataAnnotations;

namespace StudentCouncil.Data.ViewModels
{
    public class LocationVm
    {
        public LocationVm()
        {
            
        }
        public LocationVm(int locationId, int cityId, int countryId)
        {
            LocationId = locationId;
            CityId = cityId;
            CountryId = countryId;
        }

        public int LocationId { get; set; }
        public int CityId {get; set;}
        public int CountryId {get; set;}
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