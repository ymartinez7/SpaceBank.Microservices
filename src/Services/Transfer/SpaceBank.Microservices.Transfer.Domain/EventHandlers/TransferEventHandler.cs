using SpaceBank.Microservices.Rabbit.Domain.Core.Bus;
using SpaceBank.Microservices.Transfer.Domain.Entities;
using SpaceBank.Microservices.Transfer.Domain.Events;
using SpaceBank.Microservices.Transfer.Domain.Interfaces;

namespace SpaceBank.Microservices.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            var transaction = new TransferLog
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            };

            _transferRepository.AddTransferLog(transaction);

            return Task.CompletedTask;
        }
    }
}
