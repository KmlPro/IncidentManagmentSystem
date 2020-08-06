using IncidentReport.Application.Common;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Infrastructure.Persistence.Configurations.Tables;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence
{
    public class IncidentReportWriteDbContext : DbContext, IIncidentReportDbContext
    {
        public DbSet<IncidentApplication> Application { get; set; }

        public IncidentReportWriteDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DraftApplication> DraftApplication { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        }
    }
}
