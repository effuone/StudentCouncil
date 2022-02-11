using Dapper;
using Microsoft.Data.SqlClient;
using StudentCouncil.Core.Interfaces;
using StudentCouncil.Data.Models;
using StudentCouncil.Data.ViewModels;

namespace StudentCouncil.Core.ViewModelRepositories
{
    // public class LocationViewModelRepository : IAsyncViewModelRepository<LocationVm>
    // {
    //     private readonly DapperContext _context;

    //     public LocationViewModelRepository(DapperContext context)
    //     {
    //         _context = context;
    //     }

    //     public async Task<IEnumerable<LocationVm>> GetAllAsync()
    //     {
    //         using(var connection = _context.CreateConnection())
    //         {
    //             string sql = "SELECT* FROM Locations";
    //             var locations = await connection.QueryAsync<LocationVm>(sql);
    //             return locations;
    //         }
    //     }

    //     public Task<LocationVm> GetAsync(int id)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}