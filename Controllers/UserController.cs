using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _userService.RegisterAsync(request);
                return Ok(new { message = "Registration Successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await 
                    _userService.LoginAsync(request);
                
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new {error = ex.Message});
            }
        }
        

























     }
}
