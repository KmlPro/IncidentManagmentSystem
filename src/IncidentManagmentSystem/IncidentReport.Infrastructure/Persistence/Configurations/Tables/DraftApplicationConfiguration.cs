using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Infrastructure.Persistence.Configurations.Converters;
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

            builder.Property(nameof(DraftApplication.IncidentType)).HasConversion(IncidentTypeConverter.Convert());

            builder.OwnsOne(m => m.ContentOfApplication);
            builder.OwnsMany(m => m.Attachments);
        }
    }
}
