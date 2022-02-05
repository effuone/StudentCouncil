using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Data;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Core.Repositories
{
    public class CountryRepository : IAsyncRepository<Country>
    {
        public Task<int> CreateAsync(Country model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Country> UpdateAsync(int id, Country model)
        {
            throw new NotImplementedException();
        }
    }
}