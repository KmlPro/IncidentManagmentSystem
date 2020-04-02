using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class DraftApplicationTests : DraftApplicationTestsBase
    {
        [Test]
        public void CreateApplicationDraft_AllFieldsAreFilled_CreatedSuccessfully()
        {
            var contentOfApplication = new ContentOfApplication(FakeData.Alpha(10), FakeData.Alpha(20));
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployees = new SuspiciousEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }.AsEnumerable());

            var applicationDraft = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees);

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreatedDomainEvent>(applicationDraft);
            Assert.AreEqual(draftCreated.Id, applicationDraft.Id);
            Assert.AreEqual(draftCreated.IncidentType, applicationDraft.IncidentType);
            Assert.AreEqual(draftCreated.ApplicantId, applicationDraft.ApplicantId);
            Assert.AreEqual(draftCreated.SuspiciousEmployees, applicationDraft.SuspiciousEmployees);
            Assert.AreEqual(draftCreated.ContentOfApplication, applicationDraft.ContentOfApplication);
        }

        [Test]
        public void CreateApplicationDraft_ThenAddAttachments_UpdatedSuccessfully()
        {
            var contentOfApplication = new ContentOfApplication(FakeData.Alpha(10), FakeData.Alpha(20));
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployees = new SuspiciousEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }.AsEnumerable());

            var applicationDraft = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees);

            applicationDraft.AddAttachments(this.CreateAttachments(2));
            var applicationUpdated = AssertPublishedDomainEvent<DraftApplicationUpdatedDomainEvent>(applicationDraft);

            Assert.AreEqual(2, applicationDraft.IncidentVerificationApplicationAttachments.Attachments.Count());
            Assert.AreEqual(0, applicationDraft.IncidentVerificationApplicationAttachments.DeletedAttachments.Count());

            Assert.AreEqual(applicationUpdated.Id, applicationDraft.Id);
            Assert.AreEqual(applicationUpdated.IncidentType, applicationDraft.IncidentType);
            Assert.AreEqual(applicationUpdated.SuspiciousEmployees, applicationDraft.SuspiciousEmployees);
            Assert.AreEqual(applicationUpdated.ContentOfApplication, applicationDraft.ContentOfApplication);
            Assert.AreEqual(applicationUpdated.IncidentVerificationApplicationAttachments, applicationDraft.IncidentVerificationApplicationAttachments);
        }

        [Test]
        public void CreateApplicationDraft_ThenAddAttachments_ThenDeleteAttachments_UpdatedSuccessfully()
        {
            var contentOfApplication = new ContentOfApplication(FakeData.Alpha(10), FakeData.Alpha(20));
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployees = new SuspiciousEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }.AsEnumerable());

            var applicationDraft = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees);

            var applicationDraftAttachments = this.CreateAttachments(2);

            applicationDraft.AddAttachments(applicationDraftAttachments);
            applicationDraft.DeleteAttachments(new List<StorageId> { applicationDraftAttachments.First().StorageId }.AsEnumerable());

            var applicationUpdated = AssertPublishedDomainEvents<DraftApplicationUpdatedDomainEvent>(applicationDraft).OrderByDescending(x => x.OccurredOn).First();

            Assert.AreEqual(1, applicationDraft.IncidentVerificationApplicationAttachments.Attachments.Count());
            Assert.AreEqual(1, applicationDraft.IncidentVerificationApplicationAttachments.DeletedAttachments.Count());

            Assert.AreEqual(applicationUpdated.Id, applicationDraft.Id);
            Assert.AreEqual(applicationUpdated.IncidentType, applicationDraft.IncidentType);
            Assert.AreEqual(applicationUpdated.SuspiciousEmployees, applicationDraft.SuspiciousEmployees);
            Assert.AreEqual(applicationUpdated.ContentOfApplication, applicationDraft.ContentOfApplication);
            Assert.AreEqual(applicationUpdated.IncidentVerificationApplicationAttachments, applicationDraft.IncidentVerificationApplicationAttachments);
        }

        [Test]
        public void CreateApplicationDraft_AllFieldsAreNullOrEmpty_NotCreated()
        {
            AssertBrokenRule<FieldShouldBeFilledRule>(() =>
            {
                var applicationDraft = new DraftApplication(null, null, null, null);
            });
        }

        [Test]
        public void CreateApplicationDraft_TitleOFApplicationIsTooShort_NotCreated()
        {
            AssertBrokenRule<ApplicationTitleLenghtRule>(() =>
            {
                var contentOfApplication = new ContentOfApplication(FakeData.Alpha(1), FakeData.Alpha(20));
            });
        }

        [Test]
        public void CreateApplicationDraft_TitleOfApplicationIsTooLong_NotCreated()
        {
            var applicantId = new EmployeeId(Guid.NewGuid());
            AssertBrokenRule<ApplicationTitleLenghtRule>(() =>
            {
                var contentOfApplication = new ContentOfApplication(FakeData.Alpha(101), FakeData.Alpha(20));
            });
        }

        [Test]
        public void CreateApplicationDraft_DescriptionOfApplicationIsTooShort_NotCreated()
        {
            AssertBrokenRule<ApplicationDescriptionLengthRule>(() =>
            {
                var contentOfApplication = new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(1));
            });
        }

        [Test]
        public void CreateApplicationDraft_DescriptionOfApplicationIsTooLong_NotCreated()
        {
            AssertBrokenRule<ApplicationDescriptionLengthRule>(() =>
            {
                var contentOfApplication = new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(1001));
            });
        }

        [Test]
        public void CreateApplicationDraft_OnlyApplicantIdFilled_CreatedSuccessfully()
        {
            var applicantId = new EmployeeId(Guid.NewGuid());
            var applicationDraft = new DraftApplication(null, null, applicantId, null);

            var draftCreated = AssertPublishedDomainEvent<DraftApplicationCreatedDomainEvent>(applicationDraft);

            Assert.AreEqual(draftCreated.Id, applicationDraft.Id);
        }

        [Test]
        public void CreateApplicationDraft_ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployees = new SuspiciousEmployees(new List<EmployeeId> { applicantId }.AsEnumerable());

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() =>
            {
                var applicationDraft = new DraftApplication(null, null, applicantId, suspiciousEmployees);
            });
        }

        [Test]
        public void UpdateApplicationDraft_ApplicantIsSuspiciousEmployee_NotCreated()
        {
            var applicantId = new EmployeeId(Guid.NewGuid());
            var applicationDraft = new DraftApplication(null, null, applicantId, null);

            var suspiciousEmployees = new SuspiciousEmployees(new List<EmployeeId> { applicantId }.AsEnumerable());

            AssertBrokenRule<ApplicantCannotBeSuspectRule>(() => applicationDraft.Update(null, null, suspiciousEmployees));
        }
    }
}
