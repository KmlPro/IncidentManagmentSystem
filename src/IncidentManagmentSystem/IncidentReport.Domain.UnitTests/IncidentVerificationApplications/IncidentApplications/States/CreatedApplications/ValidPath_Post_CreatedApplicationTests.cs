using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.IncidentApplications.States.CreatedApplications
{
    [Category(CategoryTitle.Title + " CreatedIncidentApplication")]
    public class CreatedApplicationStateTests : TestBase
    {
        [Test]
        public void AllFieldsAreFilled_CreatedSuccessfully()
        {
            var createdApplication = ApplicationIncidentApplication.CreateInCreatedStateValid();
            var postedApplication = createdApplication.Post();

            var applicationPostedDomainEvent = AssertPublishedDomainEvent<ApplicationPostedDomainEvent>(postedApplication);
            Assert.NotNull(applicationPostedDomainEvent);
        }
    }
}
