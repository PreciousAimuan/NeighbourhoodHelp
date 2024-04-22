using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Core.Services
{
    public class PriceServices : IPriceServices
    {
        private readonly IPriceRepository _priceRepository;

        public PriceServices(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<AgentDto> AgentAcceptPrice(AgentDto request)
        {
            // Add any business logic or validation here if needed
            return await _priceRepository.AgentAcceptPrice(request);
        }

        public async Task<string> AgentCounterPrice(PriceNegotiationDto request)
        {
            // Add any business logic or validation here if needed
            return await _priceRepository.AgentCounterPrice(request);
        }

        public async Task<AgentDto> AgentDeclinePrice(AgentDto request)
        {
            // Add any business logic or validation here if needed
            return await _priceRepository.AgentDeclinePrice(request);
        }

        public async Task<AgentDto> UserAcceptPrice(AgentDto request)
        {
            // Add any business logic or validation here if needed
            return await _priceRepository.UserAcceptPrice(request);
        }

        public async Task<string> UserCounterPrice(PriceNegotiationDto request)
        {
            // Add any business logic or validation here if needed
            return await _priceRepository.UserCounterPrice(request);
        }

        public async Task<AgentDto> UserDeclinePrice(AgentDto request)
        {
            // Add any business logic or validation here if needed
            return await _priceRepository.UserDeclinePrice(request);
        }
    }
}
