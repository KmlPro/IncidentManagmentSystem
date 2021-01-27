using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.Repositories.AsyncGenericRepository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private IncidentReportWriteDbContext _context;

        public AsyncRepository(IncidentReportWriteDbContext context)
        {
            this._context = context;
        }

        public async Task<T> GetById(TypedIdValue id, CancellationToken token)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await this._context.Set<T>().FindAsync(new object[]{id}, token);

            if (entity == null)
            {
                throw new AggregateNotFoundInDbException(nameof(Application), id.Value);
            }

            return entity;
        }

        public async Task Create(T entity, CancellationToken token)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await this._context.Set<T>().AddAsync(entity, token);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this._context.Set<T>().Update(entity);
        }

        public async Task Delete(TypedIdValue id, CancellationToken token)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = await this._context.Set<T>().FindAsync(id, token);

            if (entity == null)
            {
                throw new AggregateNotFoundInDbException(nameof(Application), id.Value);
            }

            this._context.Set<T>().Remove(entity);
        }

        public async Task<bool> IsExists(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await this._context.Set<T>().AnyAsync(predicate,
                cancellationToken);
        }
    }
}
