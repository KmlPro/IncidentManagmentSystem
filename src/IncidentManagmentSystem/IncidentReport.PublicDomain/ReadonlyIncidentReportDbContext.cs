using IncidentReport.Application.Common;

namespace IncidentReport.PublicDomain
{
    public class ReadonlyIncidentReportDbContext
    {
        private IIncidentReportDbContext _incidentReportDbContext { get; set; }

        public ReadonlyIncidentReportDbContext(IIncidentReportDbContext incidentReportDbContext)
        {
            this._incidentReportDbContext = incidentReportDbContext;
        }

        // kbytner 24.06.2020 -- to do Implement ProjectTo AutoMapper
        //public IQueryable<DraftApplicationDto> GetDraftApplicationDto()
        //{

        //}
    }
}
