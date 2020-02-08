using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Domain.Employees
{
    public class Employee : Entity
    {
        public EmployeeId Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}
