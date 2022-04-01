using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SpaceBank.Microservices.Media.Application.Exceptions;
using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;
using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreamerCommandHandler> _logger;

        public UpdateStreamerCommandHandler(IStreamerRepository streamerRepository,
            IMapper mapper,
            ILogger<UpdateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdte =  await _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdte == null)
            {
                _logger.LogError($"No se encontró el streamer Id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdte, typeof(UpdateStreamerCommand), typeof(Streamer));
            await _streamerRepository.UpdateAsync(streamerToUpdte);
            _logger.LogInformation($"Se actualizó el streamer {request.Id}");

            return Unit.Value;
        }
    }
}
