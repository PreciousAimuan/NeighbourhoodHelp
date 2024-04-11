using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeighbourhoodHelp.Core.IServices;
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
        [HttpPost("agent-sign-up")]
        public async Task<IActionResult> AgentSignUp([FromForm] AgentSignUpDto agentSignUpDto)
        {
            var newAgent = await _agentServices.AgentSignUpAsync(agentSignUpDto);

            return Ok("Sign Up Successful. Please Check your email for an OTP");
        }
    }
}
