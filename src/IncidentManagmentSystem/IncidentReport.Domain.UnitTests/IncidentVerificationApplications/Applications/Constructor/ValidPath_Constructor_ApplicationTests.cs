using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Applications.Constructor
{
    [Category(CategoryTitle.Title + " Application")]
    public class ValidPath_Constructor_ApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var createdApplication = ApplicationFactory.CreateInCreatedStateValid();

            var applicationCreatedDomainEvent = AssertPublishedDomainEvent<ApplicationCreatedDomainEvent>(createdApplication);
            Assert.NotNull(applicationCreatedDomainEvent);
        }
    }
}
