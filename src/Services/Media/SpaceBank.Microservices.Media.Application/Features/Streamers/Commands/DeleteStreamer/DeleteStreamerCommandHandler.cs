using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SpaceBank.Microservices.Media.Application.Exceptions;
using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;
using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository,
            ILogger<DeleteStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToDelete == null)
            {
                _logger.LogError($"No se encontró el streamer Id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            await _streamerRepository.DeleteAsync(streamerToDelete);
            _logger.LogInformation($"El {request.Id} fue eliminado cin éxito");
            return Unit.Value;
        }
    }
}
