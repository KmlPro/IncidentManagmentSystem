using System;
using System.Linq;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        private readonly Func<Type, IQuery> _queries;
        public IncidentReportReadContext(Func<Type, IQuery> queries)
        {
            this._queries = queries;
        }

        public IQueryable<DraftApplicationDto> DraftApplications =>
            this.GetQueryable<DraftApplicationDto>();

        private IQueryable<TDto> GetQueryable<TDto>() where TDto : IDto
        {
            var query = (IQuery<TDto>)this._queries(typeof(TDto));
            if (query == null)
            {
                throw new QueryNotFoundException($"Query for {typeof(TDto)} is not implemented");
            }

            return query.Get();
        }
    }
}
