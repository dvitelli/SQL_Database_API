using Microsoft.AspNetCore.Mvc;
using Backend.Repositories;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
        
        [HttpGet("{id}", Name = "GetById" )]
        //[HttpGet]
        //[Route]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound("User does not exist in database.");
            }
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, User user)
        {
            var userExists = await _userRepository.GetByIdAsync(id);
            if(userExists == null)
            return NotFound("User not found.");  
            
            user.UserId = id;
            await _userRepository.UpdateAsync(user);
            return NoContent();
            
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            
            await _userRepository.DeleteAsync(id);
            return Ok();
        }
        
       
    }
}