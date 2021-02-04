using IncidentReport.Domain.Entities.Employees.ValueObjects;

namespace IncidentReport.Domain.Entities.Employees
{
    public interface IEmployeeRepository
    {
        bool IsExists(EmployeeId employeeId);
    }
}
