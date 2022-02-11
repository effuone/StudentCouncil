using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;
using StudentCouncil.Data.ViewModels;

namespace StudentCouncil.Api.Controllers
{
    [ApiController]
    [Route("api/locations/")]
    public class LocationController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository; 
        private readonly ICityRepository _cityRepository; 
        private readonly ILocationRepository _locationRepository; 
        private readonly ILogger<LocationController> _logger;

        public LocationController(ICountryRepository countryRepository, ICityRepository cityRepository, ILocationRepository locationRepository, ILogger<LocationController> logger)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _locationRepository = locationRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<LocationVm>> GetAllLocationsAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            var list = new List<LocationVm>();
            foreach (var location in locations)
            {
                var locationVm = new LocationVm();
                locationVm.LocationId = location.LocationId;
                locationVm.CityId = location.CityId;
                locationVm.CountryId = location.CountryId;
                list.Add(locationVm);
            }
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationVm>> GetLocationAsync(int id)
        {
            var location = await _locationRepository.GetAsync(id);
            if(location is null)
            {
                return NotFound();
            }
            var vm = new LocationVm();
            vm.LocationId = location.LocationId;
            vm.CityId = location.CityId;
            vm.CountryId = location.CountryId;
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved Location id {location.LocationId}");
            return vm;
        }
        [HttpPost]
        public async Task<ActionResult<LocationVm>> PostLocation(int cityId, int countryId)
        {
            var existingCountry = await _countryRepository.GetAsync(countryId);
            var existingCity = await _cityRepository.GetAsync(cityId);
            if(existingCountry is null)
            {
                return NotFound("Country not found.");
            }
            if(existingCity is null)
            {
                return NotFound("City not found.");
            }
            var existingLocation = await _locationRepository.GetLocationByCityAsync(existingCity.CityId);
            if(existingLocation is not null)
            {
                return BadRequest("Location already exists.");
            }
            var location = new Location();
            location.CountryId = countryId;
            location.CityId = cityId;
            await _locationRepository.CreateAsync(location);
            var vm = new LocationVm();
            vm.CityId = location.CityId;
            vm.CountryId = location.CountryId;
            vm.LocationId = location.LocationId;
            _logger.LogInformation($"200: Successfully created new location of id {location.LocationId}.");

            return CreatedAtAction(nameof(GetLocationAsync), new { id = location.LocationId }, vm);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationAsync(int id, UpdateLocationVm locationVm)
        {
            var existingLocation = await _locationRepository.GetAsync(id);
            if(existingLocation is null)
            {
                return NotFound();
            }
            existingLocation.CountryId = locationVm.CountryId;
            existingLocation.CityId = locationVm.CityId;
            await _locationRepository.UpdateAsync(existingLocation);
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Updated Location id {existingLocation.LocationId}");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAsync(int id)
        {
            var existingLocation = await _locationRepository.GetAsync(id);
            if (existingLocation == null)
            {
                return NotFound();
            }
            await _locationRepository.DeleteAsync(existingLocation);
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Deleted Location id {existingLocation.LocationId}");
            return NoContent();
        }
    }
}