using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Application;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Domain.ValueObjects;

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
            return DraftApplication.Create(
                new Title(request.Title),
                new Content(request.Content),
                new IncidentType(request.IncidentType),
                new EmployeeId(this._applicantContext.UserId),
                new List<EmployeeId>(
                    request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
            );
        }
    }
}
