using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Infrastructure.Persistence;
using IncidentReport.PublicDomain.Employees;

namespace IncidentReport.Infrastructure.PublicDomain.DraftApplications
{
    public class GetDraftApplicationQuery : IQuery
    {
        private IncidentReportDbContext _incidentReportDbContext { get; set; }

        public GetDraftApplicationQuery(IncidentReportDbContext incidentReportDbContext)
        {
            this._incidentReportDbContext = incidentReportDbContext;
        }
        public IQueryable<DraftApplicationDto> Get()
        {
            var query = from draftApplication in this._incidentReportDbContext.DraftApplication
                        join applicant in this._incidentReportDbContext.Employee on draftApplication.ApplicantId equals applicant.Id
                        select new DraftApplicationDto
                        {
                            Id = draftApplication.Id.Value,
                            Description = draftApplication.ContentOfApplication.Description,
                            Title = draftApplication.ContentOfApplication.Title,
                            IncidentType = draftApplication.IncidentType.Value,
                            Applicant = new EmployeeDto(applicant.Id.Value, applicant.Name, applicant.Surname),
                            Attachments = draftApplication.Attachments.Select(at => new AttachmentDto(at.Id.Value, at.FileInfo.FileName, at.StorageId.Value)),
                            SuspiciousEmployees = this.GetSuspiciousEmployees(draftApplication)
                        };

            return query;
        }

        private IEnumerable<EmployeeDto> GetSuspiciousEmployees(DraftApplication draftApplication)
        {
            var query = from suspiciousEmployees in draftApplication.SuspiciousEmployees
                        join se in this._incidentReportDbContext.Employee on suspiciousEmployees.EmployeeId equals se.Id
                        select new EmployeeDto(se.Id.Value, se.Name, se.Surname);

            return query;
        }
    }
}
