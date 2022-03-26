using Microsoft.EntityFrameworkCore;
using SpaceBank.Microservices.Banking.Domain.Entities;

namespace SpaceBank.Microservices.Banking.Infra.Context
{
    public class BankingDbContext: DbContext
    {
       public DbSet<Account> Accounts { get; set; }

        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {

        }
    }
}
