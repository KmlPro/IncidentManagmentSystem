using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class SuspiciousEmployee : IEntity
    {
        public SuspiciousEmployee(EmployeeId employeeId)
        {
            this.EmployeeId = employeeId;
        }

        public EmployeeId EmployeeId { get; }
    }
}
