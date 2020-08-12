using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentManagementSystem.ApiBehavioursTests.DraftApplicationFixtures
{
    public class DraftApplicationFactory
    {
        public DraftApplication Create(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = new DraftApplication(
                new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(100)),
                IncidentType.AdverseEffectForTheCompany, applicant,
                new List<EmployeeId>() {suspiciousEmployee});
            return draftApplication;
        }

        public DraftApplication CreateWithAttachments(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = Create(applicant, suspiciousEmployee);
            this.AddAttachment(draftApplication);

            return draftApplication;
        }

        private void AddAttachment(DraftApplication draftApplication)
        {
            draftApplication.AddAttachments(new List<Attachment>()
            {
                new Attachment(new FileInfo("testFile.pdf"), new StorageId(Guid.NewGuid()))
            });
        }
    }
}
