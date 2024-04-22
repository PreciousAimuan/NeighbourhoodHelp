using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Core.IServices
{
    public interface IPriceServices
    {
        Task<AgentDto> AgentAcceptPrice(AgentDto request);
        Task<string> AgentCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> AgentDeclinePrice(AgentDto request);
        Task<AgentDto> UserAcceptPrice(AgentDto request);
        Task<string> UserCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> UserDeclinePrice(AgentDto request);
    }
}
