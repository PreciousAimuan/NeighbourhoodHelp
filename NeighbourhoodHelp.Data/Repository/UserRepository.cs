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
        public async Task<string> CreateUserAsync(UserSignUpDto userSignUpDto)
        {
            try
            {
                var appUser = _mapper.Map<AppUser>(userSignUpDto);

                var createUserResult = await _userManager.CreateAsync(appUser, userSignUpDto.Password);
                if (!createUserResult.Succeeded)
                    return ("Failed to create user.");

                var roleUp = await _userManager.AddToRoleAsync(appUser, "User");

                if (!roleUp.Succeeded)
                    return ("Failed to add to role.");

                _context.appUsers.Add(appUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ("An error occurred while creating user and adding to role.");
            }

            
            return "Successful";
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
    }
}
