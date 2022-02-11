#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;
using StudentCouncil.Data.ViewModels;

namespace StudentCouncil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly StudentCouncilDbContext _context;
        private readonly ILogger<CityController> _logger;

        public CityController(StudentCouncilDbContext context, ILogger<CityController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<IEnumerable<CityVm>> GetCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            var viewModelList = new List<CityVm>();
            foreach (var city in cities)
            {
                var vm = new CityVm();
                vm.CityName = city.CityName;
                vm.CountryId = city.CountryId;
                vm.CityId = city.CityId;
                viewModelList.Add(vm);
            }
            return viewModelList;
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityVm>> GetCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            var vm = new CityVm();
            vm.CityId = city.CityId;
            vm.CityName = city.CityName;
            vm.CountryId = city.CountryId;
            return vm;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityAsync(int id, UpdateCityVm cityVm)
        {
            var existingCity = await _context.Cities.FindAsync(id);
            if(existingCity is null)
            {
                return NotFound();
            }
            existingCity.CityName = cityVm.CityName;
            existingCity.CountryId = cityVm.CountryId;
            _context.Cities.Update(existingCity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityVm>> PostCityAsync(string cityName, int countryId)
        {
            var existingCity = await _context.Cities.Where(x=>x.CityName==cityName && x.CountryId == countryId).FirstOrDefaultAsync();
            if(existingCity is not null)
            {
                return BadRequest($"{cityName} already exists");
            }
            var newCity = new City();
            newCity.CityName = cityName;
            newCity.CountryId = countryId;
            _context.Cities.Add(newCity);
            await _context.SaveChangesAsync();
            var vm = new CityVm();
            vm.CountryId = countryId;
            vm.CityName = cityName;
            vm.CityId = newCity.CityId;
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {newCity.CityName}");
            return CreatedAtAction(nameof(GetCityAsync), new { id = newCity.CityId }, vm);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CityExists(int id)
        {
            return await _context.Cities.AnyAsync(e => e.CityId == id);
        }
    }
}
