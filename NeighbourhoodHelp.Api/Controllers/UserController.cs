using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighbourhoodHelp.Core.IServices;

namespace NeighbourhoodHelp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet("errandId")]
        public async Task<IActionResult> GetUserByErrandId(Guid errandId)
        {
            var userbyerrand = await _userService.GetUserByErrandIdAsync(errandId);

            return Ok(userbyerrand);
        }

    }
}
