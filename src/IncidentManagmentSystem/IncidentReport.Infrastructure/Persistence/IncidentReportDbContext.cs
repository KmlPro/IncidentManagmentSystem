using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Application.Common;
using IncidentReport.Domain.Employees;
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

        public DbSet<DraftApplication> DraftApplication { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Attachment> Attachment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
