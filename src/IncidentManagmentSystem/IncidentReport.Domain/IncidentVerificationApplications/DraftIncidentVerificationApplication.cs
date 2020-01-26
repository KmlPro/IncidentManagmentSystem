using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class DraftIncidentVerificationApplication : Entity, IAggregateRoot
    {
        public DraftApplicationId Id { get; private set; }
        public ContentOfApplication ContentOfApplication { get; private set; }
        public IncidentType? IncidentType { get; private set; }
        public UserId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; private set; }
        public IncidentVerificationApplicationAttachments IncidentVerificationApplicationAttachments { get; private set; }

        public DraftIncidentVerificationApplication(
            ContentOfApplication contentOfApplication,
            IncidentType? incidentType,
            UserId applicantId,
            SuspiciousEmployees suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));
            this.CheckRule(new FieldShouldBeFilledRule(applicantId, nameof(this.ApplicantId)));

            this.Id = new DraftApplicationId(Guid.NewGuid());
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new DraftIncidentVerificationApplicationCreatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees));
        }

        public void Update(
            ContentOfApplication contentOfApplication,
            IncidentType? incidentType,
            SuspiciousEmployees suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, this.ApplicantId));

            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new DraftIncidentVerificationApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments));
        }

        public void AddAttachments(IEnumerable<IncidentVerificationApplicationAttachment> attachments)
        {
            this.IncidentVerificationApplicationAttachments.AddRange(attachments);
            this.AddDomainEvent(new DraftIncidentVerificationApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments));
        }

        public void DeleteAttachments(IEnumerable<StorageId> storageIds)
        {
            this.IncidentVerificationApplicationAttachments.DeleteRange(storageIds);
            this.AddDomainEvent(new DraftIncidentVerificationApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments));
        }
    }
}
