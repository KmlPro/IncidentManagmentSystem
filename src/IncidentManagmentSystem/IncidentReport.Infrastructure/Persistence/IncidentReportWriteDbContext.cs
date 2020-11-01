using System;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Exceptions.Common;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Infrastructure.Persistence.Configurations.Tables;
using IncidentReport.Infrastructure.Persistence.NotDomainEntities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IncidentReport.Infrastructure.Persistence
{
    public class IncidentReportWriteDbContext : DbContext
    {
        public IncidentReportWriteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DraftApplication> DraftApplication { get; set; }
        public DbSet<DraftApplicationAuditLog> DraftApplicationAuditLog { get; set; }
        public DbSet<ApplicationAuditLog> ApplicationAuditLog { get; set; }
        public DbSet<IncidentApplication> IncidentApplication { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationAuditLogConfiguration());
            modelBuilder.ApplyConfiguration(new DraftApplicationAuditLogConfiguration());
        }
    }
}
