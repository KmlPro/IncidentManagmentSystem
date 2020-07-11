using IncidentReport.Infrastructure.Persistence.DbEntities.Attachments;
using IncidentReport.Infrastructure.Persistence.DbEntities.DraftApplications;
using IncidentReport.Infrastructure.Persistence.DbEntities.Employees;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence
{
    //kbytner 28.01.2020 -- should think how implement users... now implemented only for employees layer test purposes
    public class IncidentReportDbContext : DbContext
    {
        //  public DbSet<PostedIncidentVerificationApplication> PostedIncidentVerificationApplication { get; set; }

        public IncidentReportDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DraftApplicationDbModel> DraftApplication { get; set; }

        public DbSet<EmployeeDbModel> Employee { get; set; }

        public DbSet<AttachmentDbModel> Attachment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DraftApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
