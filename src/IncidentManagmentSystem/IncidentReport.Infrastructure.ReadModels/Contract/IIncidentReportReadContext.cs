using System.Linq;
using IncidentReport.ReadModels.Dtos.DraftApplications;

namespace IncidentReport.ReadModels.Contract
{
    public interface IIncidentReportReadContext
    {
        IQueryable<DraftApplicationDto> DraftApplications { get; }
    }
}
