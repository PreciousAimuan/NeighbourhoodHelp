﻿
using NeighbourhoodHelp.Model.DTOs;
using NeighbourhoodHelp.Model.Entities;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IPriceRepository
    {
        Task<AgentDto> AgentAcceptPrice(AgentDto request);
        Task<string> AgentCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> AgentDeclinePrice(AgentDto request);
        Task<AgentDto> UserAcceptPrice(AgentDto request);
        Task<string> UserCounterPrice(PriceNegotiationDto request);
        Task<AgentDto> UserDeclinePrice(AgentDto request);
    }
}