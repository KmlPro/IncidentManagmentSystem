using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ContentOfApplication : ValueObject
    {
        public string Title { get; }
        public string Content { get; }

        public static ContentOfApplication Create(string title, string content)
        {
            return new ContentOfApplication(title, content);
        }
        // kbytner 13.01 - TO DO - changes in exceptions (title in exception)
        private ContentOfApplication(string title, string content)
        {
            this.CheckRule(new ApplicationContentLenghtRule(this.Title));
            this.CheckRule(new ApplicationContentLenghtRule(this.Content));

            this.Title = title;
            this.Content = content;
        }
    }
}
