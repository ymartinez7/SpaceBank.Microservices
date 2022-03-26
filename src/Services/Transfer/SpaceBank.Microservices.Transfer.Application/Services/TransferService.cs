using SpaceBank.Microservices.Rabbit.Domain.Core.Bus;
using SpaceBank.Microservices.Transfer.Application.Interfaces;
using SpaceBank.Microservices.Transfer.Domain.Entities;
using SpaceBank.Microservices.Transfer.Domain.Interfaces;

namespace SpaceBank.Microservices.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferLogRepository;
        private readonly IEventBus _eventBus;

        public TransferService(ITransferRepository transferLogRepository, IEventBus eventBus)
        {
            _transferLogRepository = transferLogRepository;
            _eventBus = eventBus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferLogRepository.GetTransferLogs();
        }

        //public void ProcessTransfer(AccountTransfer accountTransfer)
        //{
        //    var createTransferCommand = new CreateTransferCommand(accountTransfer.FromAccount,
        //        accountTransfer.ToAccount,
        //        accountTransfer.TranferAmount);

        //    _eventBus.SendCommand()
        //}
    }
}
