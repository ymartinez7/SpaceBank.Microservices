using SpaceBank.Microservices.Media.Application.Models;

namespace SpaceBank.Microservices.Media.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
