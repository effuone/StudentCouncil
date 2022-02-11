using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly StudentCouncilDbContext _context;

        public CityRepository(StudentCouncilDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(City model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.CityId;
        }

        public async Task DeleteAsync(City model)
        {
            _context.Cities.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync(); 
        }

        public async Task<City> GetAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<City> GetCityByName(string cityName)
        {
            return await _context.Cities.Where(city=>city.CityName==cityName).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(City model)
        {
            _context.Cities.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}