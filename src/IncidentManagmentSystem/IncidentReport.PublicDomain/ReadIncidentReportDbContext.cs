using System.Linq;
using IncidentReport.Infrastructure.Persistence;
using IncidentReport.PublicDomain.DraftApplications;

namespace IncidentReport.PublicDomain
{
    public class ReadIncidentReportDbContext : IReadIncidentReportContext
    {
        private IncidentReportDbContext _incidentReportDbContext { get; set; }

        public ReadIncidentReportDbContext(IncidentReportDbContext incidentReportDbContext)
        {
            this._incidentReportDbContext = incidentReportDbContext;
        }

        public IQueryable<DraftApplicationDto> DraftApplications
        {
            get
            {
                var query = from draftApplication in this._incidentReportDbContext.DraftApplication
                            join application in this._incidentReportDbContext.Employee on draftApplication.ApplicantId equals application.Id
                            from suspiciousEmployees in draftApplication.SuspiciousEmployees
                            join suspiciousEmployee in this._incidentReportDbContext.Employee on suspiciousEmployees.EmployeeId equals suspiciousEmployee.Id
                            select new DraftApplicationDto
                            {

                            };

                return query;
            }
        }
    }
}
