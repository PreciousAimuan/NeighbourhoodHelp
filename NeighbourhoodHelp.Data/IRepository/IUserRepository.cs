
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
        Task<CompleteSignUpDto> CreateUserAsync(SignUpDto signUpDto);
        Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId);
        Task<string> ForgotPassword(string email);
        Task<string> ResetPassword(string email, string token, string newPassword);
    }
}
