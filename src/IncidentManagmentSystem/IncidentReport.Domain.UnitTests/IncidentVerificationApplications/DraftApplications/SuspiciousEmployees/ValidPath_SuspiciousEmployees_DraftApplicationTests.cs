using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.SuspiciousEmployees
{
    [Category(CategoryTitle.Title + " DraftApplication")]
    public class ValidPath_SuspiciousEmployees_DraftApplicationTests : TestBase
    {
        private readonly TestFixture _testFixture;
        public ValidPath_SuspiciousEmployees_DraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }
        [Test]
        public void AddSuspiciousEmployees_AddedSuccessfully()
        {
            //Arrange
            var applicationDraft = this._testFixture.CreateValidApplicationDraft();
            var initialSuspiciousEmployeesCount = applicationDraft.SuspiciousEmployees.Count();

            //Act
            applicationDraft.AddSuspiciousEmployees(this._testFixture.CreateNewSuspiciousEmployees());

            //Assert
            var suspiciousEmployeesAddedEvent = AssertPublishedDomainEvent<DraftApplicationSuspiciousEmployeeAdded>(applicationDraft);

            Assert.NotNull(suspiciousEmployeesAddedEvent);
            Assert.That(initialSuspiciousEmployeesCount < applicationDraft.SuspiciousEmployees.Count());
        }
    }
}
