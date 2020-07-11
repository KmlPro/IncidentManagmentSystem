using IncidentReport.Domain.Employees;
using IncidentReport.Infrastructure.Persistence.Configurations;
using IncidentReport.Infrastructure.Persistence.DbEntities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.Attachments
{
    internal class AttachmentConfiguration : IEntityTypeConfiguration<AttachmentDbModel>
    {
        public void Configure(EntityTypeBuilder<AttachmentDbModel> builder)
        {
            builder.ToTable(nameof(Employee), SchemaName.IncidentReport);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();
            builder.Property(b => b.FileName).HasMaxLength(200).IsRequired();
            builder.Property(b => b.StorageId).HasMaxLength(100).IsRequired();
        }
    }
}
