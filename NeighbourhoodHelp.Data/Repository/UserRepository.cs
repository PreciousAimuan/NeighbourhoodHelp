using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.Entities;
using NeighbourhoodHelp.Model.DTOs;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NeighbourhoodHelp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NeighbourhoodHelp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserRepository(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<CompleteSignUpDto> CreateUserAsync(SignUpDto signUpDto)
        {
         
            var appUser = _mapper.Map<AppUser>(signUpDto);

            
            Random rand = new Random();

            string newOtp = rand.Next(100000, 999999).ToString(); //Generates a random 6 digit number as OTP
            appUser.Otp = newOtp;

            var email = new EmailDto
            {
                To = signUpDto.Email,
                Subject = "Verify Your Email",
                UserName = signUpDto.FirstName,
                Otp = newOtp
            };

            await _emailService.SendEmailAsync(email);

            

            var createUserResult = await _userManager.CreateAsync(appUser, signUpDto.Password);
                if (!createUserResult.Succeeded)
                {
                    return new CompleteSignUpDto
                    {
                        Message = "Failed to create user"
                    };
                }

                IdentityResult roleUp = null;

                if (signUpDto.Role.Equals("user", StringComparison.OrdinalIgnoreCase))
                    roleUp = await _userManager.AddToRoleAsync(appUser, "User");
                else
                {
                    roleUp = await _userManager.AddToRoleAsync(appUser, "Agent");
                }

                if (!roleUp.Succeeded)
                {
                    return new CompleteSignUpDto
                    {
                        Message = "Failed to add user to role."
                    };
                }
                    

                await _context.SaveChangesAsync();

                return new CompleteSignUpDto
                {
                    UserId = appUser.Id,
                    Message = appUser.Role
                };
        }
        

        public async Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId)
        {
            /*var errand = new Errand
            {
                Id = new Guid(),
                Description = "Radio Fm",
                Street = "Akeem Alao",
                City = "Ikeja",
                State = "Lagos",
                PostalCode = "5002070",
                Time = "3:00pm",
                Date = "12/6/2024",
                ItemName = "Radio",
                Weight = "40",
                Note = "No note",
                UserId = Guid.Parse("272995d6-7a08-4dc9-9a91-fb6d6d2601f4")
            };
            _context.Errands.Add(errand);
            _context.SaveChangesAsync();*/


            var Errands = await _context.Errands.Include(c => c.AppUser).FirstOrDefaultAsync(c => c.Id == errandId);
            var userByErrandId = new ErrandDto
            {
                FirstName = Errands.AppUser.FirstName,
                LastName = Errands.AppUser.LastName,
                Street = Errands.AppUser.Street,
                City = Errands.AppUser.City,
                State = Errands.AppUser.State,
                PhoneNumber = Errands.AppUser.PhoneNumber,
                Email = Errands.AppUser.Email,
               

            };
            return userByErrandId;
        }

        public async Task<string> ForgotPassword(string email)
        {
            // Find the user by email
            var user = await _context.appUsers.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                // User not found
                return "User not found";
            }

            // Generate a new password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Construct the password reset link with token
            var resetLink = $"https://yourwebsite.com/resetpassword?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}";

            // You can send an email with the password reset link to the user
            var emailContent = new EmailDto
            {
                To = email,
                Subject = "Password Reset",
                Body = $"https://yourwebsite.com/resetpassword?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}"
            };

            await _emailService.SendForgotPasswordEmailAsync(emailContent);

            // Construct the email subject and body
            /* var subject = "Password Reset";
             var body = $"Please click the following link to reset your password: {resetLink}";*/

            // Send the password reset email
           /* await _emailService.SendForgotPasswordEmailAsync(email, subject, body);*/

            return token;
        }

        public async Task<string> ResetPassword(string email, string token, string newPassword)
        {
            // Find the user by email
            var user = await _context.appUsers.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                // User not found
                return "User not found";
            }

            // Reset the password
            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (resetPasswordResult.Succeeded)
            {
                return "Password reset successfully";
            }
            else
            {
                // Password reset failed
                return "Failed to reset password";
            }
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return false; // User not found
            }

            if (user.Otp == otp)
            {
                // OTP matched, set IsVerified to true and update the user
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                // Reset the OTP after verification
                user.Otp = "";
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return true; // OTP verified successfully
                }

                
            }

            return false; // OTP verification failed
        }



    }
}
