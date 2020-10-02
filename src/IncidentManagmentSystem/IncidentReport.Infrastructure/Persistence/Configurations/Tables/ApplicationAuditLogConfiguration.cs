using IncidentReport.Infrastructure.Persistence.NotDomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    public class ApplicationAuditLogConfiguration:  IEntityTypeConfiguration<ApplicationAuditLog>
    {
        public void Configure(EntityTypeBuilder<ApplicationAuditLog> builder)
        {
            builder.ToTable(nameof(ApplicationAuditLog), SchemaName.IncidentReport);
            builder.HasKey(x => x.Id);
        }
    }
}
