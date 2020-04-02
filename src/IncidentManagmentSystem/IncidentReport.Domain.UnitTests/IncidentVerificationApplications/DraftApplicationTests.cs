using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class DraftApplicationTests : DraftApplicationTestsBase
    {
        [Test]
        public void CreateApplicationDraft_AllFieldsAreFilled_CreatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreatedDomainEvent>(applicationDraft);
            Assert.NotNull(draftCreated);
        }

        [Test]
        public void CreateApplicationDraft_ThenAddAttachments_UpdatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            applicationDraft.AddAttachments(this.CreateAttachments(2));
            var applicationUpdated = AssertPublishedDomainEvent<DraftApplicationUpdatedDomainEvent>(applicationDraft);

            Assert.AreEqual(2, applicationDraft.IncidentVerificationApplicationAttachments.Attachments.Count());
            Assert.AreEqual(0, applicationDraft.IncidentVerificationApplicationAttachments.DeletedAttachments.Count());
            Assert.NotNull(applicationUpdated);
        }

        [Test]
        public void CreateApplicationDraft_ThenAddAttachments_ThenDeleteAttachments_UpdatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            var applicationDraftAttachments = this.CreateAttachments(2);

            applicationDraft.AddAttachments(applicationDraftAttachments);
            applicationDraft.DeleteAttachments(new List<StorageId> { applicationDraftAttachments.First().StorageId }.AsEnumerable());

            var applicationUpdated = AssertPublishedDomainEvents<DraftApplicationUpdatedDomainEvent>(applicationDraft).OrderByDescending(x => x.OccurredOn).First();

            Assert.AreEqual(1, applicationDraft.IncidentVerificationApplicationAttachments.Attachments.Count());
            Assert.AreEqual(1, applicationDraft.IncidentVerificationApplicationAttachments.DeletedAttachments.Count());
            Assert.NotNull(applicationUpdated);
        }

        [Test]
        public void CreateApplicationDraft_ApplicantIdShouldBeFilled_NotCreated()
        {
            var draftApplicationBuilder = new DraftApplicationBuilder();

            AssertBrokenRule<FieldShouldBeFilledRule>(() =>
            {
                var applicationDraft = draftApplicationBuilder.Build();
            });
        }

        [Test]
        public void CreateApplicationDraft_ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var draftApplicationBuilder = new DraftApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { employeeId }));

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = draftApplicationBuilder.Build();
            });
        }

        [Test]
        public void UpdateApplicationDraft_ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var draftApplicationBuilder = new DraftApplicationBuilder()
                .SetApplicantId(employeeId);

            var draftApplication = draftApplicationBuilder.Build();

            var suspiciousEmployees = new SuspiciousEmployees(new List<EmployeeId> { employeeId }.AsEnumerable());

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() => draftApplication.Update(null, null, suspiciousEmployees));
        }
    }
}
