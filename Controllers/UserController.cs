using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Repositories;
using Backend.Models;
using System.Configuration;


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
    }
}