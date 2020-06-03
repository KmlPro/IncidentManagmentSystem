using System;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class SuspiciousEmployee : Entity
    {
        public SuspiciousEmployee(EmployeeId employeeId)
        {
            this.Id = new SuspiciousEmployeeId(new Guid());
            this.EmployeeId = employeeId;
        }

        public SuspiciousEmployeeId Id { get; set; }
        public EmployeeId EmployeeId { get; set; }
    }
}
