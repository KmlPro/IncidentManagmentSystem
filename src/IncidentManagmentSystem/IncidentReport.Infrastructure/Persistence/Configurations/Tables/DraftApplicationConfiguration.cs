using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    //kbytner 03.06.2020 - to do configuration
    internal class DraftApplicationConfiguration : IEntityTypeConfiguration<DraftApplication>
    {
        public void Configure(EntityTypeBuilder<DraftApplication> builder)
        {
            builder.ToTable(nameof(DraftApplication), SchemaName.IncidentReport);
            builder.Ignore(x => x.DomainEvents);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(b => b.ApplicantId).HasMaxLength(30);

            builder.OwnsOne(m => m.IncidentType, table =>
            {
                table.Property(inc => inc.Value).HasMaxLength(100);
            });
            //kbytner 06.06.2020 - think about set withOwner
            builder.OwnsOne(m => m.ContentOfApplication, table =>
            {
                table.Property(ca => ca.Title).HasMaxLength(100).HasColumnName(nameof(ContentOfApplication.Title));
                table.Property(ca => ca.Description).HasMaxLength(1000)
                    .HasColumnName(nameof(ContentOfApplication.Description));
            });

            builder.HasMany(g => g.Attachments);

            builder.OwnsMany(m => m.SuspiciousEmployees, table =>
                table.ToTable(nameof(SuspiciousEmployee), SchemaName.IncidentReport));
        }
    }
}
