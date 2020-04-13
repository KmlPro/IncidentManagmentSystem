using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class DraftApplicationTests : DraftApplicationTestsBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreatedDomainEvent>(applicationDraft);
            Assert.NotNull(draftCreated);
        }

        [Test]
        public void AddAttachments_UpdatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            applicationDraft.AddAttachments(this.CreateAttachments(2));
            var attachmentsAddedEvent = AssertPublishedDomainEvent<DraftApplicationAttachmentsAdded>(applicationDraft);

            Assert.NotNull(attachmentsAddedEvent);
            Assert.AreEqual(2, applicationDraft.Attachments.Count());
        }

        [Test]
        public void AddAttachments_ThenDeleteAttachments_UpdatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            var applicationDraftAttachments = this.CreateAttachments(2);

            applicationDraft.AddAttachments(applicationDraftAttachments);
            applicationDraft.DeleteAttachments(new List<StorageId> { applicationDraftAttachments.First().StorageId }.AsEnumerable());

            var attachmentsAddedEvent = AssertPublishedDomainEvent<DraftApplicationAttachmentsAdded>(applicationDraft);
            var attachmentsDeletedEvent = AssertPublishedDomainEvent<DraftApplicationAttachmentsDeleted>(applicationDraft);

            Assert.NotNull(attachmentsAddedEvent);
            Assert.NotNull(attachmentsDeletedEvent);

            Assert.AreEqual(2, attachmentsAddedEvent.Attachments.Count());
            Assert.AreEqual(1, attachmentsDeletedEvent.Attachments.Count());
            Assert.AreEqual(1, applicationDraft.Attachments.Count());
        }

        [Test]
        public void ApplicantIdShouldBeFilled_NotCreated()
        {
            var draftApplicationBuilder = new DraftApplicationBuilder();

            AssertBrokenRule<FieldShouldBeFilledRule>(() =>
            {
                var applicationDraft = draftApplicationBuilder.Build();
            });
        }

        [Test]
        public void ApplicantIsSuspiciousEmployee_NotCreated()
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
        public void ApplicantIsSuspiciousEmployee_NotUpdated()
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
