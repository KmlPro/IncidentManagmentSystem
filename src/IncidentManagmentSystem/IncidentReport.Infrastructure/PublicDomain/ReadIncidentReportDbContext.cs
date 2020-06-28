using System.Linq;
using IncidentReport.Infrastructure.PublicDomain.DraftApplications;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public class ReadIncidentReportDbContext : IReadIncidentReportContext
    {
        private GetDraftApplicationQuery _getDraftApplicationDto { get; set; }

        public ReadIncidentReportDbContext(GetDraftApplicationQuery getDraftApplicationDto)
        {
            this._getDraftApplicationDto = getDraftApplicationDto;
        }

        public IQueryable<DraftApplicationDto> DraftApplications => this._getDraftApplicationDto.Get();
    }
}
