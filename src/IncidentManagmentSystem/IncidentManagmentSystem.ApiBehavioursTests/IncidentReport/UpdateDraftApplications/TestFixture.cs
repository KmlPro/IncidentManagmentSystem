using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BuildingBlocks.Domain.UnitTests;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentManagmentSystem.ApiBehavioursTests.IncidentReport.UpdateDraftApplications
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
    }
}
