using System.Linq;
using AutoMapper.QueryableExtensions;
using IncidentReport.ReadModels.AutoMapperConfiguration;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.AuditLogs;
using IncidentReport.ReadModels.Dtos.DraftApplications;
using IncidentReport.ReadModels.Dtos.IncidentApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.ReadModels
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        private readonly IncidentReportReadDbContext _incidentReportReadDbContext;
        private readonly IReadModuleIMapper _mapper;

        public IQueryable<DraftApplicationDto> DraftApplications => this._incidentReportReadDbContext.DraftApplications
            .ProjectTo<DraftApplicationDto>(this._mapper.ConfigurationProvider).AsNoTracking();

        public IQueryable<AuditLogDto> DraftApplicationAuditLogs => this._incidentReportReadDbContext.DraftApplicationAuditLogs
            .ProjectTo<AuditLogDto>(this._mapper.ConfigurationProvider).AsNoTracking();

        public IQueryable<IncidentApplicationDto> IncidentApplications => this._incidentReportReadDbContext.IncidentApplications
            .ProjectTo<IncidentApplicationDto>(this._mapper.ConfigurationProvider).AsNoTracking();

        public IQueryable<AuditLogDto> ApplicationAuditLogs => this._incidentReportReadDbContext.ApplicationAuditLogs
            .ProjectTo<AuditLogDto>(this._mapper.ConfigurationProvider).AsNoTracking();

        public IncidentReportReadContext(IncidentReportReadDbContext incidentReportReadDbContext, IReadModuleIMapper mapper)
        {
            this._incidentReportReadDbContext = incidentReportReadDbContext;
            this._mapper = mapper;
        }
    }
}
