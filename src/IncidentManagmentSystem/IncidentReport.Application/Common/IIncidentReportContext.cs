using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IIncidentReportContext
    {
        DbSet<DraftIncidentVerificationApplication> DraftIncidentVerificationApplication { get; }

        DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; }
    }
}
