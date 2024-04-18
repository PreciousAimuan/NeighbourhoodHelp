
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Core.IServices
{
    public interface IUserServices
    {
        Task<string> UserSignUpAsync(SignUpDto userSignUpDto);
        Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId);


        Task<object> LoginService(LoginDto loginDto);

        Task<string> ForgotPassword(string email);
        Task<string> ResetPassword(string email, string token, string newPassword);
        Task<bool> VerifyOtpAsync(string email, string otp);


    }
}
