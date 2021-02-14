using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Domain.Entities.Employees;
using IncidentReport.Domain.ValueObjects;
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
                table.Property(inc => inc.Value).HasMaxLength(100).HasColumnName(nameof(IncidentType));
            });

            builder.OwnsOne(m => m.Content, table =>
            {
                table.Property(ca => ca.Value).HasMaxLength(1000).HasColumnName(nameof(Content));
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
                    table.ToTable($"{nameof(IncidentApplication)}{nameof(SuspiciousEmployee)}",
                        SchemaName.IncidentReport);
                });
        }
    }
}
