using System;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentReport.Domain.Entities.Employees
{
    public class Employee : AggregateRoot
    {
        public Employee(Guid id, string name, string surname)
        {
            this.Id = new EmployeeId(id);
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        public EmployeeId Id { get; }
        public string Name { get; }
        public string Surname { get; }

        private Employee()
        {

        }
    }
}
