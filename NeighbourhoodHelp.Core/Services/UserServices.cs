using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NeighbourhoodHelp.Infrastructure.Interfaces;
using NeighbourhoodHelp.Model.Entities;

namespace NeighbourhoodHelp.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserServices(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<string> UserSignUpAsync(SignUpDto userSignUpDto)
        {

            var result = await _userRepository.CreateUserAsync(signUpDto);
            return result;
           

        }


        public async Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId)
        {
            return await _userRepository.GetUserByErrandIdAsync(errandId);
        }

        public async Task<object> LoginService(LoginDto loginDto)
        {
            return await _userRepository.Login(loginDto);
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            return await _userRepository.VerifyOtpAsync(email, otp);
        }

    }
}
