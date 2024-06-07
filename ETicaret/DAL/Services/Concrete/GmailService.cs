﻿using DAL.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Concrete
{
    public class GmailService : IMailService
    {
        private ILogger<GmailService> _logger;
        private IConfiguration _configuration;
        private string _username;
        private string _password;
        private SmtpClient _smtpClient = new SmtpClient();

        public GmailService(ILogger<GmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _username = _configuration.GetSection("Mail:UserName").Value;
            _password = Encoding.UTF8.GetString(Convert.FromBase64String(_configuration.GetSection("Mail:Password").Value));

            _smtpClient.Host = "smtp.gmail.com";
            _smtpClient.Port = 587;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(_username, _password);

        }

        public void Send(string email, string displayName, string subject, string body)
        {
            //Gmail mail gönderme

            string log = $"{email} - {subject} - {body} mail gmail servisinden gönderildi.";
            _logger.LogInformation(log);

            MailAddress from = new MailAddress("yasinbagcuvan@gmail.com", "Yasin BAĞÇUVAN");
            MailAddress to = new MailAddress(email, displayName);

            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;
            //message.Body = RenderMailBody();
            message.IsBodyHtml = true;

            _smtpClient.Send(message);
        }
    }
}
