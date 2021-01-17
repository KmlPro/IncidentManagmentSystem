using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications
{
    public static class DraftApplicationFactory
    {
        public static DraftApplication CreateValid()
        {
            var draftApplicationBuilder = new DraftApplicationBuilder()
                .SetTitle(FakeData.Alpha(10))
                .SetContent(FakeData.Alpha(100))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany)
                .SetApplicantId(new EmployeeId(Guid.NewGuid()))
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }));

            var applicationDraft = draftApplicationBuilder.Build();

            return applicationDraft;
        }
    }
}
