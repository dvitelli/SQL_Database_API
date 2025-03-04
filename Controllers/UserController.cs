using Microsoft.AspNetCore.Mvc;
using Backend.Repositories;
using Backend.Models;

namespace Backend.Controllers
{
    //base route
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        //Initializes the _userRepository that all of the controller methods will use.
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        /// <summary>
        /// Base get call to api. Returns all users in database.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
        
        /// <summary>
        /// Returns a user in database that matches the given id.
        /// </summary>
        /// <param name="id">UserId of User in Database</param>
        [HttpGet("{id}", Name = "GetById" )]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null)
            return NotFound("User does not exist in database.");
            
            return Ok(user);
        }
        
        /// <summary>
        /// Adds a user to database.
        /// </summary>
        /// <param name="user">User to be added to database</param>
        [HttpPost]
        public async Task<ActionResult> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return Created();//returning Created - 201
        }
        
        /// <summary>
        /// Then updates user in database from new user based on ID.
        /// </summary>
        /// <param name="id", name="user">UserId of User in Database</param>
        /// <param name="user", name="user">User to be updated</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, User user)
        {
            var userExists = await _userRepository.GetByIdAsync(id);
            if(userExists == null)
            return NotFound("User not found.");  
            
            user.UserId = id;
            await _userRepository.UpdateAsync(user);
            return NoContent();//respond with a 204
            
        }
        
        /// <summary>
        /// Deletes user in database from that matches Id.
        /// </summary>
        /// <param name="id">User ID to be found in Database</param>     
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            
            await _userRepository.DeleteAsync(id);
            return NoContent();//respond with a 204 and empty body
        }
        
       
    }
}