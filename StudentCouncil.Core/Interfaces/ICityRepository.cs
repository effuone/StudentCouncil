using System.Threading.Tasks;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Interfaces
{
    public interface ICityRepository : IAsyncRepository<City>
    {
        public Task<City> GetCityByName(string cityName);
    }
}