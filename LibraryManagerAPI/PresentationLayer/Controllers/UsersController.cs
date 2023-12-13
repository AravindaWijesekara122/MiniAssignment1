using Azure.Messaging;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                _userService.AddUser(user);
                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            Console.WriteLine("all");
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost("login")]
        public IActionResult Login(User user) 
        {
            try
            {              
                bool isLogin = _userService.IsUserExist(user);
                if (isLogin)
                {
                    Console.WriteLine(user.Username, user.Password);
                    return Ok(user);
                }
                return BadRequest(user);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }


        // Add other actions as needed
    }
}
