using Microsoft.EntityFrameworkCore;
using SpaceBank.Microservices.Transfer.Domain.Entities;

namespace SpaceBank.Microservices.Transfer.Infra.Context
{
    public class TransferDbContext : DbContext
    {
        public DbSet<TransferLog> TransferLogs { get; set; }

        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {

        }
    }
}
