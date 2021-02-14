using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentReport.Domain.ValueObjects
{
    public class SuspiciousEmployee : ValueObject, IEntity
    {
        public SuspiciousEmployee(EmployeeId employeeId)
        {
            this.EmployeeId = employeeId;
        }

        public EmployeeId EmployeeId { get; }
    }
}
