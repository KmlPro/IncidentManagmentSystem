using IncidentReport.Domain.Employees;
using IncidentReport.Infrastructure.Persistence.NotDomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    public class DraftApplicationAuditLogConfiguration :  IEntityTypeConfiguration<DraftApplicationAuditLog>
    {
        public void Configure(EntityTypeBuilder<DraftApplicationAuditLog> builder)
        {
            builder.ToTable(nameof(DraftApplicationAuditLog), SchemaName.IncidentReport);
            builder.HasKey(x => x.Id);

            builder.HasOne<Employee>().WithMany().HasForeignKey(nameof(DraftApplicationAuditLog.UserId));
        }
    }
}
