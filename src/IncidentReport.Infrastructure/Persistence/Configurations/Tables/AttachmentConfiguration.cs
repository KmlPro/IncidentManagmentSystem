using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable(nameof(Attachment), SchemaName.IncidentReport);

            builder.HasKey(x => x.Id);
            builder.OwnsOne(m => m.FileInfo,
                fi => fi.Property(ca => ca.FileName)
                    .HasMaxLength(100)
                    .HasColumnName(nameof(FileInfo.FileName)));

            builder.Property(x => x.StorageId);
        }
    }
}
