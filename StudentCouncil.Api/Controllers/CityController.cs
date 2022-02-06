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
        public async Task<ActionResult<CountryVm>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            var vm = new CountryVm();
            vm.CountryName = country.CountryName;
            vm.CountryId = country.CountryId;
            return vm;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryVm country)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if(existingCountry is null)
            {
                return NotFound();
            }
            existingCountry.CountryName = country.CountryName;
            _context.Countries.Update(existingCountry);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryVm>> PostCityAsync(CreateCountryVm country)
        {
            var newCountry = new Country();
            newCountry.CountryName = country.CountryName;
            _context.Countries.Add(newCountry);
            await _context.SaveChangesAsync();
            var vm = new CountryVm();
            vm.CountryId = newCountry.CountryId;
            vm.CountryName = country.CountryName;
            return CreatedAtAction("GetCountry", new { id = newCountry.CountryId }, vm);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}
