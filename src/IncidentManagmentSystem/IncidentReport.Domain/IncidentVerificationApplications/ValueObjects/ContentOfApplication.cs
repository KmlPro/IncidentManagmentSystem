using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ContentOfApplication : ValueObject
    {
        public string Title { get; }
        public string Description { get; }

        private ContentOfApplication()
        {

        }

        public ContentOfApplication(string title, string description)
        {
            this.CheckRule(new ApplicationTitleLenghtRule(title));
            this.CheckRule(new ApplicationDescriptionLengthRule(description));

            this.Title = title;
            this.Description = description;
        }
    }
}
