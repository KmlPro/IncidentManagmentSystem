using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.IncidentApplications.Constructor
{
    [Category(CategoryTitle.Title + " IncidentApplication")]
    public class ValidPath_Constructor_IncidentApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var createdApplication = ApplicationIncidentApplication.CreateInCreatedStateValid();

            var applicationCreatedDomainEvent = AssertPublishedDomainEvent<ApplicationCreatedDomainEvent>(createdApplication);
            Assert.NotNull(applicationCreatedDomainEvent);
        }
    }
}
