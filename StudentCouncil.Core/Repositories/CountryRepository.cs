using System.Data;
using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly StudentCouncilDbContext _dbContext;

        public CountryRepository(StudentCouncilDbContext context)
        {
            _dbContext = context;
        }

        public async Task<int> CreateAsync(Country model)
        {
            var obj = await _dbContext.Countries.AddAsync(model);  
            await _dbContext.SaveChangesAsync();  
            return obj.Entity.CountryId;            
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var query = from country in _dbContext.Countries
                        select country;
            return await query.ToListAsync();
        }

        public async Task<Country> GetAsync(int id)
        {
            var query = (from country in _dbContext.Countries
                         where country.CountryId == id
                         select country).SingleOrDefaultAsync();
            return await query;
        }

        public async Task UpdateAsync(Country model)
        {
            _dbContext.Countries.Update(model);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Country model)
        {
            _dbContext.Countries.Remove(model);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Country> GetAsync(string countryName)
        {
            return await _dbContext.Countries.Where(x=>x.CountryName==countryName).FirstOrDefaultAsync();
        }
    }
}