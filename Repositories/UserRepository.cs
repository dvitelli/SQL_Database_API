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

        public async Task AddAsync(User user)
        {
            using var connection = GetConnection();
            await connection.ExecuteAsync("INSERT INTO DatabaseSchema.UserData "
                 + "(FirstName, LastName, StreetNumber, StreetName, City, State,"
                 + "Country, PostCode, Email, DateOfBirth, Age, Phone, SSN, PictureThumbnail)"
                 + "VALUES (@FirstName, @LastName, @StreetNumber, @StreetName," 
                 + "@City, @State, @Country, @PostCode, @Email, @DateOfBirth, @Age, @PhoneNumber, "
                 + "@SSN, @PictureThumbnail)", user); //use execute for add, update, delete
            
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = GetConnection();
            await connection.ExecuteAsync("Delete DatabaseSchema.UserData WHERE UserId = @Id", new{Id = id});
            
        }

        public async Task<List<User>> GetAllAsync()
        {
            using var connection = GetConnection();
            var users = await connection.QueryAsync<User>("SELECT * FROM DatabaseSchema.UserData");
            return users.ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var user = await connection
                            .QueryFirstOrDefaultAsync<User>("SELECT * FROM DatabaseSchema.UserData WHERE UserId = @Id", new{Id = id});
                return user;
            }
        }

        public async Task UpdateAsync(User user)
        {
            using var connection = GetConnection();
            await connection.ExecuteAsync("UPDATE DatabaseSchema.UserData SET "  
            + "FirstName = @FirstName, LastName=@LastName, StreetNumber=@StreetNumber, StreetName=@StreetName," 
            + "City=@City, State=@State, Country=@Country, PostCode=@PostCode, Email=@Email, DateOfBirth=@DateOfBirth,"
            + "Age=@Age, Phone=@PhoneNumber, SSN=@SSN, PictureThumbnail=@PictureThumbnail "
            + "WHERE UserId = @UserId", user);
            
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        
    }
}