using Microsoft.AspNetCore.Mvc;
using LoginApp.DTOs;
using LoginApp.Interface;
using Microsoft.AspNetCore.Authorization;

namespace LoginApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO userDto)
        {
            try
            {
                _userService.RegisterUser(userDto);
                return Ok(new { Message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var response = _userService.ValidateLogin(loginDto);
                return Ok(new
                {
                    Message = "Login successful",
                    Token = response.Token,
                    Username = response.Username
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
