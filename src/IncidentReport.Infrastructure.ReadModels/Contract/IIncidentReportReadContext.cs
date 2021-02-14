using System.Linq;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using IncidentReport.ReadModels.Dtos.IncidentApplications;

namespace IncidentReport.ReadModels.Contract
{
    public interface IIncidentReportReadContext
    {
        IQueryable<DraftApplicationDto> DraftApplications { get; }
        IQueryable<IncidentApplicationDto> IncidentApplications { get; }
    }
}
