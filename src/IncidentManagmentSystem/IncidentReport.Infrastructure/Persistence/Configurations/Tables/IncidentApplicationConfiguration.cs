using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Tables
{
    public class IncidentApplicationConfiguration : IEntityTypeConfiguration<IncidentApplication>
    {
        public void Configure(EntityTypeBuilder<IncidentApplication> builder)
        {
            builder.ToTable(nameof(IncidentApplication), SchemaName.IncidentReport);
            builder.Ignore(x => x.DomainEvents);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(b => b.ApplicantId).HasMaxLength(30);
            builder.OwnsOne(b => b.ApplicationState,
                table =>
                {
                    table.Property(appState => appState.Value).HasMaxLength(15);
                });

            builder.HasOne<Employee>().WithMany().HasForeignKey(nameof(IncidentApplication.ApplicantId));

            builder.OwnsOne(m => m.IncidentType, table =>
            {
                table.Property(inc => inc.Value).HasMaxLength(100);
            });

            builder.OwnsOne(m => m.ContentOfApplication, table =>
            {
                table.Property(ca => ca.Title).HasMaxLength(100).HasColumnName(nameof(ContentOfApplication.Title));
                table.Property(ca => ca.Description).HasMaxLength(1000)
                    .HasColumnName(nameof(ContentOfApplication.Description));
            });

            builder.HasMany(g => g.Attachments);

            builder.OwnsMany(m => m.SuspiciousEmployees,
                table =>
                {
                    table.HasOne<Employee>().WithMany().HasForeignKey(nameof(SuspiciousEmployee.EmployeeId));
                    table.ToTable($"{nameof(IncidentApplication)}{nameof(SuspiciousEmployee)}", SchemaName.IncidentReport);
                });
        }
    }
}
