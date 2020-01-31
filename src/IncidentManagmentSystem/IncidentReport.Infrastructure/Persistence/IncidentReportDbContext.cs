using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Application.Common;
using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence
{
    //kbytner 28.01.2020 -- should think how implement users... now implemented only for application layer test purposes
    public class IncidentReportDbContext : DbContext, IIncidentReportDbContext
    {
        public DbSet<DraftIncidentVerificationApplication> DraftIncidentVerificationApplication { get; set; }

        //  public DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; set; }

        public IncidentReportDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
