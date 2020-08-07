using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.UnitTests.Factories;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.UseCases.PostApplication
{
    public class TestFixture
    {
        public DraftApplication PrepareDraftApplication(IDraftApplicationRepository draftApplicationRepository)
        {
            var draftApplication = DraftApplicationFactory.Create();
            draftApplicationRepository.Create(draftApplication);
            return draftApplication;
        }

        public PostApplicationInput CreateInput(DraftApplicationId draftApplicationId)
        {
            var fileNames = new List<string> {"test.txt, test1.txt"};
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany.Value;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var attachments = fileNames
                .Select(FileDataFactory.Create).ToList();

            return new PostApplicationInput(
                draftApplicationId != null ? (Guid?)draftApplicationId.Value : null,
                title,
                description,
                incidentType,
                suspiciousEmployees,
                attachments);
        }
    }
}
