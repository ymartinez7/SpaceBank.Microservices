﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;
using SpaceBank.Microservices.Media.Application.Interfaces.Services;
using SpaceBank.Microservices.Media.Application.Models;
using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository,
            IMapper mapper,
            IEmailService emailService,
            ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamer);
            _logger.LogInformation($"Streamer {newStreamer.Id} fue creado exitosamente");
            await SendEmail(newStreamer);
            return newStreamer.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "ymartinez7@gmail.com",
                Body = "La comoañia de streamer se creó correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email de {streamer.Id}", ex);
            }
        }
    }
}
