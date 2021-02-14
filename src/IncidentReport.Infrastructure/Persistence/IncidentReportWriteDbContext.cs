using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Domain.Entities.Employees;
using IncidentReport.Infrastructure.Persistence.Configurations.Tables;
using IncidentReport.Infrastructure.Persistence.NoDomainEntities;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence
{
    public class IncidentReportWriteDbContext : DbContext
    {
        public IncidentReportWriteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DraftApplication> DraftApplication { get; set; }
        public DbSet<IncidentApplication> IncidentApplication { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<OutboxMessage> OutboxMessage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
        }
    }
}
