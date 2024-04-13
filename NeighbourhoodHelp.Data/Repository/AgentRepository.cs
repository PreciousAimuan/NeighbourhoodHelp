using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Model.Entities;

namespace NeighbourhoodHelp.Data.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext _context;

        public AgentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ErrandDto> GetAgentByErrandIdAsync(Guid errandId)
        {
            var errand = new Errand
            {
                /*Id = new Guid(),
                Description = "Perfume",
                Street = "ParkLand Estate",
                City = "Port Harcourt",
                State = "Rivers State",
                PostalCode = "5002070",
                Time = "4:00pm",
                Date = "15/4/2024",
                ItemName = "Black Oud",
                Weight = "70",
                Note = "No note",
                UserId = Guid.Parse("0c1837ba-4a03-4dca-a868-26b2a5e4b73e")*/
            };
            _context.Errands.Add(errand);
            _context.SaveChangesAsync();

            var Errands = await _context.Errands.Include(c => c.Agent).FirstOrDefaultAsync(c => c.Id == errandId);
            var agentErrandId = new ErrandDto
            {/*
                FirstName = Errands.Agent.FirstName,
                LastName = Errands.Agent.LastName,
                PostalCode = Errands.Agent.PostalCode,
                Street = Errands.Agent.Street,
                City = Errands.Agent.City,
                State = Errands.Agent.State,
                PhoneNumber = Errands.Agent.PhoneNumber,*/



            };
            return agentErrandId;


        }
    }
}

