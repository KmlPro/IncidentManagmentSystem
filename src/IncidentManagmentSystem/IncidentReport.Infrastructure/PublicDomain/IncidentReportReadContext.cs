using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        private readonly IEnumerable<IQuery<IDto>> _queries;

        public IncidentReportReadContext(IEnumerable<IQuery<IDto>> queries)
        {
            this._queries = queries;
        }

        public IQueryable<DraftApplicationDto> DraftApplications =>
            this.GetQuerylable<DraftApplicationDto>();

        private IQueryable<TDto> GetQuerylable<TDto>() where TDto : IDto
        {
            //kbytner 5.07.2020 - create decidated exception
            if (!(this._queries.First(x => x.GetType() == typeof(IQuery<TDto>)) is IQuery<TDto> query))
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.Get();
        }
    }
}
