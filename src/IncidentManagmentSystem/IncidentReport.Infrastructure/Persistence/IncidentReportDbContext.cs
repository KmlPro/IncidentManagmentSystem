using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Application.Common;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Infrastructure.Persistence.Configurations.Tables;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence
{
    //kbytner 28.01.2020 -- should think how implement users... now implemented only for employees layer test purposes
    public class IncidentReportDbContext : DbContext, IIncidentReportDbContext
    {
        //  public DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; set; }

        public IncidentReportDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DraftApplication> DraftApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
