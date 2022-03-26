using SpaceBank.Microservices.Banking.Application.Interfaces;
using SpaceBank.Microservices.Banking.Domain.Commands;
using SpaceBank.Microservices.Banking.Domain.Entities;
using SpaceBank.Microservices.Banking.Domain.Interfaces;
using SpaceBank.Microservices.Rabbit.Domain.Core.Bus;

namespace SpaceBank.Microservices.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TranferAmount);

            _eventBus.SendCommand(createTransferCommand);
        }
    }
}
