using System;
using System.Collections.Generic;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications
{
    [TestFixture]
    [Category(CategoryTitle.Title)]
    public class RuleCheck : TestFixture
    {

        [Test]
        public void AddSuspiciousEmployees_ApplicantIsSuspiciousEmployee_NotUpdated()
        {
            var applicationDraft = this.CreateValidApplicationDraft();
            var employeeList = new List<EmployeeId> { applicationDraft.ApplicantId };

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                applicationDraft.AddSuspiciousEmployees(employeeList);
            });
        }

        [Test]
        public void ApplicantIdShouldBeFilled_NotCreated()
        {
            var draftApplicationBuilder = new DraftApplicationBuilder();

            AssertException<ArgumentNullException>(() =>
            {
                var applicationDraft = draftApplicationBuilder.Build();
            });
        }

        [Test]
        public void ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var draftApplicationBuilder = new DraftApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { employeeId }));

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = draftApplicationBuilder.Build();
            });
        }
    }
}
