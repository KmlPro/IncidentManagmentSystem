using System.Linq;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    //29.06.2020 - think about moving to persistance
    public class ReadIncidentReportDbContext : IReadIncidentReportDbContext
    {
        private GetDraftApplicationQuery _getDraftApplicationDto { get; set; }

        public ReadIncidentReportDbContext(GetDraftApplicationQuery getDraftApplicationDto)
        {
            this._getDraftApplicationDto = getDraftApplicationDto;
        }

        public IQueryable<DraftApplicationDto> DraftApplications => this._getDraftApplicationDto.Get();
    }
}
