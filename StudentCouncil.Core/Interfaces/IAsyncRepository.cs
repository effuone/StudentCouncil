using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCouncil.Core.Interfaces
{
    public interface IAsyncRepository<T> where T:class
    {
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<int> CreateAsync(T model);
        public Task UpdateAsync(T model);
        public Task DeleteAsync(T model);
    }
}