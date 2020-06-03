using System;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.Employees.ValueObjects;
using JetBrains.Annotations;

namespace IncidentReport.Domain.Employees
{
    public class Employee : Entity
    {
        public Employee([NotNull] EmployeeId id, [NotNull] string name, [NotNull] string surname)
        {
            this.Id = id ?? throw new ArgumentNullException(nameof(id));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }

        public EmployeeId Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}
