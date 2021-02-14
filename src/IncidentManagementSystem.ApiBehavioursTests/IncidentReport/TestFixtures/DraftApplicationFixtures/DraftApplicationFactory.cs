using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Aggregates.DraftApplications;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Domain.ValueObjects;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.DraftApplicationFixtures
{
    public class DraftApplicationFactory
    {
        public DraftApplication Create(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = DraftApplication.Create(
                new Title(FakeData.Alpha(12)),
                new Content(FakeData.Alpha(100)),
                IncidentType.AdverseEffectForTheCompany, applicant,
                new List<EmployeeId>() {suspiciousEmployee});
            return draftApplication;
        }

        public DraftApplication CreateWithAttachments(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = this.Create(applicant, suspiciousEmployee);
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
