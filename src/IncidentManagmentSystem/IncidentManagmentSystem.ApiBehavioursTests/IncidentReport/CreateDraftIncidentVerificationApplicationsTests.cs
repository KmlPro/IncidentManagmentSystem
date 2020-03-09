using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.DraftIncidentVerificationApplication.RequestParameters;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using NUnit.Framework;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport
{
    public class CreateDraftIncidentVerificationApplicationsTests : BaseTest
    {
        private const string _path = "api/DraftIncidentVerificationApplication";

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
            var title = Faker.StringFaker.AlphaNumeric(10);
            var description = Faker.StringFaker.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };

            var formData = new MultipartFormDataContent
            {
                { new StringContent(title), nameof(CreateDraftIncidentVerificationApplicationRequest.Title) },
                { new StringContent(description), nameof(CreateDraftIncidentVerificationApplicationRequest.Description) },
                { new StringContent(incidentType.ToString()), nameof(CreateDraftIncidentVerificationApplicationRequest.IncidentType) },
                { new StringContent(string.Join(", ", suspiciousEmployees)), nameof(CreateDraftIncidentVerificationApplicationRequest.SuspiciousEmployees) }
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
