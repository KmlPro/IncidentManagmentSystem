using System.Linq;
using Autofac;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        public IQueryable<DraftApplicationDto> DraftApplications => this.GetQuerylable<DraftApplicationDto, GetDraftApplicationQuery>();

        private IQueryable<TDto> GetQuerylable<TDto, TQuery>() where TDto: IDto
                                                               where TQuery: IQuery<TDto>
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var query = scope.Resolve<TQuery>();

                return query.Get();
            }
        }           
    }
}
