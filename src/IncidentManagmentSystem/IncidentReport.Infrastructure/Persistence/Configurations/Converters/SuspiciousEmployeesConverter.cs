using System;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncidentReport.Infrastructure.Persistence.Configurations.Converters
{
    internal static class SuspiciousEmployeesConverter
    {
        private static SuspiciousEmployees ConvertTo(string value)
        {
            var values = value.Split(';');
            var suspiciousEmployeesValues = values.Select(x => new EmployeeId(new Guid(x)));
            return new SuspiciousEmployees(suspiciousEmployeesValues);
        }

        private static string ConvertFrom(SuspiciousEmployees suspiciousEmployees)
        {
            return string.Join(";", suspiciousEmployees.Employees.Select(x => x.Value.ToString()));
        }

        public static ValueConverter<SuspiciousEmployees, string> Convert()
        {
            return new ValueConverter<SuspiciousEmployees, string>(
                v => ConvertFrom(v),
                v => ConvertTo(v));
        }
    }
}
