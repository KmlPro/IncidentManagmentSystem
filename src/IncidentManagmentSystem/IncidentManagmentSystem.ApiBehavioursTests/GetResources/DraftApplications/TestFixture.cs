using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagmentSystem.ApiBehavioursTests.GetResources.DraftApplications
{
    public class TestFixture
    {
        public void CreateDraftApplicationInDB()
        {
            var employees = this.CreateEmployees();
            var draftApplication = this.CreateTestDraftApplicationEntity(employees.First().Id, employees.Last().Id);
            this.AddAttachment(draftApplication);

            TestDatabaseInitializer.SeedDataForTest(dbContext =>
                {
                    dbContext.Employee.AddRange(employees);
                    dbContext.DraftApplication.Add(draftApplication);
                }
            );
        }

        private List<Employee> CreateEmployees()
        {
            return new List<Employee>()
            {
                new Employee(FakeData.Alpha(12), FakeData.Alpha(100)),
                new Employee(FakeData.Alpha(20), FakeData.Alpha(50))
            };
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
