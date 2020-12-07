using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.IntegrationTests.Factories;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;

namespace IncidentReport.Application.IntegrationTests.UseCases.CreateDraftApplication
{
    public class TestFixture
    {
        private readonly IDraftApplicationRepository _repository;

        public TestFixture(IDraftApplicationRepository repository)
        {
            this._repository = repository;
        }

        public CreateDraftApplicationInput CreateUseCaseWithRequiredFields(Guid suspiciousEmployee, List<string> fileNames = null)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany.Value;
            var suspiciousEmployees = new List<Guid> { suspiciousEmployee };
            var attachments = fileNames
                ?.Select(FileDataFactory.Create).ToList();

            return new CreateDraftApplicationInput(
                title,
                description,
                incidentType,
                suspiciousEmployees,
                attachments);
        }

        public async Task<bool> IsDraftApplicationAdded(Guid id)
        {
            try
            {
                var aggregate = await this._repository.GetById(new DraftApplicationId(id), new CancellationToken());
                return true;
            }
            catch (AggregateNotFoundInDbException)
            {
                return false;
            }
        }
    }
}
