using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.Attachments
{
    public class TestFixture : TestBase
    {
        public List<Attachment> CreateAttachments(int numberOfAttachments)
        {
            var attachments = new List<Attachment>();

            for (var i = 0; i < numberOfAttachments; i++)
            {
                attachments.Add(new Attachment(new FileInfo("testFile.pdf"), new StorageId(Guid.NewGuid())));
            }

            return attachments;
        }

        public DraftApplication CreateValidApplicationDraft()
        {
            var draftApplicationBuilder = new DraftApplicationBuilder()
                .SetContentOfApplication(x => x.SetTitle(FakeData.Alpha(10)).SetDescription(FakeData.Alpha(20)))
                .SetIncidentType(IncidentType.AdverseEffectForTheCompany)
                .SetApplicantId(new EmployeeId(Guid.NewGuid()))
                .SetSuspiciousEmployees(x => x.SetEmployees(new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) }));

            var applicationDraft = draftApplicationBuilder.Build();

            return applicationDraft;
        }

        public List<EmployeeId> CreateNewSuspiciousEmployees()
        {
            return new List<EmployeeId> { new EmployeeId(Guid.NewGuid()) };
        }
    }
}
