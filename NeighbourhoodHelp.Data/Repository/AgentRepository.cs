using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Model.DTOs;
using NeighbourhoodHelp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NeighbourhoodHelp.Data.IRepository;

namespace NeighbourhoodHelp.Data.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Agent> _userManager;
        private readonly IMapper _mapper;
        public AgentRepository(ApplicationDbContext context, UserManager<Agent> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<string> CreateAgentAsync(AgentSignUpDto agentSignUpDto)
        {
            try
            {
                var agent = _mapper.Map<Agent>(agentSignUpDto);

                var createAgentResult = await _userManager.CreateAsync(agent, agentSignUpDto.Password);
                if (!createAgentResult.Succeeded)
                    return ("Failed to create user.");

                var roleUp = await _userManager.AddToRoleAsync(agent, "Agent");

                if (!roleUp.Succeeded)
                    return ("Failed to add to role.");

                _context.agents.Add(agent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ("An error occurred while creating user and adding to role.");
            }

            
            return "Successful";
        }
    }
}
