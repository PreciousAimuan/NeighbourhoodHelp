using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.Entities;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ErrandDto> GetUserByErrandIdAsync(Guid errandId)
        {
            var errand = new Errand
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
                Weight = 40,
                Note = "No note",
                UserId = Guid.Parse("272995d6-7a08-4dc9-9a91-fb6d6d2601f4")
            };
            _context.Errands.Add(errand);
            _context.SaveChangesAsync();


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
    }
}
