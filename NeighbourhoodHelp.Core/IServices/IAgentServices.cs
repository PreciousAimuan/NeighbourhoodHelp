using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourhoodHelp.Core.IServices
{
    public interface IAgentServices
    {
        Task<ErrandDto> GetAgentByErrandIdAsync(Guid errandId);
    }
}
