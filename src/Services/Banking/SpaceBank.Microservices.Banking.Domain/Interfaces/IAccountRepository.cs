using SpaceBank.Microservices.Banking.Domain.Entities;

namespace SpaceBank.Microservices.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
