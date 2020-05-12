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
            this.CheckRule(new ApplicationTitleLenghtRule(title)); //12.05.2020 - remove overkill :) remove checkrule from value objects!
            this.CheckRule(new ApplicationDescriptionLengthRule(description)); //12.05.2020 - remove overkill :) overkill

            this.Title = title;
            this.Description = description;
        }
    }
}
