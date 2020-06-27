using System.Linq;
using IncidentReport.PublicDomain.DraftApplications;

namespace IncidentReport.PublicDomain
{
    public interface IReadIncidentReportContext
    {
        public IQueryable<DraftApplicationDto> DraftApplications { get; }
    }
}
