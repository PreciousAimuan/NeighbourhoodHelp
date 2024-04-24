
using NeighbourhoodHelp.Model.DTOs;
using NeighbourhoodHelp.Model.Entities;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IPriceRepository
    {
        Task<AgentDto> AgentAcceptPrice(Guid errandId);
        Task<string> AgentCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> AgentDeclinePrice(Guid errandId);
        Task<AgentDto> UserAcceptPrice(Guid errandId);
        Task<string> UserCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> UserDeclinePrice(Guid errandId);
    }
}