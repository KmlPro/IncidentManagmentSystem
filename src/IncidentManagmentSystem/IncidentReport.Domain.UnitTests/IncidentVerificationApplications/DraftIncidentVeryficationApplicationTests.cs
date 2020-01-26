using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class DraftIncidentVeryficationApplicationTests : TestBase
    {
        //[Test]
        //public void CreateApplicationDraft_AllRequiredFieldsFilled_CreatedSuccessfully()
        //{
        //    var applicationDraft = new DraftIncidentVerificationApplication()
        //}

        [Test]
        public void CreateApplicationDraft_AllFieldsAreNullOrEmpty_CreatedSuccessfully()
        {
            var applicationDraft = new DraftIncidentVerificationApplication(null, null, null, null);

            var applicationCreatedEvent = AssertPublishedDomainEvent<DraftIncidentVerificationApplicationCreatedDomainEvent>(applicationDraft);

            Assert.AreEqual(applicationDraft.Id, applicationCreatedEvent.Id);
        }
    }
}
