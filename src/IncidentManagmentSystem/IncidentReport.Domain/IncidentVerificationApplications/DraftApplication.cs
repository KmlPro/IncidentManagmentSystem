using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class DraftApplication : Entity, IAggregateRoot
    {
        public DraftApplicationId Id { get; private set; }
        public ContentOfApplication ContentOfApplication { get; private set; }
        public IncidentType? IncidentType { get; private set; }
        public EmployeeId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; private set; }
        public AttachmentsToApplication IncidentVerificationApplicationAttachments { get; private set; }

        public DraftApplication(
            ContentOfApplication contentOfApplication,
            IncidentType? incidentType,
            EmployeeId applicantId,
            SuspiciousEmployees suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.Id = new DraftApplicationId(Guid.NewGuid());
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.IncidentVerificationApplicationAttachments = new AttachmentsToApplication();

            this.AddDomainEvent(new DraftApplicationCreatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees));
        }

        public void Update(
            ContentOfApplication contentOfApplication,
            IncidentType? incidentType,
            SuspiciousEmployees suspiciousEmployees)
        {
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments));
        }

        public void AddAttachments(IEnumerable<Attachment> attachments)
        {
            this.IncidentVerificationApplicationAttachments.AddRange(attachments);
            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments));
        }

        public void DeleteAttachments(IEnumerable<StorageId> storageIds)
        {
            this.IncidentVerificationApplicationAttachments.DeleteRange(storageIds);
            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments));
        }

        private DraftApplication()
        {

        }
    }
}
