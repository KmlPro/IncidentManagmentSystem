using System.Linq;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.Employees.ValueObjects;

namespace IncidentReport.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IncidentReportWriteDbContext _writeContext;

        public EmployeeRepository(IncidentReportWriteDbContext writeContext)
        {
            this._writeContext = writeContext;
        }
        public bool IsExists(EmployeeId employeeId)
        {
            return this._writeContext.Employee.Any(x => x.Id == employeeId);
        }
    }
}
