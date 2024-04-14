using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Infrastructure.Helpers;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Core.Services
{
    public class ErrandServices : IErrandServices
    {
        private readonly IErrandRepository _errandRepository;

        public ErrandServices(IErrandRepository errandRepository)
        {
            _errandRepository = errandRepository;
        }
        public async Task<IList<GetErrandDto>> GetAllErrandsByAppUserIdServiceAsync(Guid userId, PaginationParameters paginParams)
        {
            return await _errandRepository.GetAllErrandsByAppUserIdAsync(userId, paginParams);
        }

        public async Task<IList<GetErrandDto>> GetAllErrandsByAgentIdServiceAsync(Guid agentId, PaginationParameters paginParams)
        {
            return await _errandRepository.GetAllErrandsByAgentIdAsync(agentId, paginParams);
        }
    }
}
