using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.SuspiciousEmployees
{
    [Category(CategoryTitle.Title + " DraftApplication")]
    public class RuleCheck_SuspiciousEmployees_DraftApplicationTests : TestBase
    {
        [Test]
        public void AddSuspiciousEmployees_ApplicantIsSuspiciousEmployee_NotUpdated()
        {
            var applicationDraft = DraftApplicationFactory.CreateValid();
            var employeeList = new List<EmployeeId> { applicationDraft.ApplicantId };

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                applicationDraft.AddSuspiciousEmployees(employeeList);
            });
        }
    }
}
