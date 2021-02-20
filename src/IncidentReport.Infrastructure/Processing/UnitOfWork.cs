using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using BuildingBlocks.Infrastructure;
using IncidentReport.Infrastructure.Persistence;

namespace IncidentReport.Infrastructure.Processing
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IncidentReportWriteDbContext _context;

        public UnitOfWork(IncidentReportWriteDbContext context)
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
