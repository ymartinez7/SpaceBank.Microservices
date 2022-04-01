using MediatR;
using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommand : IRequest<int>
    {
        public string? Nombre { get; set; }
        public string? Url { get; set; }
    }
}
