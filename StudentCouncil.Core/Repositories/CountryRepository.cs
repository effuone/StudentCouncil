using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Repositories
{
    public class CountryRepository : IAsyncRepository<Country>
    {
        private readonly StudentCouncilDbContext _context;

        public CountryRepository(StudentCouncilDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Country model)
        {
            await _context.Countries.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.CountryId;
        }

        public async Task DeleteAsync(int id)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if(existingCountry is not null)
            {
                _context.Countries.Remove(existingCountry);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if(country is not null)
            return country;
            else throw new ArgumentNullException();

        }

        public async Task<Country> UpdateAsync(int id, Country model)
        {
            var country = await _context.Countries.FindAsync(id);
            if(country is not null)
            {
                _context.Countries.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else throw new ArgumentNullException();
        }
    }
}