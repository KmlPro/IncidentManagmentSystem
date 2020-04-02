using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class AttachmentsToApplication : ValueObject
    {
        private readonly List<Attachment> _attachments;
        public ReadOnlyCollection<Attachment> Attachments => this._attachments.AsReadOnly();

        private readonly List<Attachment> _deletedAttachments;
        public ReadOnlyCollection<Attachment> DeletedAttachments => this._deletedAttachments.AsReadOnly();

        public AttachmentsToApplication(List<Attachment> incidentVerificationApplicationAttachments)
        {
            this._attachments = incidentVerificationApplicationAttachments;
            this._deletedAttachments = new List<Attachment>();
        }

        public AttachmentsToApplication()
        {
            this._attachments = new List<Attachment>();
            this._deletedAttachments = new List<Attachment>();
        }

        public void AddRange(IEnumerable<Attachment> incidentVerificationApplicationAttachment)
        {
            this._attachments.AddRange(incidentVerificationApplicationAttachment);
        }

        public void DeleteRange(IEnumerable<StorageId> storageIds)
        {
            foreach (var storageId in storageIds)
            {
                if (this._attachments.Any(x => x.StorageId == storageId))
                {
                    this._deletedAttachments.Add(this._attachments.Single(x => x.StorageId == storageId));
                    this._attachments.RemoveAll(x => x.StorageId == storageId);
                }
            }
        }
    }
}
