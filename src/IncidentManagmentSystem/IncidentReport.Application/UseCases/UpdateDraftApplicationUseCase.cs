using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Abstract;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Application.UseCases
{
    public class UpdateDraftApplicationUseCase : IUseCase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IIncidentReportDbContext _incidentReportContext;
        private readonly IOutputPort _outputPort;

        public UpdateDraftApplicationUseCase(IIncidentReportDbContext incidentReportContext,
            IFileStorageService fileStorageService,
            IOutputPort outputPort)
        {
            this._incidentReportContext = incidentReportContext;
            this._fileStorageService = fileStorageService;
            this._outputPort = outputPort;
        }

        public async Task<IOutputPort> Handle(UpdateDraftApplicationInput input, CancellationToken cancellationToken)
        {
            try
            {
                var draftApplication =
                 await this._incidentReportContext.DraftApplication.FirstAsync(x =>
                     x.Id == new DraftApplicationId(input.DraftApplicationId), cancellationToken);

                this.UpdateApplicationData(draftApplication, input);
                await this.UpdateAttachments(draftApplication, input);
                this.UpdateSuspiciousEmployees(draftApplication, input);

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

        private void BuildOutput()
        {
            this._outputPort.Standard(new UpdateDraftApplicationOutput());
        }

        private void UpdateSuspiciousEmployees(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            var newSuspiciousEmployees = this.GetNewSuspiciousEmployees(draftApplication, input);
            var removedSuspiciousEmployees = this.GetRemovedSuspiciousEmployees(draftApplication, input);

            if (newSuspiciousEmployees.Any())
            {
                draftApplication.AddSuspiciousEmployees(newSuspiciousEmployees);
            }

            if (removedSuspiciousEmployees.Any())
            {
                draftApplication.DeleteSuspiciousEmployees(removedSuspiciousEmployees);
            }
        }

        private List<EmployeeId> GetRemovedSuspiciousEmployees(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            return draftApplication.SuspiciousEmployees.
                Where(se => !input.SuspiciousEmployees.Contains(se.EmployeeId.Value))
                .Select(x => x.EmployeeId).ToList();
        }

        private async Task UpdateAttachments(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            if (this.IfAddedAttachmentsExists(input))
            {
                var files = await this.UploadFilesToStorage(input);
                this.AddUploadedFilesAsAttachments(draftApplication, files);
            }

            if (this.IfDeletedAttachmentExists(input))
            {
                this.DeleteAttachments(draftApplication, input);
            }
        }

        private List<EmployeeId> GetNewSuspiciousEmployees(DraftApplication draftApplication, UpdateDraftApplicationInput input)
        {
            return input.SuspiciousEmployees.
                Where(se => !draftApplication.SuspiciousEmployees.Select(x => x.EmployeeId.Value).Contains(se))
                .Select(x => new EmployeeId(x)).ToList();
        }

        private void UpdateApplicationData(DraftApplication draftApplication, UpdateDraftApplicationInput request)
        {
            draftApplication.Update(
                new ContentOfApplication(request.Title, request.Description),
                new IncidentType(request.IncidentType));
        }

        private bool IfAddedAttachmentsExists(UpdateDraftApplicationInput request)
        {
            return request.AddedAttachments != null && request.AddedAttachments.Any();
        }

        private void AddUploadedFilesAsAttachments(DraftApplication draftApplication,
            List<UploadedFile> files)
        {
            var attachments = files.Select(x => new Attachment(new FileInfo(x.FileName), new StorageId(x.StorageId)))
                .ToList();
            draftApplication.AddAttachments(attachments);
        }

        private Task<List<UploadedFile>> UploadFilesToStorage(UpdateDraftApplicationInput request)
        {
            return this._fileStorageService.UploadFiles(request.AddedAttachments);
        }

        private bool IfDeletedAttachmentExists(UpdateDraftApplicationInput request)
        {
            return request.DeletedAttachments != null && request.DeletedAttachments.Any();
        }

        private void DeleteAttachments(DraftApplication draftApplication,
            UpdateDraftApplicationInput request)
        {
            draftApplication.DeleteAttachments(
                request.DeletedAttachments.Select(x => new StorageId(x)));
        }
    }
}
