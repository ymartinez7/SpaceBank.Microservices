using SpaceBank.Microservices.Transfer.Domain.Entities;
using SpaceBank.Microservices.Transfer.Domain.Interfaces;
using SpaceBank.Microservices.Transfer.Infra.Context;

namespace SpaceBank.Microservices.Transfer.Infra.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _dbContext;

        public TransferRepository(TransferDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTransferLog(TransferLog log)
        {
            _dbContext.TransferLogs.Add(log);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _dbContext.TransferLogs;
        }
    }
}
