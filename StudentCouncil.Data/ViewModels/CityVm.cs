using System.ComponentModel.DataAnnotations;

namespace StudentCouncil.Data.ViewModels
{
    public class CityVm
    {
        public int CityId { get; set; }
        public int CountryId {get; set;}
        public string CityName { get; set; }
    }
    public class CreateCityVm
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CityName { get; set; }
    }
    public class UpdateCityVm
    {
        [Required]
        public int CountryId { get; set; }
        [MaxLength(50)]
        [Required]
        public string CityName { get; set; }
    }
}