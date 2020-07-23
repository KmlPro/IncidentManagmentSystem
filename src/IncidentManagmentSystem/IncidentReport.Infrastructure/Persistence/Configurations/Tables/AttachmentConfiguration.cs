using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable(nameof(Attachment), SchemaName.IncidentReport);
            builder.Ignore(x => x.DomainEvents);

            builder.HasKey(x => x.Id);
            builder.OwnsOne(m => m.FileInfo,
                fi => fi.Property(ca => ca.FileName)
                    .HasMaxLength(100)
                    .HasColumnName(nameof(FileInfo.FileName)));
        }
    }
}
