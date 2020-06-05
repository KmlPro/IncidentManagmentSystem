using System;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Domain.Employees
{
    public class Employee : Entity
    {
        public Employee(EmployeeId id, string name, string surname)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        public EmployeeId Id { get; }
        public string Name { get; }
        public string Surname { get; }
    }
}
