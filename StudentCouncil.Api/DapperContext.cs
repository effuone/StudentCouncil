using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace StudentCouncil.Api
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration; _connectionString = _configuration.GetConnectionString("ZhetistikDB");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
