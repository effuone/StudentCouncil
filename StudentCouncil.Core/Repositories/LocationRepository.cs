using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly StudentCouncilDbContext _dbContext;
        
        public LocationRepository(StudentCouncilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Location model)
        {
            var obj = await _dbContext.Locations.AddAsync(model);  
            await _dbContext.SaveChangesAsync();  
            return obj.Entity.CountryId; 
        }

        public async Task DeleteAsync(Location model)
        {
            _dbContext.Locations.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task<Location> GetAsync(int id)
        {
            return await _dbContext.Locations.FindAsync(id);
        }

        public async Task<Location> GetLocationByCityAsync(string cityName)
        {
            var city = await _dbContext.Cities.Where(x=>x.CityName==cityName).FirstOrDefaultAsync();
            return await _dbContext.Locations.Where(x=>x.CityId==city.CityId).FirstOrDefaultAsync();
        }

        public async Task<Location> GetLocationByCityAsync(int cityId)
        {
            return await _dbContext.Locations.Where(x=>x.CityId==cityId).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Location model)
        {
            _dbContext.Locations.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}