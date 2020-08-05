using IncidentReport.Domain.IncidentVerificationApplications.Events.Applications;

namespace IncidentReport.Domain.IncidentVerificationApplications.Applications.States
{
    public class PostedApplication : Application
    {
        public PostedApplication(Application application) : base(application)
        {
            this.AddDomainEvent(new ApplicationPostedDomainEvent(this.Id, this.ApplicationNumber, this.ContentOfApplication,
                this.IncidentType, this.PostDate, this.ApplicantId, this.SuspiciousEmployees, this.Attachments));
        }
    }
}
