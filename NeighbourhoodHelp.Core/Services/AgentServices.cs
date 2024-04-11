using NeighbourhoodHelp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighbourhoodHelp.Core.IServices;
using NeighbourhoodHelp.Data.IRepository;
using NeighbourhoodHelp.Infrastructure.Interfaces;

namespace NeighbourhoodHelp.Core.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IEmailService _emailService;

        public AgentServices(IAgentRepository agentRepository, IEmailService emailService)
        {
            _agentRepository = agentRepository;
            _emailService = emailService;
        }
        public async Task<string> AgentSignUpAsync(AgentSignUpDto agentSignUpDto)
        {
            await _agentRepository.CreateAgentAsync(agentSignUpDto);

            Random rand = new Random();

            int newOtp = rand.Next(100000, 999999); //Generates a random 6 digit number as OTP

            var email = new EmailDto
            {
                To = agentSignUpDto.Email,
                Subject = "Verify Your Email",
                UserName = agentSignUpDto.FirstName,
                Otp = newOtp
            };
            

            await _emailService.SendEmailAsync(email);
            return("Successful");
        }
    }
}
