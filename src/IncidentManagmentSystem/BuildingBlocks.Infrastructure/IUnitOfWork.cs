using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace BuildingBlocks.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        TransactionScope BeginTransaction();
    }
}
