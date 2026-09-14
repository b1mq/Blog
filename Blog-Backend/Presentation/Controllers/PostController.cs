using System.Security.Claims;
using Application.Dtos.Post.AddDtos;
using Application.Interfaces.PostServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
        // доделать контроллер 
    {
        private protected IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddNewPost([FromBody] AddPostDto postDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                return Unauthorized();
            }
            var result = await _postService.AddNewPost(postDto,Guid.Parse(userId));
            if(!result.isSucces)
            {
                return BadRequest(result.Error);
            }
            return Ok();

        }
    }
}
