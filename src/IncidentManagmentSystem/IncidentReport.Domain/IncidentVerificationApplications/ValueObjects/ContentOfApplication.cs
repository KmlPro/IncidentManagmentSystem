using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ContentOfApplication : ValueObject
    {
        public string Title { get; }
        public string Description { get; }

        public ContentOfApplication(string title, string description)
        {
            this.CheckRule(new ApplicationDescriptionLengthRule(title));
            this.CheckRule(new ApplicationDescriptionLengthRule(description));

            this.Title = title;
            this.Description = description;
        }
    }
}
