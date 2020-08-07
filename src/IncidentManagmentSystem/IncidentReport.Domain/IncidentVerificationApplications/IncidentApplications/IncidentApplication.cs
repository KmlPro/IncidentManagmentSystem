using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications
{
    public class IncidentApplication : Entity, IAggregateRoot
    {
        public static CreatedIncidentApplication Create(ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments)
        {
            var application = new IncidentApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployees, attachments);
            return new CreatedIncidentApplication(application);
        }

        protected IncidentApplication(IncidentApplication incidentApplication)
        {
            if (incidentApplication == null)
            {
                throw new ArgumentNullException(nameof(incidentApplication));
            }

            this.Id = incidentApplication.Id;
            this.ApplicantId = incidentApplication.ApplicantId;
            this.ContentOfApplication = incidentApplication.ContentOfApplication;
            this.IncidentType = incidentApplication.IncidentType;
            this.SuspiciousEmployees = incidentApplication.SuspiciousEmployees;
            this.Attachments = incidentApplication.Attachments;
            this.PostDate = incidentApplication.PostDate;
            this.ApplicationState = incidentApplication.ApplicationState;
            this.ApplicationNumber = incidentApplication.ApplicationNumber;

            this.CopyDomainEvents(incidentApplication);
        }

        private IncidentApplication(
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments)
        {
            this.CheckRule(new IndicateAtLeastOneSuspectRule(suspiciousEmployees));
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ApplicantId = applicantId ?? throw new ArgumentNullException(nameof(applicantId));
            this.ContentOfApplication =
                contentOfApplication ?? throw new ArgumentNullException(nameof(contentOfApplication));
            this.IncidentType = incidentType ?? throw new ArgumentNullException(nameof(incidentType));

            this.Id = new IncidentApplicationId(Guid.NewGuid());
            this.SuspiciousEmployees = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();
            this.ApplicationNumber = new ApplicationNumber(this.PostDate, this.IncidentType);
            this.ApplicationState = ApplicationStateValue.Created;
            this.Attachments = attachments ?? new List<Attachment>();
            this.PostDate = SystemClock.Now;

            this.AddDomainEvent(new ApplicationCreatedDomainEvent(this.Id, this.ApplicationNumber,
                this.ContentOfApplication, this.IncidentType, this.PostDate, this.ApplicantId, this.SuspiciousEmployees,
                this.Attachments));
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
