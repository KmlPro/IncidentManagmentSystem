using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.DraftApplications
{
    public class DraftApplication : Entity, IAggregateRoot
    {
        public DraftApplication(
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ApplicantId = applicantId ?? throw new ArgumentNullException(nameof(applicantId));
            this.ContentOfApplication =
                contentOfApplication ?? throw new ArgumentNullException(nameof(contentOfApplication));

            this.Id = new DraftApplicationId(Guid.NewGuid());
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();
            this.Attachments = new List<Attachment>();

            this.AddDomainEvent(new DraftApplicationCreatedDomainEvent(this.Id, this.ContentOfApplication,
                this.IncidentType, this.ApplicantId, this.SuspiciousEmployees));
        }

        private DraftApplication()
        {
            this.Attachments = new List<Attachment>();
            this.SuspiciousEmployees = new List<SuspiciousEmployee>();
        }

        public DraftApplicationId Id { get; }
        public ContentOfApplication ContentOfApplication { get; private set; }
        public IncidentType IncidentType { get; private set; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; private set; }
        public List<Attachment> Attachments { get; }
        public EmployeeId ApplicantId { get; }

        public void Update(
            ContentOfApplication contentOfApplication,
            IncidentType incidentType)
        {
            this.ContentOfApplication =
                contentOfApplication ?? throw new ArgumentNullException(nameof(contentOfApplication));
            this.IncidentType = incidentType;

            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication,
                this.IncidentType, this.SuspiciousEmployees));
        }

        public void AddSuspiciousEmployees(List<EmployeeId> employeeIds)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(employeeIds, this.ApplicantId));

            var suspiciousEmployees = employeeIds.Select(x => new SuspiciousEmployee(x)).ToList();
            this.SuspiciousEmployees.AddRange(employeeIds.Select(x => new SuspiciousEmployee(x)));

            this.AddDomainEvent(new DraftApplicationSuspiciousEmployeeAdded(this.Id, suspiciousEmployees));
        }

        public void DeleteSuspiciousEmployees(List<EmployeeId> employeeIds)
        {
            var suspiciousEmployee = employeeIds.Select(x => new SuspiciousEmployee(x)).ToList();
            this.SuspiciousEmployees.RemoveAll(x => employeeIds.Contains(x.EmployeeId));

            this.AddDomainEvent(new DraftApplicationSuspiciousEmployeeDeleted(this.Id, suspiciousEmployee));
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
    }
}
