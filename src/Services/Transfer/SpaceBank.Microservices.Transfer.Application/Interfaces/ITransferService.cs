using SpaceBank.Microservices.Transfer.Domain.Entities;

namespace SpaceBank.Microservices.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
