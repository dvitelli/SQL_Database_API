using Backend.Data;
using Newtonsoft.Json;
using Backend.Models;

namespace Utility.CreateDatabase
{
    /// <summary>
    /// Checks if user data exists in database, if it does not create database
    /// </summary>
    public class CreateDatabase{
    
        
        public void DatabaseCreation()
        {
            //check to see if database exists
            if(UserDataExists())
            {
               Console.WriteLine("Database exists, skipping database creation.");
               return;
            }; 
            
            DataContextDapper dapper = new DataContextDapper();
                     
            var data = File.ReadAllText("Users.json");
            IngestModel? users = JsonConvert.DeserializeObject<IngestModel>(data);
                
            if (users == null) return;
            List<User> userList = new List<User>();
            
            foreach(var item in users.Results)
            {
                User user = new User(){
                    FirstName = item.Name.FirstName,
                    LastName = item.Name.LastName,
                    StreetNumber = item.Location.Street.Number,
                    StreetName = item.Location.Street.Name,
                    City = item.Location.City,
                    State = item.Location.State,
                    Country = item.Location.Country,
                    PostCode = item.Location.PostCode,
                    Email = item.Email,
                    DateOfBirth = item.Date.Date,
                    Age = item.Date.Age,
                    PhoneNumber = item.Cell ?? item.Phone ?? string.Empty,
                    SSN = item.Id.Value,
                    PictureThumbnail = item.Picture?.Thumbnail ?? string.Empty                    
                };   
                
                userList.Add(user); 
                
            }
            
            dapper.LoadUserList(userList);
    
        }
        
        /// <summary>
        /// Runs sql query to see if user data is in the database
        /// </summary>
        /// <returns>{bool} wether users exist</returns>
        public bool UserDataExists()
        {
            DataContextDapper dapper = new DataContextDapper();
            string sql = "SELECT COUNT(*) FROM DatabaseSchema.UserData"; 
            var count = dapper.QuerySingle<int>(sql);
            return count > 0;
        }
    }
}