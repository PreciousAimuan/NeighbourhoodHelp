
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NeighbourhoodHelp.Model.DTOs;
using NeighbourhoodHelp.Model.Entities;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(SignUpDto userSignUpDto);
        Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId);

        Task<object> Login(LoginDto loginDto);
    }
}
