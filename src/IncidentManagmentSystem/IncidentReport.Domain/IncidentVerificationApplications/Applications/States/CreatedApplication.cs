using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Applications.States
{
    public class CreatedApplication : Application
    {
        public CreatedApplication(Application application) : base(application)
        {
        }

        public PostedApplication Post()
        {
            this.SetState(ApplicationStateValue.Posted);
            return new PostedApplication(this);
        }
    }
}
