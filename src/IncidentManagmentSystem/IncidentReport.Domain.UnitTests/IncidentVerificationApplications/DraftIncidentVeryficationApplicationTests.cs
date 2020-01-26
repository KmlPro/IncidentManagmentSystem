using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class DraftIncidentVeryficationApplicationTests : TestBase
    {
        [Test]
        public void CreateApplicationDraft_AllFieldsAreNullOrEmpty_NotCreated()
        {
            AssertBrokenRule<FieldShouldBeFilledRule>(() =>
            {
                var applicationDraft = new DraftIncidentVerificationApplication(null, null, null, null);
            });
        }

        [Test]
        public void CreateApplicationDraft_OnlyApplicantIdFilled_CreatedSuccessfully()
        {
            var applicantId = new UserId(Guid.NewGuid());
            var applicationDraft = new DraftIncidentVerificationApplication(null, null, applicantId, null);

            var draftCreated = AssertPublishedDomainEvent<DraftIncidentVerificationApplicationCreatedDomainEvent>(applicationDraft);

            Assert.AreEqual(draftCreated.Id, applicationDraft.Id);
        }

        [Test]
        public void CreateApplicationDraft_ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var applicantId = new UserId(Guid.NewGuid());
            var suspiciousEmployees = new SuspiciousEmployees(new List<UserId> { applicantId }.AsEnumerable());

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = new DraftIncidentVerificationApplication(null, null, applicantId, suspiciousEmployees);
            });
        }
    }
}
