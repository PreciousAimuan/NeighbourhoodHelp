using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Core.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepository _agentRepository;

        public AgentServices(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<ErrandDto> GetAgentByErrandIdAsync(Guid errandId)
        {
            return await _agentRepository.GetAgentByErrandIdAsync(errandId);
        }
    }
}
