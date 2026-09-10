using System.Security.Claims;
using Application.Dtos.LoginDtos;
using Application.Dtos.RegisterDto;
using Application.Dtos.UpdateDtos;
using Application.Interfaces.UserServicesInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        public ValuesController(IUserService us)
        {
            _userService = us;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var result = await _userService.RegisterUser(dto);
            if(!result.isSucces)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _userService.LoginUser(dto);
            if (!result.isSucces) return BadRequest(result.Error);
            return Ok(result.value);
        }
        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _userService.UpdatePassword(Guid.Parse(userId!), dto);
            if (!result.isSucces) return BadRequest(result.Error);
            return Ok();
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userService.GetUserById(id);
            if (!result.isSucces) return NotFound(result.Error);
            return Ok(result.value);
        }
    }
}
