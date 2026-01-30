using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Data
{
    public sealed class DbService
    {
        
        private readonly string _connectionString;

        public DbService()
        {
            _connectionString = "Server=(LocalDb)\\MSSQLLocalDb;Database=Practical22;Trusted_Connection=True;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}