using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.IncidentApplications
{
    public static class IncidentApplicationFactory
    {
        public static IncidentApplication CreateInCreatedStateValid()
        {
            var applicationBuilder = new IncidentApplicationBuilder()
                .SetTitle(FakeData.Alpha(10))
                .SetContent(FakeData.Alpha(100))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany)
                .SetApplicantId(new EmployeeId(Guid.NewGuid()))
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }));

            var createdApplication = applicationBuilder.Build();

            return createdApplication;
        }
    }
}
