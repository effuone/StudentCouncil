using System.Threading.Tasks;

namespace StudentCouncil.Core.Interfaces
{
    public interface IAsyncViewModelRepository<T,U> where T:class
    {
        public Task<T> GetViewModelAsync(T model);
    }
}