using SpaceBank.Microservices.Transfer.Domain.Entities;

namespace SpaceBank.Microservices.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void AddTransferLog(TransferLog log);
    }
}
