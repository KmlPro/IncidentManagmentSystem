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

namespace IncidentReport.Domain.IncidentVerificationApplications.Applications
{
    public class Application : Entity, IAggregateRoot
    {
        public static CreatedApplication Create(ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments)
        {
            var application = new Application(contentOfApplication, incidentType, applicantId, suspiciousEmployees, attachments);
            return new CreatedApplication(application);
        }

        public Application(Application application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }

            this.Id = application.Id;
            this.ApplicantId = application.ApplicantId;
            this.ContentOfApplication = application.ContentOfApplication;
            this.IncidentType = application.IncidentType;
            this.SuspiciousEmployees = application.SuspiciousEmployees;
            this.Attachments = application.Attachments;
            this.PostDate = application.PostDate;
            this.CopyDomainEvents(application);
        }

        private Application(
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

            this.Id = new PostedApplicationId(Guid.NewGuid());
            this.SuspiciousEmployees = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();
            this.ApplicationNumber = new ApplicationNumber(this.PostDate, this.IncidentType);
            this.ApplicationState = ApplicationStateValue.Created;
            this.Attachments = attachments ?? new List<Attachment>();
            this.PostDate = SystemClock.Now;

            this.AddDomainEvent(new ApplicationCreatedDomainEvent(this.Id, this.ApplicationNumber,
                this.ContentOfApplication, this.IncidentType, this.PostDate, this.ApplicantId, this.SuspiciousEmployees,
                this.Attachments));
        }

        public PostedApplicationId Id { get; }
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
    }
}
