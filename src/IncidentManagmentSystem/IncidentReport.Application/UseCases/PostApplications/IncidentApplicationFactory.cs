using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Application;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases.PostApplications
{
    public class IncidentApplicationFactory
    {
        private readonly ICurrentUserContext _applicantContext;

        public IncidentApplicationFactory(ICurrentUserContext userContext)
        {
            this._applicantContext = userContext;
        }

        public IncidentApplication CreateApplication(PostApplicationInput request, List<Attachment> attachments)
        {
            return IncidentApplication.Create(
                new Title(request.Title),
                new Content(request.Content),
                new IncidentType(request.IncidentType),
                new EmployeeId(this._applicantContext.UserId),
                new List<EmployeeId>(
                    request.SuspiciousEmployees.Select(x => new EmployeeId(x))),
                attachments);
        }
    }
}
