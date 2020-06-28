using System;

namespace IncidentReport.PublicDomain.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public EmployeeDto(Guid id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }
    }
}
