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
        Task<AgentDto> AgentAcceptPrice(Guid errandId);
        Task<string> AgentCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> AgentDeclinePrice(Guid errandId);
        Task<AgentDto> UserAcceptPrice(Guid errandId);
        Task<string> UserCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> UserDeclinePrice(Guid errandId);
    }
}
