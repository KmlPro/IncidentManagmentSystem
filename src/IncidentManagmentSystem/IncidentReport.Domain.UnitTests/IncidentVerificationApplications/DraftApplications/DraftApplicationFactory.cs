using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
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
                .SetContentOfApplication(x => x.SetTitle(FakeData.Alpha(10)).SetDescription(FakeData.Alpha(20)))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany)
                .SetApplicantId(new EmployeeId(Guid.NewGuid()))
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }));

            var applicationDraft = draftApplicationBuilder.Build();

            return applicationDraft;
        }
    }
}
