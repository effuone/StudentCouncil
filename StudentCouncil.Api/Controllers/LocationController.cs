using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;
using StudentCouncil.Data.ViewModels;

namespace StudentCouncil.Api.Controllers
{
    [ApiController]
    [Route("api/locations/")]
    public class LocationController : ControllerBase
    {
        private readonly StudentCouncilDbContext _context;
        private readonly ILogger<LocationController> _logger;

        public LocationController(StudentCouncilDbContext context, ILogger<LocationController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
           return await _context.Locations.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if(location is not null)
            {
                _logger.LogInformation($"Retrieved location of id {location.LocationId}.");
                return location;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<LocationVm>> PostLocation(CreateLocationVm locationVm)
        {
            var existingCountry = await _context.Countries.FindAsync(locationVm.CountryId);
            var existingCity = await _context.Cities.FindAsync(locationVm.CityId);
            if(existingCountry is null)
            {
                _logger.LogInformation($"404: Non-existing country of id of {locationVm.CountryId}.");
                return NotFound("Country not found.");
            }
            if(existingCity is null)
            {
                _logger.LogInformation($"404: Non-existing city of id of {locationVm.CountryId}.");
                return NotFound("City not found.");
            }
            var existingLocation = await _context.Locations.Where(x=>x.CountryId == locationVm.CountryId && x.CityId==locationVm.CityId).FirstOrDefaultAsync();
            if(existingLocation is null)
            {
                var location = new Location();
                location.CountryId = locationVm.CountryId;
                location.CityId = locationVm.CityId;
                await _context.Locations.AddAsync(location);
                await _context.SaveChangesAsync();
                 _logger.LogInformation($"200: Successfully created new location of id {location.LocationId}.");

                return CreatedAtAction("GetLocationAsync", new { id = location.LocationId }, location);
            }
            _logger.LogInformation($"Request on existing location of id {existingLocation.LocationId}");
            return BadRequest("Location already exists.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationAsync(int id, UpdateLocationVm locationVm)
        {
            var existingLocation = await _context.Locations.FindAsync(id);
            if(existingLocation is null)
            {
                return NotFound();
            }
            existingLocation.CountryId = locationVm.CountryId;
            existingLocation.CityId = locationVm.CityId;
            _context.Locations.Update(existingLocation);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Updated location by id of {existingLocation.LocationId}");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAsync(int id)
        {
            var model = await _context.Locations.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            _context.Locations.Remove(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}