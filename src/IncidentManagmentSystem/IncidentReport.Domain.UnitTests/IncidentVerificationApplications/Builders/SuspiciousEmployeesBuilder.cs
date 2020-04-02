using System.Collections.Generic;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class SuspiciousEmployeesBuilder
    {
        private IEnumerable<EmployeeId> _suspiciousEmployees;

        public SuspiciousEmployeesBuilder SetEmployees(IEnumerable<EmployeeId> suspiciousEmployees)
        {
            this._suspiciousEmployees = suspiciousEmployees;
            return this;
        }

        public SuspiciousEmployees Build()
        {
            return new SuspiciousEmployees(this._suspiciousEmployees);
        }
    }
}
