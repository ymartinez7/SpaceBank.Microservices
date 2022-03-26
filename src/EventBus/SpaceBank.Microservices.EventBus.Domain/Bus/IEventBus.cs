﻿using SpaceBank.Microservices.Rabbit.Domain.Core.Commands;
using SpaceBank.Microservices.Rabbit.Domain.Core.Events;

namespace SpaceBank.Microservices.Rabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() where T : Event
                                where TH : IEventHandler<T>;
    }
}
