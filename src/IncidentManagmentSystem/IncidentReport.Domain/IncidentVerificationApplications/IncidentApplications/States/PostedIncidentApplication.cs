using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;

namespace IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications.States
{
    public class PostedIncidentApplication : IncidentApplication
    {
        public PostedIncidentApplication(IncidentApplication incidentApplication) : base(incidentApplication)
        {
            this.AddDomainEvent(new ApplicationPostedDomainEvent(this.Id, this.ApplicationNumber, this.ContentOfApplication,
                this.IncidentType, this.PostDate, this.ApplicantId, this.SuspiciousEmployees, this.Attachments));
        }
    }
}
