using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using Dawn;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications
{
    public class IncidentApplication : AggregateRoot
    {
        public static IncidentApplication Create(ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments)
        {
            var id = IncidentApplicationId.Create();
            var postDate = SystemClock.Now;

            var application = new IncidentApplication(id,contentOfApplication, incidentType, applicantId, suspiciousEmployees, attachments, postDate);
            application.AddDomainEvent(new ApplicationCreatedDomainEvent(application));

            return application;
        }

        private IncidentApplication(IncidentApplicationId incidentApplicationId,
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments,
            DateTime postDate)
        {
            this.ApplicantId = Guard.Argument(applicantId, nameof(applicantId)).NotNull();
            this.ContentOfApplication = Guard.Argument(contentOfApplication, nameof(contentOfApplication)).NotNull();
            this.IncidentType = Guard.Argument(incidentType, nameof(incidentType)).NotNull();
            this.Id = Guard.Argument(incidentApplicationId, nameof(incidentApplicationId)).NotNull();
            this.PostDate = Guard.Argument(postDate,nameof(postDate)).NotDefault();

            this.CheckRule(new IndicateAtLeastOneSuspectRule(suspiciousEmployees));
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.SuspiciousEmployees = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();
            this.ApplicationNumber = new ApplicationNumber(this.PostDate, this.IncidentType);
            this.ApplicationState = ApplicationStateValue.Created;
            this.Attachments = attachments ?? new List<Attachment>();
        }

        public IncidentApplicationId Id { get; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; }
        public List<Attachment> Attachments { get; }
        public ApplicationStateValue ApplicationState { get; private set; }

        public void SetState(ApplicationStateValue applicationState)
        {
            this.ApplicationState = applicationState;
        }

        private IncidentApplication()
        {
            this.SuspiciousEmployees = new List<SuspiciousEmployee>();
            this.Attachments = new List<Attachment>();
        }
    }
}
