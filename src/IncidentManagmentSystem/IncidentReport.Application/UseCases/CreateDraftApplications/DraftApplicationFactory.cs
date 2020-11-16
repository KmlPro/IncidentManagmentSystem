using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Application;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases.CreateDraftApplications
{
    public class DraftApplicationFactory
    {
        private readonly ICurrentUserContext _applicantContext;

        public DraftApplicationFactory(ICurrentUserContext userContext)
        {
            this._applicantContext = userContext;
        }

        public DraftApplication Create(CreateDraftApplicationInput request)
        {
            return new DraftApplication(
                new ContentOfApplication(request.Title, request.Description),
                new IncidentType(request.IncidentType),
                new EmployeeId(this._applicantContext.UserId),
                new List<EmployeeId>(
                    request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
            );
        }
    }
}
