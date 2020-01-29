using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class IncidentVerificationApplicationAttachments : ValueObject
    {
        private readonly List<IncidentVerificationApplicationAttachment> _attachments;
        public ReadOnlyCollection<IncidentVerificationApplicationAttachment> Attachments => this._attachments.AsReadOnly();


        private readonly List<IncidentVerificationApplicationAttachment> _deletedAttachments;
        public ReadOnlyCollection<IncidentVerificationApplicationAttachment> DeletedAttachments => this._deletedAttachments.AsReadOnly();

        public IncidentVerificationApplicationAttachments(List<IncidentVerificationApplicationAttachment> incidentVerificationApplicationAttachments)
        {
            this._attachments = incidentVerificationApplicationAttachments;
            this._deletedAttachments = new List<IncidentVerificationApplicationAttachment>();
        }

        public IncidentVerificationApplicationAttachments()
        {
            this._attachments = new List<IncidentVerificationApplicationAttachment>();
            this._deletedAttachments = new List<IncidentVerificationApplicationAttachment>();
        }

        public void AddRange(IEnumerable<IncidentVerificationApplicationAttachment> incidentVerificationApplicationAttachment)
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