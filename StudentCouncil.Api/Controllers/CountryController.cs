#nullable disable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Core.Repositories;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;
using StudentCouncil.Data.ViewModels;

namespace StudentCouncil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryRepository countryRepository, ILogger<CountryController> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<IEnumerable<CountryVm>> GetCountriesAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            var list = new List<CountryVm>();
            foreach (var country in countries)
            {
                var vm = new CountryVm();
                vm.CountryName = country.CountryName;
                vm.CountryId = country.CountryId;
                list.Add(vm);
            }
            return list;
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryVm>> GetCountryAsync(int id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            var vm = new CountryVm();
            vm.CountryName = country.CountryName;
            vm.CountryId = country.CountryId;
            return vm;
        }
        [HttpGet("{countryName}")]
        public async Task<ActionResult<CountryVm>> GetCountryAsync(string countryName)
        {
            var country = await _countryRepository.GetAsync(countryName);
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
        public async Task<IActionResult> PutCountryAsync(int id, UpdateCountryVm countryVm)
        {
            var country = await _countryRepository.GetAsync(id);
            if(country is null)
            {
                return NotFound();
            }
            country.CountryName = countryVm.CountryName;
            country.CountryId = id;
            await _countryRepository.UpdateAsync(country);
            return NoContent();
        }

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryVm>> PostCountryAsync(string countryName)
        {
            var country = await _countryRepository.GetAsync(countryName);
            if(country is not null)
            {
                return BadRequest($"Country {countryName} already exists.");
            }
            var newCountry = new CountryVm();
            newCountry.CountryId = country.CountryId;
            newCountry.CountryName = country.CountryName;
            _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")} : Retrieved {newCountry.CountryName}");
            return CreatedAtAction(nameof(GetCountryAsync), new { id = newCountry.CountryId }, newCountry);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            var existingCountry = await _countryRepository.GetAsync(id);
            if(existingCountry is null)
            {
                return NotFound();
            }
            await _countryRepository.DeleteAsync(existingCountry);
            return NoContent();
        }
    }
}
