using System;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.Entities.Employees.ValueObjects
{
    public class EmployeeId : TypedIdValue
    {
        public EmployeeId(Guid value) : base(value)
        {
        }
    }
}
