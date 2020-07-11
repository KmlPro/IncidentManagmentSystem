using System;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.Employees
{
    public class EmployeeDbModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
