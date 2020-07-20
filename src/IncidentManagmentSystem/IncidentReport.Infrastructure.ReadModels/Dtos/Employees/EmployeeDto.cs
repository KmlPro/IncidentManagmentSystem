using System;

namespace IncidentReport.ReadModels.Dtos.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
