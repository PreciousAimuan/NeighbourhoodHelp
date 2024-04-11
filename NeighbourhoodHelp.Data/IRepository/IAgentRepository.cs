using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IAgentRepository
    {
        Task<string> CreateAgentAsync(AgentSignUpDto agentSignUpDto);
    }
}
