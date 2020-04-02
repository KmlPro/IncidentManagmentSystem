using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class ContentOfApplicationBuilder
    {
        private string _title;
        private string _description;

        public ContentOfApplicationBuilder SetTitle(string title)
        {
            this._title = title;
            return this;
        }

        public ContentOfApplicationBuilder SetDescription(string description)
        {
            this._description = description;
            return this;
        }

        public ContentOfApplication Build()
        {
            return new ContentOfApplication(this._title, this._description);
        }
    }
}
