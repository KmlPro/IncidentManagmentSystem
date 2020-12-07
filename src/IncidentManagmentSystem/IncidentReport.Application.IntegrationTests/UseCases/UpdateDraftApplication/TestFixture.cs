using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Application.IntegrationTests.Factories;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.IntegrationTests.UseCases.UpdateDraftApplication
{
    public class TestFixture
    {
        private IDraftApplicationRepository _draftApplicationRepository { get; }

        public TestFixture(IDraftApplicationRepository draftApplicationRepository)
        {
            this._draftApplicationRepository = draftApplicationRepository;
        }

        // public async Task<UpdateDraftApplicationInput> PrepareUseCaseWithTestData(List<Guid> suspiciousEmployees, List<Guid> initialSuspiciousEmployees)
        // {
        //     var newDraftApplication = DraftApplicationFactory.Create(initialSuspiciousEmployees);
        //     await this._draftApplicationRepository.Create(newDraftApplication, new CancellationToken());
        //
        //     var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees, IncidentType.FinancialViolations.Value, null, null);
        //     return useCase;
        // }
        //
        // public async Task<UpdateDraftApplicationInput> PrepareUseCaseWithTestData(List<FileData> addedAttachments, List<Guid> deleteAttachments, List<Attachment> initialAttachments)
        // {
        //     var suspiciousEmployees = new List<Guid>() { Guid.NewGuid() };
        //     var newDraftApplication = DraftApplicationFactory.Create(suspiciousEmployees);
        //     newDraftApplication.AddAttachments(initialAttachments);
        //     await this._draftApplicationRepository.Create(newDraftApplication, new CancellationToken());
        //
        //     var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees, IncidentType.FinancialViolations.Value, addedAttachments, deleteAttachments);
        //     return useCase;
        // }

        public async Task<DraftApplication> GetDraftFromContext(Guid id)
        {
            return await this._draftApplicationRepository.GetById(new DraftApplicationId(id), new CancellationToken());
        }

        private UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(Guid draftApplicationId, List<Guid> suspiciousEmployees, string incidentType, List<FileData> addedAttachments, List<Guid> deleteAttachments)
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
