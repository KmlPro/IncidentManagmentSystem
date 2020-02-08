using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class SuspiciousEmployees : ValueObject
    {
        private readonly List<EmployeeId> _employees;
        public ReadOnlyCollection<EmployeeId> Employees => this._employees.AsReadOnly();

        public SuspiciousEmployees()
        {
            this._employees = new List<EmployeeId>();
        }

        public SuspiciousEmployees(IEnumerable<EmployeeId> suspiciousEmployees)
        {
            this._employees = suspiciousEmployees.ToList();
        }
    }
}
