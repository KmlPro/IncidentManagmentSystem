using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IIncidentReportContext
    {
        DbSet<IncidentVerificationApplication> IncidentVerificationApplication { get; set; }

        DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; set; }
    }
}
