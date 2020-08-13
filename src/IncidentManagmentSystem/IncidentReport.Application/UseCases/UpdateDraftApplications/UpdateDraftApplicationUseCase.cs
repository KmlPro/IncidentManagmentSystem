using System;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Abstract;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationUseCase : IUseCase
    {
        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IOutputPort _outputPort;
        private readonly UpdateSuspiciousEmployees _updateSuspiciousEmployees;
        private readonly UpdateAttachments _updateAttachments;

        public UpdateDraftApplicationUseCase(IIncidentReportDbContext incidentReportContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._incidentReportContext = incidentReportContext;
            this._outputPort = outputPort;
            this._updateAttachments = new UpdateAttachments(fileStorageService);
            this._updateSuspiciousEmployees = new UpdateSuspiciousEmployees();
        }

        public async Task<IOutputPort> Handle(UpdateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                var draftApplication =
                    await this.GetDraftApplication(input.DraftApplicationId, cancellationToken);

                this.UpdateApplicationData(draftApplication, input);
                await this._updateAttachments.Handle(draftApplication, input);
                this._updateSuspiciousEmployees.Handle(draftApplication, input);

                this.BuildOutput();
            }
            catch (BusinessRuleValidationException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }
            catch (ApplicationLayerException ex)
            {
                this._outputPort.WriteBusinessRuleError(ex.ToString());
            }

            return this._outputPort;
        }

        private async Task<DraftApplication> GetDraftApplication(Guid id,CancellationToken cancellationToken)
        {
            return await this._incidentReportContext.DraftApplication.Include(nameof(DraftApplication.Attachments)).FirstAsync(x =>
                x.Id == new DraftApplicationId(id), cancellationToken);
        }

        private void BuildOutput()
        {
            this._outputPort.Standard(new UpdateDraftApplicationOutput());
        }

        private void UpdateApplicationData(DraftApplication draftApplication, UpdateDraftApplicationInput request)
        {
            draftApplication.Update(
                new ContentOfApplication(request.Title, request.Description),
                new IncidentType(request.IncidentType));
        }
    }
}
