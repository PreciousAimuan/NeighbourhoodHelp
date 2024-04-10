
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Core.IServices
{
    public interface IUserServices
    {
        Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId);
    }
}
