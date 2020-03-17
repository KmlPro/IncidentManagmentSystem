using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport
{
    public class CreateDraftApplicationsTests : BaseTest
    {
        private const string _path = "api/DraftApplication";

        [Test]
        public async Task CreateIncidentVerificationApplication_ValidRequestParameters_ReturnOk()
        {
            var requestParameters = this.CreateMultipartFormDataContent();

            var response = await this.TestClient.PostAsync(_path, requestParameters);

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CreateIncidentVerificationApplication_ValidRequestParameters_WithAttachemtns_ReturnOk()
        {
            var requestParameters = this.CreateMultipartFormDataContent();
            this.AddAttachments(requestParameters, new List<string>() { "test1.txt", "test2.txt" });

            var response = await this.TestClient.PostAsync(_path, requestParameters);

            response.EnsureSuccessStatusCode();
        }

        private MultipartFormDataContent CreateMultipartFormDataContent()
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };

            var formData = new MultipartFormDataContent
            {
                { new StringContent(title), nameof(CreateDraftApplicationRequest.Title) },
                { new StringContent(description), nameof(CreateDraftApplicationRequest.Description) },
                { new StringContent(incidentType.ToString()), nameof(CreateDraftApplicationRequest.IncidentType) },
                { new StringContent(string.Join(", ", suspiciousEmployees)), nameof(CreateDraftApplicationRequest.SuspiciousEmployees) }
            };

            return formData;
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
