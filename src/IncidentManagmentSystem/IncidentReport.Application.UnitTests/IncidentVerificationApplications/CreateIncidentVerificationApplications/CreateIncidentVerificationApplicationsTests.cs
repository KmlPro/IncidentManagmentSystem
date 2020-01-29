using System;
using System.Collections.Generic;
using IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.IncidentVerificationApplications.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationsTests : BaseTest
    {
        [Test]
        public void CreateIncidentVerificationApplicationCommand_AllFieldsAreFilled_DraftCreatedSuccessfully()
        {
            var command = new CreateIncidentVerificationApplicationCommand(
                 Faker.StringFaker.AlphaNumeric(100),
                 Faker.StringFaker.AlphaNumeric(100),
                 IncidentType.AdverseEffectForTheCompany,
                 new List<Guid> { Guid.NewGuid() },
                 null);

           // var handler = new CreateIncidentVerificationApplicationCommandHandler();
        }
    }
}
