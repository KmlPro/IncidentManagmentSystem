using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class SuspiciousEmployees : ValueObject
    {
        private readonly List<UserId> _employees;
        public ReadOnlyCollection<UserId> Employees => this._employees.AsReadOnly();

        public SuspiciousEmployees()
        {
            this._employees = new List<UserId>();
        }

        public SuspiciousEmployees(IEnumerable<UserId> suspiciousEmployees)
        {
            this._employees = suspiciousEmployees.ToList();
        }
    }
}
