using MediatR;
using SpaceBank.Microservices.Banking.Domain.Commands;
using SpaceBank.Microservices.Banking.Domain.Events;
using SpaceBank.Microservices.Rabbit.Domain.Core.Bus;

namespace SpaceBank.Microservices.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;
        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
