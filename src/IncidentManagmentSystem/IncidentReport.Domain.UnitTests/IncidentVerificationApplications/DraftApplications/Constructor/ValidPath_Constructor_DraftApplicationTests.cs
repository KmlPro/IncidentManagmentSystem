using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.Constructor
{
    [Category(CategoryTitle.Title + " DraftApplication")]
    public class ValidPath_Constructor_DraftApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var applicationDraft = DraftApplicationFactory.CreateValid();

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreatedDomainEvent>(applicationDraft);
            Assert.NotNull(draftCreated);
        }
    }
}
