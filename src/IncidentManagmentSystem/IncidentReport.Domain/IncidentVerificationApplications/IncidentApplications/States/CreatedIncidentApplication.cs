using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.IncidentVerificationApplications.Applications.States
{
    public class CreatedIncidentApplication : IncidentApplication
    {
        public CreatedIncidentApplication(IncidentApplication incidentApplication) : base(incidentApplication)
        {
        }

        public PostedIncidentApplication Post()
        {
            this.SetState(ApplicationStateValue.Posted);
            return new PostedIncidentApplication(this);
        }
    }
}
