using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Infrastructure.Helpers;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrandController : ControllerBase
    {
        private readonly IErrandServices _errandServices;

        public ErrandController(IErrandServices errandServices)
        {
            _errandServices = errandServices;
        }

         
        [HttpPost("create-errand")]
        public async Task<IActionResult> Create([FromBody] CreateErrandDto createErrand)
        {

            var newErrand = await _errandServices.CreateErrand(createErrand);
            return Ok(newErrand);

        }

        [HttpGet("get-errands-by-userId")]
        public async Task<IActionResult> GetAllErrandsByAppUserId(Guid userId, [FromQuery] PaginationParameters paginParams)
        {
            try
            {
                var userErrands = await _errandServices.GetAllErrandsByAppUserIdServiceAsync(userId, paginParams);

                if (userErrands == null || userErrands.Count == 0)
                {
                    return NotFound("No errand found for the specified user");
                }

                return Ok(userErrands);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("get-errands-by-agentId")]
        public async Task<IActionResult> GetAllErrandsByAgentId(Guid agentId, [FromQuery] PaginationParameters paginParams)
        {
            try
            {
                var agentErrands = await _errandServices.GetAllErrandsByAgentIdServiceAsync(agentId, paginParams);

                if (agentErrands == null || agentErrands.Count == 0)
                {
                    return NotFound("The specified agent has no completed errand");
                }

                return Ok(agentErrands);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetPendingErrandByAgentId")]
        public async Task<IActionResult> GetPendingErrands(Guid agentId)
        {
            var pendingErrands = await _errandServices.GetPendingErrandByAgentId(agentId);
            return Ok(pendingErrands);
        }





    }

}
