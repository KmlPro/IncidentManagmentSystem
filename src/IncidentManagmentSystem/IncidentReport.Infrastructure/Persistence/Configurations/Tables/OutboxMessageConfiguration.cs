using IncidentReport.Infrastructure.Persistence.NoDomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    internal class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable(nameof(OutboxMessage), SchemaName.IncidentReport);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type);
            builder.Property(x => x.OccurredOn);
            builder.Property(x => x.Data);
            builder.Property(x => x.EventId);
            builder.Property(x => x.ProcessedDate);
        }
    }
}
