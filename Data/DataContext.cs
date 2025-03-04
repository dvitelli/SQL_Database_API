using System.Data;
using Backend.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Backend.Data
{
    public class DataContextDapper
    {
        private static string _connectionString = "Server=localhost;Database=UserDatabase;Trusted_Connection=True;TrustServerCertificate=true;";
        
        public IEnumerable<T> LoadData<T>(string sql)
        {
            
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
            
        }
        
        /// <summary>
        /// Inserts user list into Database.
        /// </summary>
        /// <param name="values">List of Users</param>
        public void LoadUserList(List<User> values)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            
            string sql = "INSERT INTO DatabaseSchema.UserData "
                 + "(FirstName"
                 + ",LastName"
                 + ",StreetNumber"
                 + ",StreetName"
                 + ",City"
                 + ",State"
                 + ",Country"
                 + ",PostCode"
                 + ",Email"
                 + ",DateOfBirth"
                 + ",Age"
                 + ",Phone"
                 + ",SSN"
                 + ",PictureThumbnail)"
                 + "VALUES";
                 
                 foreach(User user in values)
                 {
                    sql += "(" 
                     + " '" + user.FirstName 
                     + "', '" + user.LastName
                     + "', '" + user.StreetNumber
                     + "', '" + user.StreetName
                     + "', '" + user.City
                     + "', '" + user.State
                     + "', '" + user.Country
                     + "', '" + user.PostCode
                     + "', '" + user.Email
                     + "', '" + user.DateOfBirth
                     + "', '" + user.Age
                     + "', '" + user.PhoneNumber
                     + "', '" + user.SSN
                     + "', '" + user.PictureThumbnail
                     + "'),";
    
             
                 }
                 
                 dbConnection.Query(sql.Trim(','));
                                    
        }
        
        public T QuerySingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }
         
         
    }
}
