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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<string> CreateUserAsync(SignUpDto userSignUpDto)
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

        public async Task<object> Login(LoginDto loginDto)
        {

            //check if user is valid
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email); //compares the Email with existing Email

            if (user == null) return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return null;

            // Get user role
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            // Generate token
            var token = _tokenService.CreateToken(user);
            var loggedin = new LoggedInUserDto
            {
                token = token,
                email = loginDto.Email,
                role = role
            };


            return loggedin;

        }
    }
}
