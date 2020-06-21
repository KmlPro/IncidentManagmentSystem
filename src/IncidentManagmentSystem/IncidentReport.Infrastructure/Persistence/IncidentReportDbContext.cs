using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Application.Common;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Infrastructure.Persistence.Configurations.Tables;
using IncidentReport.Infrastructure.Persistence.EnumDescriptions;
using IncidentReport.Infrastructure.Persistence.EnumDescriptions.IncidentTypes;
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

        public DbSet<DraftApplication> DraftApplication { get; set; }
        public DbSet<EnumDescription> EnumDescription { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EnumDescriptionConfiguration());

            modelBuilder.Seed();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
