using AutoMapper;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels.Dtos.AuditLogs
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            this.CreateMap<DraftApplicationAuditLog, AuditLogDto>();
            this.CreateMap<ApplicationAuditLog, AuditLogDto>();
        }
    }
}
