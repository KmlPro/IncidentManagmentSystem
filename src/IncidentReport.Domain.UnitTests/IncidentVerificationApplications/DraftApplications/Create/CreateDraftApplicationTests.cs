using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Aggregates.DraftApplications.Events;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Domain.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.Create
{
    [Category(CategoryTitle.Title + " DraftApplication")]
    public class CreateDraftApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var applicationDraft = DraftApplicationFactory.CreateValid();

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreated>(applicationDraft);
            Assert.NotNull(draftCreated);
        }

        [Test]
        public void ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var draftApplicationBuilder = new DraftApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> {employeeId}));

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = draftApplicationBuilder.Build();
            });
        }
    }
}
