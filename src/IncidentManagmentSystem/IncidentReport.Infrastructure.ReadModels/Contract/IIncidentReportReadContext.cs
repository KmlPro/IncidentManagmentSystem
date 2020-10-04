using System.Linq;
using IncidentReport.ReadModels.Dtos.AuditLogs;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using IncidentReport.ReadModels.Dtos.IncidentApplications;

namespace IncidentReport.ReadModels.Contract
{
    public interface IIncidentReportReadContext
    {
        IQueryable<DraftApplicationDto> DraftApplications { get; }
        IQueryable<AuditLogDto> DraftApplicationAuditLogs { get; }
        IQueryable<IncidentApplicationDto> IncidentApplications { get; }
        IQueryable<AuditLogDto> ApplicationAuditLogs { get; }
    }
}
