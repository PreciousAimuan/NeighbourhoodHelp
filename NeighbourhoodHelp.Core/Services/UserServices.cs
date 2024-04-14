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

        public async Task<CompleteSignUpDto> UserSignUpAsync(SignUpDto signUpDto)
        {
            var user = await _userRepository.CreateUserAsync(signUpDto);

            Random rand = new Random();

            int newOtp = rand.Next(100000, 999999); //Generates a random 6 digit number as OTP

            var email = new EmailDto
            {
                To = signUpDto.Email,
                Subject = "Verify Your Email",
                UserName = signUpDto.FirstName,
                Otp = newOtp
            };

            await _emailService.SendEmailAsync(email);
            return user;
        }


        public async Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId)
        {
            return await _userRepository.GetUserByErrandIdAsync(errandId);
        }

        public async Task<string> ForgotPassword(string email)
        {
            return await _userRepository.ForgotPassword(email);
        }

        public async Task<string> ResetPassword(string email, string token, string newPassword)
        {
            return await _userRepository.ResetPassword(email, token, newPassword);
        }
    }
}
