using System.Linq;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.Contract
{
    public interface IIncidentReportReadContext
    {
        IQueryable<DraftApplicationDto> DraftApplications { get; }
    }
}
