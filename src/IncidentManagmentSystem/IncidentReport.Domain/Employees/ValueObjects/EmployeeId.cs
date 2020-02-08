using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.Employees.ValueObjects
{
    public class EmployeeId : ValueObject
    {
        public Guid Value { get; private set; }

        public EmployeeId(Guid value)
        {
            this.Value = value;
        }
    }
}
