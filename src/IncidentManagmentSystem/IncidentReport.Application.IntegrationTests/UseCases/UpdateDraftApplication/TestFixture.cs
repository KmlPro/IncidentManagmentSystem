using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Application.IntegrationTests.TestFixtures.DraftApplicationFixtures;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.IntegrationTests.UseCases.UpdateDraftApplication
{
    public class TestFixture
    {
        private DraftApplicationFactory _draftApplicationFactory;
        private DraftApplicationTestFixture _draftApplicationTestFixture;
        private IDraftApplicationRepository _draftApplicationRepository;
        public TestFixture(IDraftApplicationRepository draftApplicationRepository)
        {
            this._draftApplicationFactory = new DraftApplicationFactory();
            this._draftApplicationTestFixture = new DraftApplicationTestFixture();
            this._draftApplicationRepository = draftApplicationRepository;
        }

        public async Task<UpdateDraftApplicationInput> PrepareUseCaseWithTestData(EmployeeId applicant,
            List<EmployeeId> suspiciousEmployees, List<EmployeeId> initialSuspiciousEmployees)
        {
            var newDraftApplication = this._draftApplicationFactory.Create(applicant, initialSuspiciousEmployees);
            this._draftApplicationTestFixture.SaveDraftApplicationInDb(newDraftApplication);

            var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value,
                suspiciousEmployees.Select(x => x.Value).ToList(), IncidentType.FinancialViolations.Value, null, null);
            return useCase;
        }

        public async Task<UpdateDraftApplicationInput> PrepareUseCaseWithTestData(EmployeeId applicant,
            List<EmployeeId> suspiciousEmployees, List<FileData> addedAttachments,
            List<Guid> deleteAttachments, List<Attachment> initialAttachments)
        {
            var newDraftApplication = this._draftApplicationFactory.Create(applicant,suspiciousEmployees);
            newDraftApplication.AddAttachments(initialAttachments);
            this._draftApplicationTestFixture.SaveDraftApplicationInDb(newDraftApplication);

            var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees.Select(x=> x.Value).ToList(),
                IncidentType.FinancialViolations.Value, addedAttachments, deleteAttachments);
            return useCase;
        }

        public async Task<DraftApplication> GetDraftFromContext(Guid id)
        {
            return await this._draftApplicationRepository.GetById(new DraftApplicationId(id), new CancellationToken());
        }

        private UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(Guid draftApplicationId,
            List<Guid> suspiciousEmployees, string incidentType, List<FileData> addedAttachments,
            List<Guid> deleteAttachments)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);

            return new UpdateDraftApplicationInput(
                draftApplicationId,
                title,
                description,
                incidentType,
                suspiciousEmployees,
                addedAttachments,
                deleteAttachments);
        }
    }
}
