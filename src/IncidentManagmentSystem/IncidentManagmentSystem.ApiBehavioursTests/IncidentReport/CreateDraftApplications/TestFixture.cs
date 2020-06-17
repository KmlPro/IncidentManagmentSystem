using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.CreateDraftApplications
{
    public class TestFixture
    {
        public MultipartFormDataContent CreateMultipartFormDataContent()
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };

            var formData = new MultipartFormDataContent
            {
                {new StringContent(title), nameof(CreateDraftApplicationRequest.Title)},
                {new StringContent(description), nameof(CreateDraftApplicationRequest.Description)},
                {new StringContent(incidentType.ToString()), nameof(CreateDraftApplicationRequest.IncidentType)},
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

        public HttpClient GetHttpClient()
        {
            var hostBuilder = TestWebHostBuilderFactory.Create();
            var host = hostBuilder.StartAsync().Result;

            return host.GetTestClient();
        }
    }
}
