using SpaceBank.Microservices.Banking.Domain.Entities;
using SpaceBank.Microservices.Banking.Domain.Interfaces;
using SpaceBank.Microservices.Banking.Infra.Context;

namespace SpaceBank.Microservices.Banking.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _dbContext;

        public AccountRepository(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _dbContext.Accounts;
        }
    }
}
