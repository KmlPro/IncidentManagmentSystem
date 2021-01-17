using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.IncidentApplications.Constructor
{
    [Category(CategoryTitle.Title + " IncidentApplication")]
    public class RuleCheck_Constructor_IncidentApplicationTests : TestBase
    {
        [Test]
        public void ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var applicationBuilder = new ApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { employeeId }))
                .SetTitle(FakeData.Alpha(10))
                .SetContent(FakeData.Alpha(100))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany);

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = applicationBuilder.Build();
            });
        }

        [Test]
        public void IndicateAtLeastOneSuspect_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var applicationBuilder = new ApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId>()))
                .SetTitle(FakeData.Alpha(10))
                .SetContent(FakeData.Alpha(100))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany);

            AssertBrokenRule<IndicateAtLeastOneSuspectRule>(() =>
            {
                var applicationDraft = applicationBuilder.Build();
            });
        }
    }
}
