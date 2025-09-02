using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using User.Entities.Read;
using User.Infrastructure.EF.Interfaces;

namespace InmoSys.Controllers.Users.Read
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
         }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login([FromBody] UserLoginRequest request)
        {
            var result = await _userRepository.LoginAsync(request);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
