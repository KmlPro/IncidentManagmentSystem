using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Attachment = IncidentReport.Domain.IncidentVerificationApplications.Attachment;

namespace IncidentReport.Application.IntegrationTests.TestFixtures.IncidentApplications
{
    public class IncidentApplicationFactory
    {
        public IncidentApplication CreatePostedWithAttachments(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var incidentApplication = IncidentApplication.Create(
                new Title(FakeData.Alpha(10)),
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
