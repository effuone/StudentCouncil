#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Core.Repositories;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;
using StudentCouncil.Data.ViewModels;

namespace StudentCouncil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryController> _logger;

        public CityController(ICityRepository cityRepository, ICountryRepository countryRepository, ILogger<CountryController> logger)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        // GET: api/City
        [HttpGet]
        public async Task<IEnumerable<CityVm>> GetCitiesAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            var list = new List<CityVm>();
            foreach (var city in cities)
            {
                var vm = new CityVm();
                vm.CityName = city.CityName;
                vm.CityId = city.CityId;
                vm.CountryId = city.CountryId;
                list.Add(vm);
            }
            return list;
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityVm>> GetCityAsync(int id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            var vm = new CityVm();
            vm.CityName = city.CityName;
            vm.CityId = city.CityId;
            vm.CountryId = city.CountryId;
            return vm;
        }

        // PUT: api/City/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityAsync(int id, UpdateCityVm cityVm)
        {
            var city = await _cityRepository.GetAsync(id);
            if(city is null)
            {
                return NotFound();
            }
            city.CityName = cityVm.CityName;
            city.CityId = id;
            city.CountryId = cityVm.CountryId;
            await _cityRepository.UpdateAsync(city);
            return NoContent();
        }

        // POST: api/City
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityVm>> PostCityAsync(int countryId, string cityName)
        {
            var city = await _cityRepository.GetCityByName(cityName);
            var country = await _countryRepository.GetAsync(countryId); 
            if(city is not null)
            {
                return BadRequest($"City {cityName} already exists.");
            }
            if(country is null)
            {
                return NotFound($"Country of id {countryId} not found.");
            }
            var newCity = new City();
            newCity.CityName = cityName;
            newCity.CountryId = country.CountryId;
            await _cityRepository.CreateAsync(newCity);

            var vm = new CityVm();
            vm.CountryId = newCity.CountryId;
            vm.CityName = newCity.CityName;
            vm.CityId = newCity.CityId;
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {newCity.CityName}");
            return CreatedAtAction(nameof(GetCityAsync), new { id = newCity.CityId }, vm);
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            var existingCity = await _cityRepository.GetAsync(id);
            if(existingCity is null)
            {
                return NotFound();
            }
            await _cityRepository.DeleteAsync(existingCity);
            return NoContent();
        }
    }
}
