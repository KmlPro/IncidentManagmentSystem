using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(
            DbContext context)
        {
            this._context = context;
        }

        public TransactionScope BeginTransaction()
        {
            return new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled);
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}