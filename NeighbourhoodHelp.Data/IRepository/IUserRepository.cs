
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IUserRepository
    {
        Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId);
    }
}
