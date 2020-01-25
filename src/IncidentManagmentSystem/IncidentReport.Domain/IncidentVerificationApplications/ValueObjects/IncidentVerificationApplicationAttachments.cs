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

        private readonly List<IncidentVerificationApplicationAttachment> _addedAttachments;
        public ReadOnlyCollection<IncidentVerificationApplicationAttachment> AddedAttachments => this._addedAttachments.AsReadOnly();

        private readonly List<IncidentVerificationApplicationAttachment> _deletedAttachments;
        public ReadOnlyCollection<IncidentVerificationApplicationAttachment> DeletedAttachments => this._deletedAttachments.AsReadOnly();

        public IncidentVerificationApplicationAttachments(List<IncidentVerificationApplicationAttachment> incidentVerificationApplicationAttachments)
        {
            this._attachments = incidentVerificationApplicationAttachments;
            this._addedAttachments = new List<IncidentVerificationApplicationAttachment>();
            this._addedAttachments.AddRange(incidentVerificationApplicationAttachments);
            this._deletedAttachments = new List<IncidentVerificationApplicationAttachment>();
        }

        public IncidentVerificationApplicationAttachments()
        {
            this._attachments = new List<IncidentVerificationApplicationAttachment>();
            this._deletedAttachments = new List<IncidentVerificationApplicationAttachment>();
            this._addedAttachments = new List<IncidentVerificationApplicationAttachment>();
        }

        public void AddRange(IEnumerable<IncidentVerificationApplicationAttachment> incidentVerificationApplicationAttachment)
        {
            this._attachments.AddRange(incidentVerificationApplicationAttachment);
        }

        public void DeleteRange(IEnumerable<StorageId> storageIds)
        {
            //kbytner 22.01.2020 -- i should think about this... 
            //kbytner 22.01.2020 - to do, Value Object should overrite equals expresion
            foreach (var storageId in storageIds)
            {
                if (!this._deletedAttachments.Any(x => x.StorageId.Value == storageId.Value))
                {
                    this._deletedAttachments.Add(this._attachments.Single(x => x.StorageId.Value == storageId.Value));
                    this._attachments.RemoveAll(x => x.StorageId.Value == storageId.Value);
                }
            }
        }
    }
}
