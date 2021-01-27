using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Infrastructure.Persistence.Repositories.AsyncGenericRepository
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetById(TypedIdValue id, CancellationToken token);
        Task Create(T entity, CancellationToken token);
        void Update(T entity);
        Task Delete(TypedIdValue id, CancellationToken token);
        Task<bool> IsExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
