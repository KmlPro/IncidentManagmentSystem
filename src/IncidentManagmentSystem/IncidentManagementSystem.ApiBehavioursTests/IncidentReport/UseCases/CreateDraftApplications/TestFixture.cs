using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagementSystem.Web.IncidentReports.UseCases.CreateDraftApplications;
using IncidentReport.Domain.ValueObjects;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.UseCases.CreateDraftApplications
{
    public class TestFixture
    {
        public MultipartFormDataContent CreateRequestContent(Guid suspiciousEmployee)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { suspiciousEmployee };

            var formData = new MultipartFormDataContent
            {
                {new StringContent(title), nameof(CreateDraftApplicationRequest.Title)},
                {new StringContent(description), nameof(CreateDraftApplicationRequest.Content)},
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
    }
}
