using SpaceBank.Microservices.Rabbit.Domain.Core.Events;

namespace SpaceBank.Microservices.Rabbit.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler { }
}
