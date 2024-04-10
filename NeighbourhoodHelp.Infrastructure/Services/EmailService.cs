using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NeighbourhoodHelp.Infrastructure.Interfaces;

namespace NeighbourhoodHelp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Neighbourhood Help", _config["EmailSettings:Username"])); // Replace with your email address
            message.To.Add(new MailboxAddress("", toEmail)); // Replace with recipient email address
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_config["EmailSettings:Host"], 587, false);
                await client.AuthenticateAsync(_config["EmailSettings:Username"], _config["EmailSettings:Password"]); // Replace with your Gmail credentials
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
