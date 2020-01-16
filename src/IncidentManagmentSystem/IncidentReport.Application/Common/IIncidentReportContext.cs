using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IIncidentReportContext
    {
        DbSet<NewIncidentVerificationApplication> IncidentVerificationApplication { get; set; }

        DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; set; }
    }
}
