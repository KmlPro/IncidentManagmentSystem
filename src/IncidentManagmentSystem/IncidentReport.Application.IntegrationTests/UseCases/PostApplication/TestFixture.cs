using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.PostApplicationUseCase;
using IncidentReport.Application.IntegrationTests.Factories;
using IncidentReport.Application.IntegrationTests.TestFixtures.DraftApplicationFixtures;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.Persistence.Repositories.Exceptions;

namespace IncidentReport.Application.IntegrationTests.UseCases.PostApplication
{
    public class TestFixture
    {
        private readonly IIncidentApplicationRepository _incidentApplicationRepository;
        private readonly IDraftApplicationRepository _draftApplicationRepository;
        private DraftApplicationFactory _draftApplicationFactory;
        private DraftApplicationTestFixture _draftApplicationTestFixture;

        public TestFixture(IIncidentApplicationRepository incidentApplicationRepository,
            IDraftApplicationRepository draftApplicationRepository)
        {
            this._incidentApplicationRepository = incidentApplicationRepository;
            this._draftApplicationRepository = draftApplicationRepository;

            this._draftApplicationFactory = new DraftApplicationFactory();
            this._draftApplicationTestFixture = new DraftApplicationTestFixture();
        }

        public DraftApplicationId CreateDraftApplicationInDb(EmployeeId applicant, EmployeeId suspiciousEmployee)
        {
            var draftApplication = this._draftApplicationFactory.Create(applicant, suspiciousEmployee);
            this._draftApplicationTestFixture.SaveDraftApplicationInDb(draftApplication);

            return draftApplication.Id;
        }

        public PostApplicationInput CreateInput(Guid suspiciousEmployee, Guid? draftApplicationId)
        {
            var fileNames = new List<string> {"test.txt, test1.txt"};
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany.Value;
            var suspiciousEmployees = new List<Guid> { suspiciousEmployee };
            var attachments = fileNames
                .Select(FileDataFactory.Create).ToList();

            return new PostApplicationInput(
                draftApplicationId,
                title,
                description,
                incidentType,
                suspiciousEmployees,
                attachments);
        }

        public async Task<bool> IsIncidentApplicationAdded(Guid id)
        {
            try
            {
                var aggregate = await this._incidentApplicationRepository.GetPostedById(new IncidentApplicationId(id), new CancellationToken());
                return true;
            }
            catch (AggregateNotFoundInDbException)
            {
                return false;
            }
        }

        public async Task<bool> IsDraftApplicationExists(Guid id)
        {
            try
            {
                var aggregate = await this._draftApplicationRepository.GetById(new DraftApplicationId(id), new CancellationToken());
                return true;
            }
            catch (AggregateNotFoundInDbException)
            {
                return false;
            }
        }
    }
}
