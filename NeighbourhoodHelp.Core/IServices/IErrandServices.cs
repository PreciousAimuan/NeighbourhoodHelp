using NeighbourhoodHelp.Infrastructure.Helpers;
using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Core.IServices
{
    public interface IErrandServices
    {
        Task<IList<GetErrandDto>> GetAllErrandsByAppUserIdServiceAsync(Guid userId, PaginationParameters paginParams);
        Task<IList<GetErrandDto>> GetAllErrandsByAgentIdServiceAsync(Guid agentId, PaginationParameters paginParams);
    }
}
