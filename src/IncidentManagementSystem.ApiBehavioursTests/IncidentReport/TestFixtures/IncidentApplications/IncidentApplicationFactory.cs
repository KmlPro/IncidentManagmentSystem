using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Aggregates.IncidentApplications;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Domain.ValueObjects;
using Attachment = IncidentReport.Domain.Entities.Attachments.Attachment;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.IncidentApplications
{
    public class IncidentApplicationFactory
    {
        public IncidentApplication CreatePostedWithAttachments(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var incidentApplication = IncidentApplication.Create(
                new Title(FakeData.Alpha(12)),
                new Content(FakeData.Alpha(100)),
                IncidentType.AdverseEffectForTheCompany, applicant,
                new List<EmployeeId>() {suspiciousEmployee}, this.CreateAttachment());

            return incidentApplication;
        }

        private List<Attachment> CreateAttachment()
        {
            return new List<Attachment>()
            {
                new Attachment(new FileInfo("testFile.pdf"), new StorageId(Guid.NewGuid()))
            };
        }
    }
}
