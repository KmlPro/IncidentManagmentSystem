using System.Linq;
using AutoMapper.QueryableExtensions;
using IncidentReport.ReadModels.AutoMapperConfiguration;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.DraftApplications;

namespace IncidentReport.ReadModels
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        private readonly IncidentReportReadDbContext _incidentReportReadDbContext;
        private readonly IReadModuleIMapper _mapper;

        public IQueryable<DraftApplicationDto> DraftApplications => this._incidentReportReadDbContext.DraftApplication
            .ProjectTo<DraftApplicationDto>(this._mapper.ConfigurationProvider).AsQueryable();

        public IncidentReportReadContext(IncidentReportReadDbContext incidentReportReadDbContext, IReadModuleIMapper mapper)
        {
            this._incidentReportReadDbContext = incidentReportReadDbContext;
            this._mapper = mapper;
        }
    }
}
