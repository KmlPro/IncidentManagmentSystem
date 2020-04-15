using System;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Converters
{
    internal class IncidentTypeConverter
    {
        public static ValueConverter<IncidentType?, string> Convert()
        {
            return new ValueConverter<IncidentType?, string>(
                v => v.ToString(),
                v => (IncidentType)Enum.Parse(typeof(IncidentType), v));
        }
    }
}
