using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(b => b.ApplicantId).HasMaxLength(30);
            builder.HasOne<Employee>().WithMany().HasForeignKey(nameof(DraftApplication.ApplicantId));

            builder.OwnsOne(m => m.IncidentType, table =>
            {
                table.Property(inc => inc.Value).HasMaxLength(100).HasColumnName(nameof(IncidentType));
            });

            builder.OwnsOne(m => m.Content, table =>
            {
                table.Property(inc => inc.Value).HasMaxLength(1000).HasColumnName(nameof(Content));
            });

            builder.OwnsOne(m => m.Title, table =>
            {
                table.Property(ca => ca.Value).HasMaxLength(100).HasColumnName(nameof(Title));
            });

            builder.HasMany(g => g.Attachments);

            builder.OwnsMany(m => m.SuspiciousEmployees,
                table =>
                {
                    table.HasOne<Employee>().WithMany().HasForeignKey(nameof(SuspiciousEmployee.EmployeeId));
                    table.HasKey("Id");
                    table.ToTable($"{nameof(DraftApplication)}{nameof(SuspiciousEmployee)}", SchemaName.IncidentReport);
                });
        }
    }
}
