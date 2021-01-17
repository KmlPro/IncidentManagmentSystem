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
            Title tile,
            Content content,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees)
        {
            var id = DraftApplicationId.Create();
            var suspiciousEmployeesList = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();

            var draftApplication = new DraftApplication(id, content, tile, incidentType, applicantId, suspiciousEmployeesList);

            draftApplication.AddDomainEvent(new DraftApplicationCreatedDomainEvent(id, content,
                incidentType, applicantId, suspiciousEmployeesList));

            return draftApplication;
        }

        private DraftApplication(
            DraftApplicationId draftApplicationId,
            Content content,
            Title title,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<SuspiciousEmployee> suspiciousEmployees)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees.Select(x=> x.EmployeeId).ToList(), applicantId));

            this.ApplicantId = Guard.Argument(applicantId, nameof(applicantId)).NotNull();
            this.Content = Guard.Argument(content, nameof(content)).NotNull();
            this.Title = Guard.Argument(title, nameof(title)).NotNull();
            this.Id = Guard.Argument(draftApplicationId, nameof(draftApplicationId)).NotNull();

            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = new List<Attachment>();
        }

        private DraftApplication()
        {
            this.Attachments = new List<Attachment>();
            this.SuspiciousEmployees = new List<SuspiciousEmployee>();
        }

        public DraftApplicationId Id { get; }
        public Content Content { get; private set; }
        public Title Title { get; private set; }
        public IncidentType IncidentType { get; private set; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; private set; }
        public List<Attachment> Attachments { get; }
        public EmployeeId ApplicantId { get; }

        public void Update(
            Content content,
            Title title,
            IncidentType incidentType,
            List<EmployeeId> employeeIds)
        {
            this.CheckRule(new ApplicantCannotBeSuspectRule(employeeIds, this.ApplicantId));

            this.Content = Guard.Argument(content,nameof(content)).NotNull();
            this.Title = Guard.Argument(title,nameof(title)).NotNull();

            this.IncidentType = incidentType;

            var suspiciousEmployees = employeeIds.Select(x => new SuspiciousEmployee(x)).ToList();
            this.SuspiciousEmployees = suspiciousEmployees;

            this.AddDomainEvent(new DraftApplicationUpdatedDomainEvent(this.Id, this.Content,
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
