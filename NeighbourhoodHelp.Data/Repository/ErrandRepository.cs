using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Data.Repository
{
    public class ErrandRepository : IErrandRepository
    {
        private readonly ApplicationDbContext _context;

        public ErrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateErrand(CreateErrandDto createErrand)
        {

            var newErrand = new Errand
            {
                ItemName = createErrand.ItemName,
                Description = createErrand.Description,
                State = createErrand.State,
                City = createErrand.City,
                Street = createErrand.Street,
                PostalCode = createErrand.PostalCode,
                Time = createErrand.Time,
                Date = createErrand.Date,
                Weight = createErrand.Weight,
                Quantity = createErrand.Quantity,
                Note = createErrand.Note,

            };
            await _context.Errands.AddAsync(newErrand);
            var saveChanges = await _context.SaveChangesAsync();
            return "Errand created Successfully";

        }
    }
}
/*var existingUser = await _context.AppUsers.FirstOrDefaultAsync(e => e.Email == appUserDto.Email);
           if (existingUser != null)
           {
               return "User already exist";
           }*/


/*if (saveChanges > 0)
{
    return "Errand created Successfully";
}*/

// return "User could not be added";