using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications
{
    [Category(CategoryTitle.Title + " DraftApplication")]
    public class ValidPath_DraftApplicationTests : TestFixture
    {
        [Test]
        public void AddAttachments_ThenDeleteAttachments_UpdatedSuccessfully()
        {
            //Arrange
            var applicationDraft = this.CreateValidApplicationDraft();

            var applicationDraftAttachments = this.CreateAttachments(2);

            //Act
            applicationDraft.AddAttachments(applicationDraftAttachments);
            applicationDraft.DeleteAttachments(new List<StorageId> { applicationDraftAttachments.First().StorageId }
                .AsEnumerable());

            //Assert
            var attachmentsAddedEvent = AssertPublishedDomainEvent<DraftApplicationAttachmentsAdded>(applicationDraft);
            var attachmentsDeletedEvent =
                AssertPublishedDomainEvent<DraftApplicationAttachmentsDeleted>(applicationDraft);

            Assert.NotNull(attachmentsAddedEvent);
            Assert.NotNull(attachmentsDeletedEvent);

            Assert.AreEqual(2, attachmentsAddedEvent.Attachments.Count());
            Assert.AreEqual(1, attachmentsDeletedEvent.Attachments.Count());
            Assert.AreEqual(1, applicationDraft.Attachments.Count());
        }

        [Test]
        public void AddAttachments_AddedSuccessfully()
        {
            //Arrange
            var applicationDraft = this.CreateValidApplicationDraft();

            //Act
            applicationDraft.AddAttachments(this.CreateAttachments(2));

            //Assert
            var attachmentsAddedEvent = AssertPublishedDomainEvent<DraftApplicationAttachmentsAdded>(applicationDraft);

            Assert.NotNull(attachmentsAddedEvent);
            Assert.AreEqual(2, applicationDraft.Attachments.Count());
        }

        [Test]
        public void AddSuspiciousEmployees_AddedSuccessfully()
        {
            //Arrange
            var applicationDraft = this.CreateValidApplicationDraft();
            var initialSuspiciousEmployeesCount = applicationDraft.SuspiciousEmployees.Count();

            //Act
            applicationDraft.AddSuspiciousEmployees(this.CreateNewSuspiciousEmployees());

            //Assert
            var suspiciousEmployeesAddedEvent = AssertPublishedDomainEvent<DraftApplicationSuspiciousEmployeeAdded>(applicationDraft);

            Assert.NotNull(suspiciousEmployeesAddedEvent);
            Assert.That(initialSuspiciousEmployeesCount < applicationDraft.SuspiciousEmployees.Count());
        }

        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var applicationDraft = this.CreateValidApplicationDraft();

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreatedDomainEvent>(applicationDraft);
            Assert.NotNull(draftCreated);
        }
    }
}
