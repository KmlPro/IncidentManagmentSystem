using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class DraftIncidentVeryficationApplicationTests : TestBase
    {
        [Test]
        public void CreateApplicationDraft_AllFieldsAreFilled_CreatedSuccessfully()
        {
            var contentOfApplication = new ContentOfApplication(Faker.StringFaker.Alpha(10), Faker.StringFaker.Alpha(20));
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var applicantId = new UserId(Guid.NewGuid());
            var suspiciousEmployees = new SuspiciousEmployees(new List<UserId> { new UserId(Guid.NewGuid()) }.AsEnumerable());

            var applicationDraft = new DraftIncidentVerificationApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees);

            var draftCreated = AssertPublishedDomainEvent<DraftIncidentVerificationApplicationCreatedDomainEvent>(applicationDraft);
            Assert.AreEqual(draftCreated.Id, applicationDraft.Id);
            Assert.AreEqual(draftCreated.IncidentType, applicationDraft.IncidentType);
            Assert.AreEqual(draftCreated.ApplicantId, applicationDraft.ApplicantId);
            Assert.AreEqual(draftCreated.SuspiciousEmployees, applicationDraft.SuspiciousEmployees);
            Assert.AreEqual(draftCreated.ContentOfApplication, applicationDraft.ContentOfApplication);
        }

        [Test]
        public void CreateApplicationDraft_AllFieldsAreNullOrEmpty_NotCreated()
        {
            AssertBrokenRule<FieldShouldBeFilledRule>(() =>
            {
                var applicationDraft = new DraftIncidentVerificationApplication(null, null, null, null);
            });
        }

        [Test]
        public void CreateApplicationDraft_TitleOFApplicationIsTooShort_NotCreated()
        {
            var applicantId = new UserId(Guid.NewGuid());
            AssertBrokenRule<ApplicationDescriptionLengthRule>(() =>
            {
                var contentOfApplication = new ContentOfApplication(Faker.StringFaker.Alpha(1), Faker.StringFaker.Alpha(20));
            });
        }

        [Test]
        public void CreateApplicationDraft_DescriptionOFApplicationIsTooShort_NotCreated()
        {
            var applicantId = new UserId(Guid.NewGuid());

            AssertBrokenRule<ApplicationDescriptionLengthRule>(() =>
            {
                var contentOfApplication = new ContentOfApplication(Faker.StringFaker.Alpha(12), Faker.StringFaker.Alpha(1));
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

        [Test]
        public void UpdateApplicationDraft_ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var applicantId = new UserId(Guid.NewGuid());
            var applicationDraft = new DraftIncidentVerificationApplication(null, null, applicantId, null);

            var suspiciousEmployees = new SuspiciousEmployees(new List<UserId> { applicantId }.AsEnumerable());

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() => applicationDraft.Update(null, null, suspiciousEmployees));
        }
    }
}
