using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Applications.Constructor
{
    [Category(CategoryTitle.Title + " Application")]
    public class RuleCheck_Constructor_ApplicationTests : TestBase
    {
        [Test]
        public void ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var applicationBuilder = new ApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { employeeId }));

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = applicationBuilder.Build();
            });
        }

        [Test]
        public void IndicateAtLeastOneSuspect_NotCreated()
        {
            var employeeId = new EmployeeId(Guid.NewGuid());

            var applicationBuilder = new ApplicationBuilder()
                .SetApplicantId(employeeId)
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId>()));

            AssertBrokenRule<IndicateAtLeastOneSuspectRule>(() =>
            {
                var applicationDraft = applicationBuilder.Build();
            });
        }
    }
}
