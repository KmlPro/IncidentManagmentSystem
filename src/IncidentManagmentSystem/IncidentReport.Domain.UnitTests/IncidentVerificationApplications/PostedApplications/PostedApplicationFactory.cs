using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.PostedApplications
{
    public static class PostedApplicationFactory
    {
        public static PostedApplication CreateValid()
        {
            var postedApplicationBuilder = new PostedApplicationBuilder()
                .SetContentOfApplication(x => x.SetTitle(FakeData.Alpha(10)).SetDescription(FakeData.Alpha(20)))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany)
                .SetApplicantId(new EmployeeId(Guid.NewGuid()))
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }));

            var postedApplication = postedApplicationBuilder.Build();

            return postedApplication;
        }
    }
}
