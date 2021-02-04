using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.DraftApplicationFixtures;
using IncidentManagementSystem.Web.IncidentReports.UseCases.PostApplications;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Domain.ValueObjects;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.UseCases.PostApplications
{
    public class TestFixture
    {
        private DraftApplicationFactory _draftApplicationFactory;
        private DraftApplicationTestFixture _draftApplicationTestFixture;

        public TestFixture()
        {
            this._draftApplicationFactory = new DraftApplicationFactory();
            this._draftApplicationTestFixture = new DraftApplicationTestFixture();
        }

        public Guid CreateDraftApplicationInDb(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = this._draftApplicationFactory.Create(applicant, suspiciousEmployee);
            this._draftApplicationTestFixture.SaveDraftApplicationInDb(draftApplication);

            return draftApplication.Id.Value;
        }

        public MultipartFormDataContent CreateRequestContent(Guid suspiciousEmployee, Guid? draftApplicationId)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> {suspiciousEmployee};

            var formData = new MultipartFormDataContent
            {
                {new StringContent(title), nameof(PostApplicationRequest.Title)},
                {new StringContent(description), nameof(PostApplicationRequest.Content)},
                {new StringContent(incidentType.ToString()), nameof(PostApplicationRequest.IncidentType)},
                {
                    new StringContent(string.Join(", ", suspiciousEmployees)),
                    nameof(PostApplicationRequest.SuspiciousEmployees)
                }
            };
            this.AddAttachments(formData, new List<string>() {"Text.txt"});
            if (draftApplicationId.HasValue)
            {
                this.AddDraftApplicationId(formData, draftApplicationId.Value);
            }

            return formData;
        }

        private void AddDraftApplicationId(MultipartFormDataContent formData, Guid draftApplicationId)
        {
            formData.Add(new StringContent(draftApplicationId.ToString()),
                nameof(PostApplicationRequest.DraftApplicationId)
            );
        }

        private void AddAttachments(MultipartFormDataContent formData, List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                formData.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(fileName)), "Attachments", fileName);
            }
        }
    }
}
