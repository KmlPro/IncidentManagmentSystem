using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncidentReport.Infrastructure.Persistence.Configurations
{
    internal class DraftIncidentVerificationApplicationConfiguration : IEntityTypeConfiguration<DraftIncidentVerificationApplication>
    {
        private readonly string _tableName = "DraftIncidentVerificationApplication";

        public void Configure(EntityTypeBuilder<DraftIncidentVerificationApplication> builder)
        {
            //kbytner 30.01.2020 - handle users (how ? 
            builder.ToTable(this._tableName, SchemaName.IncidentReport);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(nameof(DraftIncidentVerificationApplication.SuspiciousEmployees)).HasConversion(this.SuspiciousEmployeesConverter());

            builder.HasMany(c => c.IncidentVerificationApplicationAttachments.Attachments);

            builder.Property(nameof(DraftIncidentVerificationApplication.IncidentVerificationApplicationAttachments)).HasConversion(this.IncidentVerificationApplicationAttachmentsConverter());

            builder.OwnsOne(m => m.ContentOfApplication);

            builder.Property(nameof(DraftIncidentVerificationApplication.IncidentType)).HasConversion(this.IncidentTypeConverter());
        }

        private ValueConverter<IncidentType?, string> IncidentTypeConverter()
        {
            return new ValueConverter<IncidentType?, string>(
                v => v.ToString(),
                v => (IncidentType)Enum.Parse(typeof(IncidentType), v));
        }

        private ValueConverter<IncidentVerificationApplicationAttachments, List<IncidentVerificationApplicationAttachment>> IncidentVerificationApplicationAttachmentsConverter()
        {
            return new ValueConverter<IncidentVerificationApplicationAttachments, List<IncidentVerificationApplicationAttachment>>(
            v => v.Attachments.ToList(),
            v => new IncidentVerificationApplicationAttachments(v));
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
            var suspiciousEmployeesValues = values.Select(x => new UserId(new Guid(x)));
            return new SuspiciousEmployees(suspiciousEmployeesValues);
        }

        private string ConvertFromSuspiciousEmployees(SuspiciousEmployees suspiciousEmployees)
        {
            return string.Join(";", suspiciousEmployees.Employees.Select(x => x.Value.ToString()));
        }
    }
}
