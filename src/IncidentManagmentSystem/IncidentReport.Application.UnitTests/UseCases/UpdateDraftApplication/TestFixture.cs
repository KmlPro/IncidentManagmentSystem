using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    public class TestFixture
    {
        public DraftApplication CreateNewDraft(List<Guid> suspiciousEmployees, IncidentType incidentType)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var contentOfApplication = new ContentOfApplication(title, description);
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployeesIds = suspiciousEmployees.Select(x => new EmployeeId(x)).ToList();

            var draftApplication = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployeesIds);

            return draftApplication;
        }

        public UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(Guid draftApplicationId, List<Guid> suspiciousEmployees, IncidentType incidentType)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);

            return new UpdateDraftApplicationInput(
                draftApplicationId,
                title,
                description,
                incidentType,
                suspiciousEmployees,
                null,
                null);
        }
    }
}
