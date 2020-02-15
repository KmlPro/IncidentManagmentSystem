using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.RequestParameters;
using IncidentManagmentSystem.Web.Tests.Mocks;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace IncidentManagmentSystem.Web.Tests.IncidentReport
{
    public class CreateIncidentVerificationApplicationsTests : BaseTest
    {
        private const string _path = "api/IncidentReport/CreateIncidentVerificationApplication";

        [Test]
        public async Task CreateIncidentVerificationApplication_ValidRequestParameters_ReturnOk()
        {
            var requestObj = this.CreateParameters();
            var requestBody = this.CreateRequestBody(requestObj);

            var response = await this.TestClient.PostAsync(_path, new StringContent(requestBody, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task CreateIncidentVerificationApplication_ValidRequestParameters_WithAttachemtns_ReturnOk()
        {
            var requestObj = this.CreateParameters();
            requestObj.Attachments = new List<IFormFile>() { this.CreateAttachment() };

            var requestBody = this.CreateRequestBody(requestObj);

            var response = await this.TestClient.PostAsync(_path, new StringContent(requestBody, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        private CreateIncidentVerificationApplicationRequest CreateParameters()
        {
            var title = Faker.StringFaker.AlphaNumeric(10);
            var description = Faker.StringFaker.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };

            return new CreateIncidentVerificationApplicationRequest()
            {
                Title = title,
                Description = description,
                IncidentType = incidentType,
                SuspiciousEmployees = suspiciousEmployees,
            };
        }

        private IFormFile CreateAttachment()
        {
            var physicalFile = new FileInfo(@"IncidentReport\TestFiles\attachmentFile.txt");
            var formFile = physicalFile.AsMockIFormFile();

            return formFile;
        }
    }
}
