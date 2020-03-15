using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using BuildingBlocks.Domain.SharedRules.FieldShouldBeFilled;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class PostedApplication : Entity, IAggregateRoot
    {
        public PostedApplicationId Id { get; private set; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public IncidentVerificationApplicationAttachments IncidentVerificationApplicationAttachments { get; }

        private PostedApplication()
        {

        }

        public PostedApplication(
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            SuspiciousEmployees suspiciousEmployees,
            IncidentVerificationApplicationAttachments incidentVerificationApplicationAttachments)
        {
            this.CheckRule(new IndicateAtLeastOneSuspectRule(suspiciousEmployees));
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));
            this.CheckRule(new FieldShouldBeFilledRule(contentOfApplication, nameof(this.ContentOfApplication)));
            this.CheckRule(new FieldShouldBeFilledRule(applicantId, nameof(this.ApplicantId)));

            this.Id = new PostedApplicationId(Guid.NewGuid());
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.IncidentVerificationApplicationAttachments = incidentVerificationApplicationAttachments;
            this.PostDate = SystemClock.Now;
            this.ApplicationNumber = new ApplicationNumber(this.PostDate, this.IncidentType);

            this.AddDomainEvent(new PostedApplicationDomainEvent(this.Id, this.ApplicationNumber, this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments, this.PostDate));
        }
    }
}
