using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
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
            builder.Ignore(x => x.Attachments);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(nameof(DraftApplication.SuspiciousEmployees)).HasConversion(this.SuspiciousEmployeesConverter());

            builder.Property(nameof(DraftApplication.Attachments)).HasConversion(this.AttachmentsConverter());

            builder.Property(nameof(DraftApplication.IncidentType)).HasConversion(this.IncidentTypeConverter());

            builder.OwnsOne(m => m.ContentOfApplication);

            //    builder.OwnsOne(m => m.Attachments);
        }

        private ValueConverter<IncidentType?, string> IncidentTypeConverter()
        {
            return new ValueConverter<IncidentType?, string>(
                v => v.ToString(),
                v => (IncidentType)Enum.Parse(typeof(IncidentType), v));
        }

        private ValueConverter<AttachmentsToApplication, List<Attachment>> AttachmentsConverter()
        {
            return new ValueConverter<AttachmentsToApplication, List<Attachment>>(
            v => v.Attachments.ToList(),
            v => new AttachmentsToApplication(v));
        }

        private ValueConverter<SuspiciousEmployees, string> SuspiciousEmployeesConverter()
        {
            return new ValueConverter<SuspiciousEmployees, string>(
                v => this.ConvertFromSuspiciousEmployees(v),
                v => this.ConvertToSuspiciousEmployees(v));
        }

        private SuspiciousEmployees ConvertToSuspiciousEmployees(string value)
        {
            var values = value.Split(';');
            var suspiciousEmployeesValues = values.Select(x => new EmployeeId(new Guid(x)));
            return new SuspiciousEmployees(suspiciousEmployeesValues);
        }

        private string ConvertFromSuspiciousEmployees(SuspiciousEmployees suspiciousEmployees)
        {
            return string.Join(";", suspiciousEmployees.Employees.Select(x => x.Value.ToString()));
        }
    }
}
