using System.ComponentModel.DataAnnotations;

namespace StudentCouncil.Data.ViewModels
{
    public class CountryVm
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
    public class CreateCountryVm
    {
        [Required]
        [MaxLength(50)]
        public string CountryName {get; set;}
    }
    public class UpdateCountryVm
    {
        [Required]
        [MaxLength(50)]
        public string CountryName {get; set;}
    }
}