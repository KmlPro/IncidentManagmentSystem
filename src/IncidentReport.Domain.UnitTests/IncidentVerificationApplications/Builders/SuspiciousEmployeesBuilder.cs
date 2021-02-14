using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class SuspiciousEmployeesBuilder
    {
        private IEnumerable<EmployeeId> _suspiciousEmployees;

        public SuspiciousEmployeesBuilder()
        {
            this._suspiciousEmployees = new List<EmployeeId>();
        }

        public SuspiciousEmployeesBuilder SetEmployees(IEnumerable<EmployeeId> suspiciousEmployees)
        {
            this._suspiciousEmployees = suspiciousEmployees;
            return this;
        }

        public List<EmployeeId> Build()
        {
            return this._suspiciousEmployees.ToList();
        }
    }
}
