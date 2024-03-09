using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.BL;

namespace SuperMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService userService;
        
        public AuthController(IAuthService _userService)
        {
            userService = _userService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await userService.RegisterAsync(dto);

            if(!result.IsAuthenticated)
                return BadRequest(result.Masseage);

            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await userService.LoginAsync(dto);

            if(!result.IsAuthenticated)
                return BadRequest(result.Masseage);

            return Ok(result);
        }
    }
}
