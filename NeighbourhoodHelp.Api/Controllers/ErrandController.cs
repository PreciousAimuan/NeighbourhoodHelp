using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighbourhoodHelp.Data.DTOs;
using NeighbourhoodHelp.Data.IRepository;

namespace NeighbourhoodHelp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrandController : ControllerBase
    {
        private readonly IErrandRepository _errandRepository;
        public ErrandController(IErrandRepository errandRepository)
        {
            _errandRepository = errandRepository;
        }

         
        [HttpPost("create-errand")]
        public async Task<IActionResult> Create([FromBody] CreateErrandDto createErrand)
        {

            var newErrand = await _errandRepository.CreateErrand(createErrand);
            return Ok(newErrand);

        }

    }

}
