using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.UpdateDraftApplications
{
    public class TestFixture
    {
        protected DraftApplication DraftApplication { get; set; }

        public TestFixture()
        {
            this.DraftApplication = this.GetTestDraftApplicationEntity();
        }

        private DraftApplication GetTestDraftApplicationEntity()
        {
            var draftApplication = new DraftApplication(new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(100)), IncidentType.AdverseEffectForTheCompany, new EmployeeId(Guid.NewGuid()), new List<EmployeeId>() { new EmployeeId(Guid.NewGuid()) });
            return draftApplication;
        }

        public MultipartFormDataContent CreateMultipartFormDataContent()
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;

            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };

            var formData = new MultipartFormDataContent
            {
                {new StringContent(title), nameof(UpdateDraftApplicationRequest.Title)},
                {new StringContent(description), nameof(UpdateDraftApplicationRequest.Description)},
                {new StringContent(incidentType.ToString()), nameof(UpdateDraftApplicationRequest.IncidentType)},
                {
                    new StringContent(string.Join(", ", suspiciousEmployees)),
                    nameof(CreateDraftApplicationRequest.SuspiciousEmployees)
                }
            };

            return formData;
        }

        public void AddAttachments(MultipartFormDataContent formData, List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                formData.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(fileName)), "Attachments", fileName);
            }
        }

        public void SeedDataForTest()
        {
            TestDatabaseInitializer.SeedDataForTest(dbContext => dbContext.DraftApplication.Add(this.DraftApplication));
        }
    }
}
