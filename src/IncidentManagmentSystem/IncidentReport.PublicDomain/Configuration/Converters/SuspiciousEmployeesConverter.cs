using System;
using System.Collections.Generic;
using AutoMapper;
using IncidentReport.Domain.IncidentVerificationApplications;

namespace IncidentReport.PublicDomain.Configuration.Converters
{
    public class SuspiciousEmployeesConverter : ITypeConverter<List<SuspiciousEmployee>, List<Guid>>
    {
        public List<Guid> Convert(List<SuspiciousEmployee> source, List<Guid> destination, ResolutionContext context)
        {
            var suspiciousEmployees = new List<Guid>();
            if (source != null)
            {
                foreach (var employee in source)
                {
                    suspiciousEmployees.Add(employee.EmployeeId.Value);
                }
            }

            return suspiciousEmployees;
        }
    }
}
