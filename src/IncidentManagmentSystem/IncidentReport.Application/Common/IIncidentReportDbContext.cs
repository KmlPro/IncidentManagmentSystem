using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IIncidentReportDbContext
    {
        DbSet<DraftIncidentVerificationApplication> DraftIncidentVerificationApplication { get; }

        DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; }
    }
}
