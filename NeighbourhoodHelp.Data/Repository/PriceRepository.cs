using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.Entities;
using NeighbourhoodHelp.Model.Enums;


namespace NeighbourhoodHelp.Data.Repository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly ApplicationDbContext _context;

        public PriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> NegotiatePrice(PriceNegotiation request)
        {
            var errand = await _context.Errands.FindAsync(request.ErrandId);

            if (errand == null)
            {
                return "Errand not found"; // Or any suitable message
            }

            if (request.AgentResponse == AgentResponse.Accept)
            {
                // Assign the errand to the agent
                /*errand.UserId = request.AppUserId;*/
                await _context.SaveChangesAsync();
                return "Errand assigned to the agent.";
            }
            else if (request.AgentResponse == AgentResponse.CounterOffer)
            {
                if (errand.AgentCounterOffers < 2)
                {
                    // Update price request on database
                    errand.Price = request.CounterPrice;
                    errand.AgentCounterOffers++;
                    await _context.SaveChangesAsync();
                    return "Counter offer made.";
                }
                else
                {
                    return "Agent has reached the maximum number of counteroffers.";
                }
            }
            else if (request.AgentResponse == AgentResponse.Decline)
            {
                // Soft delete the errand
                errand.IsDeleted = true;
                await _context.SaveChangesAsync();

                // Reassign the errand to another agent
                try
                {
                    /*await AssignAgentAsync(errand);*/
                    return "Errand reassigned to another agent.";
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    return $"Error: {ex.Message}";
                }
            }

            return "Invalid agent response.";
        }
    }
}