using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.IncidentApplications.Create
{
    [Category(CategoryTitle.Title + " IncidentApplication")]
    public class CreateIncidentApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var createdApplication = IncidentApplicationFactory.CreateInCreatedStateValid();

            var applicationCreatedDomainEvent = AssertPublishedDomainEvent<IncidentApplicationCreated>(createdApplication);
            Assert.NotNull(applicationCreatedDomainEvent);
        }

        [Test]
        public void ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var applicationBuilder = new IncidentApplicationBuilder()
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

            var applicationBuilder = new IncidentApplicationBuilder()
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
