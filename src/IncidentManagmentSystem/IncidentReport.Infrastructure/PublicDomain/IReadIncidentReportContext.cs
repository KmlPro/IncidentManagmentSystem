using System.Linq;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public interface IReadIncidentReportContext
    {
        public IQueryable<DraftApplicationDto> DraftApplications { get; }
    }
}
