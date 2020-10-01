using System.Collections.Generic;
using System.Linq;
using System.Text;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;
using IncidentReport.Infrastructure.Persistence;

namespace IncidentReport.Infrastructure.AuditLogs.Logs.DraftApplications
{
    public class DraftApplicationSuspiciousEmployeeAddedAuditLog : AuditLogFactory<DraftApplicationSuspiciousEmployeeAdded>
    {
        private readonly IncidentReportWriteDbContext _dbContext;

        public DraftApplicationSuspiciousEmployeeAddedAuditLog(IncidentReportWriteDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public override string BuildLog(DraftApplicationSuspiciousEmployeeAdded @event)
        {
            var employeeIds = @event.SuspiciousEmployee.Select(se => se.EmployeeId);
            var employees = this._dbContext.Employee.Where(x =>
                employeeIds.Contains(x.Id)).ToList();
            var names = this.CreateNamesText(employees);
            return string.Format(LogResources.DraftApplicationSuspiciousEmployeeAdded, names);
        }

        private string CreateNamesText(List<Employee> employees)
        {
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.Append($" {employee.Name} {employee.Surname}");
            }

            return sb.ToString();
        }
    }
}
