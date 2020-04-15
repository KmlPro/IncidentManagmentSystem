using System;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Configurations.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    internal class DraftApplicationConfiguration : IEntityTypeConfiguration<DraftApplication>
    {
        public void Configure(EntityTypeBuilder<DraftApplication> builder)
        {
            builder.ToTable(nameof(DraftApplication), SchemaName.IncidentReport);
            builder.Ignore(x => x.DomainEvents);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(nameof(DraftApplication.SuspiciousEmployees)).HasConversion(SuspiciousEmployeesConverter.Convert());
            builder.Property(nameof(DraftApplication.IncidentType)).HasConversion(IncidentTypeConverter.Convert());

            builder.OwnsOne(m => m.ContentOfApplication);
            builder.OwnsMany(m => m.Attachments);
        }
    }
}
