using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ContentOfApplication : ValueObject
    {
        public string Title { get; }
        public string Content { get; }

        public ContentOfApplication(string title, string content)
        {
            this.CheckRule(new ApplicationContentLenghtRule(this.Title));
            this.CheckRule(new ApplicationContentLenghtRule(this.Content));

            this.Title = title;
            this.Content = content;
        }
    }
}
