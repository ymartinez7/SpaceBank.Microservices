using SpaceBank.Microservices.Rabbit.Domain.Core.Events;

namespace SpaceBank.Microservices.Rabbit.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
