using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.Employees.ValueObjects
{
    public class EmployeeId : TypedIdValue
    {
        public EmployeeId(Guid value) : base(value)
        {
        }
    }
}
