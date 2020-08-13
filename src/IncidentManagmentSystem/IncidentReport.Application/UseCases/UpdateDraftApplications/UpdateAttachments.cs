using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Factories;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UseCases.UpdateDraftApplications
{
    public class UpdateAttachments
    {
        private readonly AttachmentsFactory _attachmentsFactory;
        private readonly IFileStorageService _fileStorageService;

        public UpdateAttachments(IFileStorageService fileStorageService)
        {
            this._attachmentsFactory = new AttachmentsFactory();
            this._fileStorageService = fileStorageService;
        }

        public async Task Handle(DraftApplication draftApplication, UpdateDraftApplicationInput input)
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

        private bool IfAddedAttachmentsExists(UpdateDraftApplicationInput request)
        {
            return request.AddedAttachments != null && request.AddedAttachments.Any();
        }

        private void AddUploadedFilesAsAttachments(DraftApplication draftApplication,
            List<UploadedFile> files)
        {
            var attachments = this._attachmentsFactory.CreateAttachments(files);
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
