using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.Common
{
    public interface IIncidentReportDbContext
    {
        DbSet<DraftApplication> DraftApplication { get; }
        DbSet<Employee> Employee { get; }

        //     DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; }
    }
}
