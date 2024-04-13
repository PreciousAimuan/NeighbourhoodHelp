using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Infrastructure.Interfaces;
using NeighbourhoodHelp.Data.Repository;
using AutoMapper;

namespace NeighbourhoodHelp.Core.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepository _agentRepository;

        private readonly IMapper _mapper;

        public AgentServices(IAgentRepository agentRepository, IMapper mapper)
        {
           
            _agentRepository = agentRepository;
            
            _mapper = mapper;
        }

        public Task<string> AgentSignUpAsync(AgentSignUpDto agentSignUpDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ErrandDto> GetAgentByErrandIdAsync(Guid errandId)
        {
            return await _agentRepository.GetAgentByErrandIdAsync(errandId);
        }
        public async Task<List<GetAgentDto>> GetAllAgents()
        {
            var agents = await _agentRepository.GetAllAgents();
            return _mapper.Map<List<GetAgentDto>>(agents);
        }
    }
}
