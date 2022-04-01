using MediatR;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommand : IRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}
