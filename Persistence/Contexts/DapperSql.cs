using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class DapperSql
    {
        private readonly string _query;
        public DapperSql(string query, IConfiguration configuration)
        {
            _query = query;
            SqlConnection dbConnection = new(configuration.GetConnectionString("DefaultConnection"));
        }


    }
}
