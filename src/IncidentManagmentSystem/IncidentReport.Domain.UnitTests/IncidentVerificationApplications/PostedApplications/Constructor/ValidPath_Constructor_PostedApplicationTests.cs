using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.PostedApplications.Constructor
{
    [Category(CategoryTitle.Title + " PostedApplication")]
    public class ValidPath_Constructor_PostedApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var postedApplication = PostedApplicationFactory.CreateValid();

            var postedApplicationCreated = AssertPublishedDomainEvent<ApplicationCreatedDomainEvent>(postedApplication);
            Assert.NotNull(postedApplicationCreated);
        }
    }
}
