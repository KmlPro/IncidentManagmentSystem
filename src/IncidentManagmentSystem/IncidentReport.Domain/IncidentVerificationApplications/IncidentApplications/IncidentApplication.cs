using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using Dawn;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications
{
    public class IncidentApplication : AggregateRoot
    {
        public static IncidentApplication Create(Title title,
            Content content,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments)
        {
            var id = IncidentApplicationId.Create();
            var postDate = SystemClock.Now;
            var applicationNumber = new ApplicationNumber(postDate, incidentType);
            var suspiciousEmployeesList = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();

            var application = new IncidentApplication(id,content, title,incidentType, applicantId, suspiciousEmployeesList, attachments, postDate, applicationNumber);
            application.AddDomainEvent(new IncidentApplicationCreated(application));

            return application;
        }

        private IncidentApplication(IncidentApplicationId incidentApplicationId,
            Content content,
            Title title,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<SuspiciousEmployee> suspiciousEmployees,
            List<Attachment> attachments,
            DateTime postDate,
            ApplicationNumber applicationNumber)
        {
            this.ApplicantId = Guard.Argument(applicantId, nameof(applicantId)).NotNull();
            this.Content = Guard.Argument(content, nameof(content)).NotNull();
            this.Title = Guard.Argument(title, nameof(title)).NotNull();
            this.IncidentType = Guard.Argument(incidentType, nameof(incidentType)).NotNull();
            this.Id = Guard.Argument(incidentApplicationId, nameof(incidentApplicationId)).NotNull();
            this.PostDate = Guard.Argument(postDate,nameof(postDate)).NotDefault();

            this.CheckRule(new IndicateAtLeastOneSuspectRule(suspiciousEmployees));
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees.Select(x=> x.EmployeeId).ToList(), applicantId));

            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicationNumber = applicationNumber;
            this.ApplicationState = ApplicationStateValue.Created;
            this.Attachments = attachments ?? new List<Attachment>();
        }

        public Title Title { get; }
        public IncidentApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }
        public Content Content { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }
        public List<Attachment> Attachments { get; }
        public ApplicationStateValue ApplicationState { get; }

        private IncidentApplication()
        {
            this.SuspiciousEmployees = new List<SuspiciousEmployee>();
            this.Attachments = new List<Attachment>();
        }
    }
}
