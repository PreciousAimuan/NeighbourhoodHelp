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
            await _userRepository.CreateUserAsync(userSignUpDto);

            Random rand = new Random();

            int newOtp = rand.Next(100000, 999999); //Generates a random 6 digit number as OTP

            var email = new EmailDto
            {
                To = userSignUpDto.Email,
                Subject = "Verify Your Email",
                UserName = userSignUpDto.FirstName,
                Otp = newOtp
            };
            

            await _emailService.SendEmailAsync(email);
            return("Successful");
        }


        public async Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId)
        {
            return await _userRepository.GetUserByErrandIdAsync(errandId);
        }

        public async Task<object> LoginService(LoginDto loginDto)
        {
            return await _userRepository.Login(loginDto);
        }
    }
}
