using System.Collections.Generic;
using System.Linq;

namespace IncidentReport.PublicDomain.DraftApplications
{
    public class GetDraftApplicationDto
    {
        //24.06.2020 - i should think about query bus...
        public IQueryable<DraftApplicationDto> Get()
        {
            return new List<DraftApplicationDto>().AsQueryable();
        }
    }
}
