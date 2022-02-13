using System.Threading.Tasks;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Interfaces
{
    public interface ICountryRepository : IAsyncRepository<Country>
    {
        public Task<Country> GetAsync(string countryName);
    }
}