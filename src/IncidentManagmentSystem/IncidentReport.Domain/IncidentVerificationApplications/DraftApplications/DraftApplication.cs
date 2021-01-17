using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain.Abstract;
using Dawn;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.DraftApplications
{
    public class DraftApplication : AggregateRoot
    {
        public static DraftApplication Create(
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees)
        {
            var id = DraftApplicationId.Create();
            var draftApplication = new DraftApplication(id, contentOfApplication, incidentType, applicantId, suspiciousEmployees);

            draftApplication.AddDomainEvent(new DraftApplicationCreatedDomainEvent(id, contentOfApplication,
                incidentType, applicantId, suspiciousEmployees));

            return draftApplication;
        }

        private DraftApplication(
            DraftApplicationId draftApplicationId,
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ApplicantId = Guard.Argument(applicantId, nameof(applicantId)).NotNull();
            this.ContentOfApplication = Guard.Argument(contentOfApplication, nameof(contentOfApplication)).NotNull();
            this.Id = Guard.Argument(draftApplicationId, nameof(draftApplicationId)).NotNull();

            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();
            this.Attachments = new List<Attachment>();
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
            IncidentType incidentType,
            List<EmployeeId> employeeIds)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(employeeIds, this.ApplicantId));

            this.ContentOfApplication =
                contentOfApplication ?? throw new ArgumentNullException(nameof(contentOfApplication));
            this.IncidentType = incidentType;

            var suspiciousEmployees = employeeIds.Select(x => new SuspiciousEmployee(x)).ToList();
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.ContentOfApplication,
                this.IncidentType, this.SuspiciousEmployees));
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
