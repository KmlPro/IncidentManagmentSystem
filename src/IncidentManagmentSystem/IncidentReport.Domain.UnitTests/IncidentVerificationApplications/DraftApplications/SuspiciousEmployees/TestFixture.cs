using System;
using System.Collections.Generic;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.SuspiciousEmployees
{
    public class TestFixture
    {
        public List<EmployeeId> CreateNewSuspiciousEmployees()
        {
            return new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) };
        }
    }
}
