using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Core.Services;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentServices _agentServices;
        public AgentController(IAgentServices agentServices)
        {
            _agentServices = agentServices;
        }

        [HttpGet("get-agent-by-errandId")]
        public async Task<IActionResult> GetUserByErrandId(Guid errandId)
        {
            var agentbyerrand = await _agentServices.GetAgentByErrandIdAsync(errandId);

            return Ok(agentbyerrand);
        }
        [HttpGet("Get-All-Agents")]
        public async Task<IActionResult> GetAllAgents()
        {
            try
            {
                var agents = await _agentServices.GetAllAgents();
                return Ok(agents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
