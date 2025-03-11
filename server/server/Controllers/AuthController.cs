using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Entities;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthServices authServices) : ControllerBase
    {
        public static User user = new User();


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            var user = await authServices.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Username already exists");
            }

            return Ok(user);
        }
    }
}
