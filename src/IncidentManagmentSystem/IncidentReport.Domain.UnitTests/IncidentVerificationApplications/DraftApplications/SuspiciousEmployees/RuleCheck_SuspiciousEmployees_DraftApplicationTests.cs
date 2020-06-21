using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.SuspiciousEmployees
{
    [Category(CategoryTitle.Title + " DraftApplication")]
    public class RuleCheck_SuspiciousEmployees_DraftApplicationTests : TestBase
    {
        private readonly TestFixture _testFixture;
        public RuleCheck_SuspiciousEmployees_DraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }

        [Test]
        public void AddSuspiciousEmployees_ApplicantIsSuspiciousEmployee_NotUpdated()
        {
            var applicationDraft = this._testFixture.CreateValidApplicationDraft();
            var employeeList = new List<EmployeeId> { applicationDraft.ApplicantId };

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                applicationDraft.AddSuspiciousEmployees(employeeList);
            });
        }
    }
}
