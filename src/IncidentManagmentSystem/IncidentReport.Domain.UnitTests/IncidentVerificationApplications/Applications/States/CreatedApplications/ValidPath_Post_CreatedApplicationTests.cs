using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Applications.States.CreatedApplications
{
    public class CreatedApplicationStateTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var createdApplication = ApplicationFactory.CreateInCreatedStateValid();
            var postedApplication = createdApplication.Post();

            var applicationPostedDomainEvent = AssertPublishedDomainEvent<ApplicationPostedDomainEvent>(postedApplication);
            Assert.NotNull(applicationPostedDomainEvent);
        }
    }
}
