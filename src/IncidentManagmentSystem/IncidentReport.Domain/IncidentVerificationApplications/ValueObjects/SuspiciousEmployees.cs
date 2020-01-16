using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class SuspiciousEmployees : ValueObject
    {
        public ReadOnlyCollection<UserId> Employees { get; }

        public static SuspiciousEmployees Create(IEnumerable<Guid> suspiciousEmployees)
        {
            return new SuspiciousEmployees(suspiciousEmployees.Select(x => UserId.Create(x)).ToList().AsReadOnly());
        }

        private SuspiciousEmployees(ReadOnlyCollection<UserId> suspiciousEmployees)
        {
            this.Employees = suspiciousEmployees;
        }
    }
}
