using IncidentReport.Infrastructure.Persistence.EnumDescriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    internal class EnumDescriptionConfiguration : IEntityTypeConfiguration<EnumDescription>
    {
        public void Configure(EntityTypeBuilder<EnumDescription> builder)
        {
            builder.ToTable(nameof(EnumDescription), SchemaName.IncidentReport);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Type).HasMaxLength(100);
            builder.Property(x => x.Value).HasMaxLength(100);
        }
    }
}
