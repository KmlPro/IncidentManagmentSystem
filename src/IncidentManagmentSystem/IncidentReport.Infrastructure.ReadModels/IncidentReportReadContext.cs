using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Dtos.DraftApplications;

namespace IncidentReport.ReadModels
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        private readonly IncidentReportReadDbContext _incidentReportReadDbContext;
        private readonly IMapper _mapper;

        public IQueryable<DraftApplicationDto> DraftApplications => this._incidentReportReadDbContext.DraftApplication
            .ProjectTo<DraftApplicationDto>(this._mapper.ConfigurationProvider).AsQueryable();

        public IncidentReportReadContext(IncidentReportReadDbContext incidentReportReadDbContext, IMapper mapper)
        {
            this._incidentReportReadDbContext = incidentReportReadDbContext;
            this._mapper = mapper;
        }
    }
}
