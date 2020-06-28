using System.Linq;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public interface IReadIncidentReportDbContext
    {
        public IQueryable<DraftApplicationDto> DraftApplications { get; }
    }
}
