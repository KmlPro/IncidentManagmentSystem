using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.UnitTests.Factories;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.UseCases.CreateDraftApplication
{
    public class TestFixture
    {
        public CreateDraftApplicationInput CreateUseCaseWithRequiredFields(List<string> fileNames = null)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany.Value;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var attachments = fileNames
                ?.Select(FileDataFactory.Create).ToList();

            return new CreateDraftApplicationInput(
                title,
                description,
                incidentType,
                suspiciousEmployees,
                attachments);
        }
    }
}
