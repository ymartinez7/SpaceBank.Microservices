using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SpaceBank.Microservices.Media.Application.Interfaces.Services;
using SpaceBank.Microservices.Media.Application.Models;
using System.Net;

namespace SpaceBank.Microservices.Media.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly EmailSetting _emailSettings;

        public EmailService(IOptions<EmailSetting> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGrigMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);

            var response = await client.SendEmailAsync(sendGrigMessage);

            if (response.StatusCode != HttpStatusCode.Accepted || response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError($"Ha ocurrido un error al enviar el correo");
                return false;
            }

            return true;
        }
    }
}
