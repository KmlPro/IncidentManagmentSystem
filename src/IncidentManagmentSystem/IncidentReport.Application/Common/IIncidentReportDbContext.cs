using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IIncidentReportDbContext
    {
        DbSet<DraftApplication> DraftApplications { get; }

        //     DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; }
    }
}
