using Backend.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Backend.Repositories
{
        public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<List<User>> GetAllAsync()
        {
            using var connection = GetConnection();
            var users = await connection.QueryAsync<User>("SELECT * FROM DatabaseSchema.UserData");
            return users.ToList();
        }
        
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        
    }
}