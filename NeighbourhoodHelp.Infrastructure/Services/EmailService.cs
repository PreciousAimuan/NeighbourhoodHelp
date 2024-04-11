﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NeighbourhoodHelp.Infrastructure.Interfaces;
using NeighbourhoodHelp.Model.DTOs;

namespace NeighbourhoodHelp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(EmailDto emailDto)
        {
            string body = PopulateRegisterEmail(emailDto.UserName, emailDto.Otp.ToString());

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Neighbourhood Help", _config["EmailSettings:Username"])); // Replace with your email address
            message.To.Add(new MailboxAddress("", emailDto.To)); // Replace with recipient email address
            message.Subject = emailDto.Subject;
            
            var builder = new BodyBuilder();
            builder.HtmlBody = body;

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_config["EmailSettings:Host"], 587, false);
                await client.AuthenticateAsync(_config["EmailSettings:Username"], _config["EmailSettings:Password"]); // Replace with your Gmail credentials
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        private string PopulateRegisterEmail(string UserName, string Otp)
        {
            string body = string.Empty;

            string filePath = Directory.GetCurrentDirectory() + @"\Templates\SignUpEmail.html";   //getting the filepath of the email template

            using (var reader = new StreamReader(filePath))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{UserName}", UserName);
            body = body.Replace("{Otp}", Otp);

            return body;
        }
    }
}
