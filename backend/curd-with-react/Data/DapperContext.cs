using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace curd_with_react.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _config;

        public DapperContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IEnumerable<T> LoadData<T>(String sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql);
        }
        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.QuerySingle<T>(sql);
        }
        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return (dbConnection.Execute(sql) > 0);
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql);
        }

    }
}
