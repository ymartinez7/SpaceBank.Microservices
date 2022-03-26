using SpaceBank.Microservices.Banking.Domain.Entities;

namespace SpaceBank.Microservices.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
