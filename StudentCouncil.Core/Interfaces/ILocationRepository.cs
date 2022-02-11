using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Interfaces
{
    public interface ILocationRepository : IAsyncRepository<Location>
    {
        public Task<Location> GetLocationByCityAsync(string cityName);
        public Task<Location> GetLocationByCityAsync(int cityId);
    }
}