using System;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspectRule;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.FieldShouldBeFilled;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Domain.Users;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    public class PostedIncidentVerificationApplication : Entity, IAggregateRoot
    {
        public PostedApplicationId Id { get; private set; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public UserId ApplicantId { get; }
        public SuspiciousEmployees SuspiciousEmployees { get; }
        public IncidentVerificationApplicationAttachments IncidentVerificationApplicationAttachments { get; }

        public PostedIncidentVerificationApplication(
            ApplicationNumber applicationNumber,
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            UserId applicantId,
            SuspiciousEmployees suspiciousEmployees,
            IncidentVerificationApplicationAttachments incidentVerificationApplicationAttachments)
        {
            this.CheckRule(new IndicateAtLeastOneSuspectRule(suspiciousEmployees));
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));
            this.CheckRule(new FieldShouldBeFilledRule(contentOfApplication, nameof(this.ContentOfApplication)));
            this.CheckRule(new FieldShouldBeFilledRule(applicantId, nameof(this.ApplicantId)));
            this.CheckRule(new FieldShouldBeFilledRule(applicationNumber, nameof(this.ApplicationNumber)));

            this.Id = new PostedApplicationId(Guid.NewGuid());
            this.ContentOfApplication = contentOfApplication;
            this.IncidentType = incidentType;
            this.ApplicantId = applicantId;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.ApplicationNumber = applicationNumber;
            this.IncidentVerificationApplicationAttachments = incidentVerificationApplicationAttachments;
            this.PostDate = SystemClock.Now;

            this.AddDomainEvent(new PostedIncidentVerificationApplicationDomainEvent(this.Id, this.ApplicationNumber, this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees, this.IncidentVerificationApplicationAttachments, this.PostDate));
        }
    }
}
