using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.Factories
{
    public static class DraftApplicationFactory
    {
        public static DraftApplication Create()
        {
            return Create(new List<Guid>() {Guid.NewGuid()});
        }

        public static DraftApplication Create(List<Guid> suspiciousEmployees)
        {
            var title = FakeData.AlphaNumeric(10);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var description = FakeData.AlphaNumeric(99);
            var contentOfApplication = new ContentOfApplication(title, description);
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployeesIds = suspiciousEmployees.Select(x => new EmployeeId(x)).ToList();

            var draftApplication = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployeesIds);

            return draftApplication;
        }
    }
}
