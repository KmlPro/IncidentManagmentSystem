using System;
using IncidentReport.ReadModels.Dtos.Employees;

namespace IncidentReport.ReadModels.Dtos.AuditLogs
{
    public class AuditLogDto
    {
        public string Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public string EntityId { get; set; }
        public string Description { get; set; }
        public EmployeeDto User { get; set; }
    }
}
