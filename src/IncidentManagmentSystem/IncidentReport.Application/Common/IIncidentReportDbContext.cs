using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IWriteIncidentReportDbContext
    {
        DbSet<DraftApplication> DraftApplication { get; }

        //     DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; }
    }
}
