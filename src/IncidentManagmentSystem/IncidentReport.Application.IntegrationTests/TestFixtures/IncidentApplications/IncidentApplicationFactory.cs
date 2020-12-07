using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Attachment = IncidentReport.Domain.IncidentVerificationApplications.Attachment;

namespace IncidentReport.Application.IntegrationTests.TestFixtures.IncidentApplications
{
    public class IncidentApplicationFactory
    {
        public PostedIncidentApplication CreatePostedWithAttachments(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var incidentApplication = IncidentApplication.Create(
                new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(100)),
                IncidentType.AdverseEffectForTheCompany, applicant,
                new List<EmployeeId>() {suspiciousEmployee}, this.CreateAttachment());

            return incidentApplication.Post();
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
