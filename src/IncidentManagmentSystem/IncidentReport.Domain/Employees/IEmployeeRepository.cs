using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Domain.Employees
{
    public interface IEmployeeRepository
    {
        bool IsExists(EmployeeId draftApplicationId);
    }
}
