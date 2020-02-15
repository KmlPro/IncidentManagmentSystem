using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IncidentManagmentSystem.Web.Controllers.IncidentReports.RequestParameters;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
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

        //[Test]
        //public void CreateIncidentVerificationApplication_ValidRequestParameters_WithAttachemtns_ReturnOk()
        //{

        //}

        private CreateIncidentVerificationApplicationRequest CreateParameters()
        {
            var title = Faker.StringFaker.AlphaNumeric(10);
            var description = Faker.StringFaker.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            //var attachments = fileNames?.Select(x => new FileData(x, new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 })).ToList();

            return new CreateIncidentVerificationApplicationRequest(
                  title,
                  description,
                  incidentType,
                  suspiciousEmployees,
                  null);
        }
    }
}
