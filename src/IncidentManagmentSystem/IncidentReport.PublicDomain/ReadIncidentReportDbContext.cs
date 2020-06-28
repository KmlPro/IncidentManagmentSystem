using System.Linq;
using IncidentReport.PublicDomain.DraftApplications;

namespace IncidentReport.PublicDomain
{
    public class ReadIncidentReportDbContext : IReadIncidentReportContext
    {
        private GetDraftApplicationDtoQuery _getDraftApplicationDto { get; set; }

        public ReadIncidentReportDbContext(GetDraftApplicationDtoQuery getDraftApplicationDto)
        {
            this._getDraftApplicationDto = getDraftApplicationDto;
        }

        public IQueryable<DraftApplicationDto> DraftApplications => this._getDraftApplicationDto.Get();
    }
}
