using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.DraftApplications
{
    internal class DraftApplicationConfiguration : IEntityTypeConfiguration<DraftApplicationDbModel>
    {
        public void Configure(EntityTypeBuilder<DraftApplicationDbModel> builder)
        {
            builder.ToTable(nameof(DraftApplication), SchemaName.IncidentReport);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(t=> t.IncidentType).HasMaxLength(100);
            builder.Property(ca => ca.Title).HasMaxLength(100);
            builder.Property(ca => ca.Description).HasMaxLength(1000);

            builder.HasMany(c => c.Attachments);
            builder.HasMany(c => c.SuspiciousEmployees);
        }
    }
}
