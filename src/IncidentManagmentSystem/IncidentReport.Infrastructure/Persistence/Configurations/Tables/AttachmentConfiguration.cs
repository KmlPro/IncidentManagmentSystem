using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
