using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using JetBrains.Annotations;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class DraftApplication : Entity, IAggregateRoot
    {
        public DraftApplicationId Id { get; private set; }
        public ContentOfApplication ContentOfApplication { get; private set; }
        public IncidentType? IncidentType { get; private set; }
        public SuspiciousEmployees SuspiciousEmployees { get; private set; }
        public List<Attachment> Attachments { get; private set; }
        public EmployeeId ApplicantId { get; }

        public DraftApplication(
            [NotNull] ContentOfApplication contentOfApplication,
            IncidentType? incidentType,
            [NotNull] EmployeeId applicantId,
            [NotNull] SuspiciousEmployees suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.Id = new DraftApplicationId(Guid.NewGuid());
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = new List<Attachment>();

            this.AddDomainEvent(new DraftApplicationCreatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees));
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

            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication, this.IncidentType, this.SuspiciousEmployees));
        }

        public void AddAttachments(List<Attachment> attachments)
        {
            this.Attachments.AddRange(attachments);
            this.AddDomainEvent(new DraftApplicationAttachmentsAdded(this.Id, attachments));
        }

        public void DeleteAttachments(IEnumerable<StorageId> storageIds)
        {
            var attachmentsToRemove = this.Attachments.Where(x => storageIds.Contains(x.StorageId)).ToList();
            this.Attachments.RemoveAll(x => attachmentsToRemove.Contains(x));

            this.AddDomainEvent(new DraftApplicationAttachmentsDeleted(this.Id, attachmentsToRemove));
        }

        private DraftApplication()
        {

        }
    }
}
