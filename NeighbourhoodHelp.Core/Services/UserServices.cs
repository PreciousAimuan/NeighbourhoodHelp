﻿using NeighbourhoodHelp.Core.IServices;
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
using Microsoft.EntityFrameworkCore;

namespace NeighbourhoodHelp.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IEmailService emailService, IMapper mapper)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _mapper = mapper;
            
        }

        public async Task<string> UserSignUpAsync(UserSignUpDto userSignUpDto)
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

        public async Task<List<GetAppUserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<List<GetAppUserDto>>(users);
        }
    }
}
