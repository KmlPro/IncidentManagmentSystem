using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Attachments
{
    [Category(CategoryTitle.Title + " DraftApplication With Attachments")]
    public class ValidPath_Attachments_DraftApplicationTests : TestBase
    {
        private readonly TestFixture _testFixture;
        public ValidPath_Attachments_DraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }

        [Test]
        public void AddAttachments_ThenDeleteAttachments_AttachmentsChangedSuccessfully()
        {
            //Arrange
            var applicationDraft = DraftApplicationFactory.CreateValid();

            var applicationDraftAttachments = this._testFixture.CreateAttachments(2);

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

            Assert.AreEqual(2, attachmentsAddedEvent.AddedAttachments.Count());
            Assert.AreEqual(1, attachmentsDeletedEvent.DeletedAttachments.Count());
            Assert.AreEqual(1, applicationDraft.Attachments.Count());
        }

        [Test]
        public void AddAttachments_AddedSuccessfully()
        {
            //Arrange
            var applicationDraft = DraftApplicationFactory.CreateValid();

            //Act
            applicationDraft.AddAttachments(this._testFixture.CreateAttachments(2));

            //Assert
            var attachmentsAddedEvent = AssertPublishedDomainEvent<DraftApplicationAttachmentsAdded>(applicationDraft);

            Assert.NotNull(attachmentsAddedEvent);
            Assert.AreEqual(2, applicationDraft.Attachments.Count());
        }
    }
}
