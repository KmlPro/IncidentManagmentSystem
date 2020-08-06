using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagementSystem.ApiBehavioursTests.EmployeesFixtures;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagementSystem.ApiBehavioursTests.GetResources.DraftApplications
{
    public class TestFixture
    {
        public void CreateDraftApplicationInDB(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = this.CreateTestDraftApplicationEntity(applicant, suspiciousEmployee);
            this.AddAttachment(draftApplication);

            TestDatabaseInitializer.SeedDataForTest(dbContext =>
                {
                    dbContext.DraftApplication.Add(draftApplication);
                }
            );
        }

        private void AddAttachment(DraftApplication draftApplication)
        {
            draftApplication.AddAttachments(new List<Attachment>()
            {
                new Attachment(new FileInfo("testFile.pdf"), new StorageId(Guid.NewGuid()))
            });
        }

        private DraftApplication CreateTestDraftApplicationEntity(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = new DraftApplication(
                new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(100)),
                IncidentType.AdverseEffectForTheCompany, applicant,
                new List<EmployeeId>() {suspiciousEmployee});
            return draftApplication;
        }
    }
}
