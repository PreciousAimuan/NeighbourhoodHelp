using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Model.DTOs;
using NeighbourhoodHelp.Model.Entities;
using NeighbourhoodHelp.Model.Enums;


namespace NeighbourhoodHelp.Data.Repository
{
    public class PriceRepository : IPriceRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IAgentRepository _agentRepository;
    private readonly IMapper _mapper;

    public PriceRepository(ApplicationDbContext context, IAgentRepository agentRepository, IMapper mapper)
    {
        _context = context;
        _agentRepository = agentRepository;
        _mapper = mapper;
    }

    public async Task<AgentDto> AgentAcceptPrice(AgentDto request)
    {
        var errand = await _context.Errands.FindAsync(request.ErrandId);

        if (errand == null)
        {
            return null;
        }

        // Assign the errand to the agent
        var agent = await _context.agents.FirstOrDefaultAsync(a => a.AppUser.ErrandId == request.ErrandId); /*user that made a request matches an agent that is a user*/

        if (agent != null)
        {
            var agentDetail = _mapper.Map<AgentDto>(agent.AppUser);
            await _context.SaveChangesAsync();
            return agentDetail;
        }
        else
        {
            return null;
        }
    }

    public async Task<string> AgentCounterPrice(PriceNegotiationDto request)
    {
        var errand = await _context.Errands.FindAsync(request.ErrandId);

        if (errand == null)
        {
            return "Errand not found";
        }

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

    public async Task<AgentDto> AgentDeclinePrice(AgentDto request)
    {
        var errand = await _context.Errands.FindAsync(request.ErrandId);

        if (errand == null)
        {
            return null; // or you can throw an exception or handle it as you prefer
        }

        // Soft delete the errand
        errand.IsDeleted = true;
        await _context.SaveChangesAsync();

        // Mark the agent as deleted (assuming you want to soft delete the agent)
        var agent = await _context.agents.FirstOrDefaultAsync(a => a.AppUser.ErrandId == request.ErrandId);
        if (agent != null)
        {
            agent.IsDeleted = true;
            await _context.SaveChangesAsync(); // Save changes to mark agent as deleted
        }

        // Reassign the errand to another agent
        try
        {
            var assignedAgent = await _agentRepository.AssignAgentAsync(errand);
            var agentDetail = _mapper.Map<AgentDto>(assignedAgent.AppUser);
            await _context.SaveChangesAsync();
            return agentDetail;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }
    }


    public async Task<AgentDto> UserAcceptPrice(AgentDto request)
    {
        var errand = await _context.Errands.FindAsync(request.ErrandId);

        if (errand == null)
        {
            return null;
        }

        // Assign the errand to the agent
        var agent = await _context.agents.FirstOrDefaultAsync(a => a.AppUser.ErrandId == request.ErrandId); /*user that made a request matches an agent that is a user*/

        if (agent != null)
        {
            var agentDetail = _mapper.Map<AgentDto>(agent.AppUser);
            await _context.SaveChangesAsync();
            return agentDetail;
        }
        else
        {
            return null;
        }
    }


    public async Task<string> UserCounterPrice(PriceNegotiationDto request)
    {
        var errand = await _context.Errands.FindAsync(request.ErrandId);

        if (errand == null)
        {
            return "Errand not found";
        }

        if (errand.UserCounterOffers < 1)
        {
            // Update price request on database
            errand.Price = request.CounterPrice;
            errand.UserCounterOffers++;
            await _context.SaveChangesAsync();
            return "Counter offer made.";
        }
        else
        {
            return "User has reached the maximum number of counteroffers.";
        }
    }

    public async Task<AgentDto> UserDeclinePrice(AgentDto request)
    {
        var errand = await _context.Errands.FindAsync(request.ErrandId);

        if (errand == null)
        {
            return null; // or you can throw an exception or handle it as you prefer
        }

        // Soft delete the errand
        errand.IsDeleted = true;
        await _context.SaveChangesAsync();

        // Mark the agent as deleted (assuming you want to soft delete the agent)
        var agent = await _context.agents.FirstOrDefaultAsync(a => a.AppUser.ErrandId == request.ErrandId);
        if (agent != null)
        {
            agent.IsDeleted = true;
            await _context.SaveChangesAsync(); // Save changes to mark agent as deleted
        }

        // Reassign the errand to another agent
        try
        {
            var assignedAgent = await _agentRepository.AssignAgentAsync(errand);
            var agentDetail = _mapper.Map<AgentDto>(assignedAgent.AppUser);
            await _context.SaveChangesAsync();
            return agentDetail;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }
    }

}
}