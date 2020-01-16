using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength
{
    internal class ApplicationContentLenghtRule : IBusinessRule
    {
        private readonly int _minLength = 10;
        private readonly int _maxLength = 1000;
        private string Content { get; }

        public ApplicationContentLenghtRule(string content)
        {
            this.Content = content;
        }

        public void CheckIsBroken()
        {
            if (string.IsNullOrEmpty(this.Content))
            {
                throw new ApplicationContentCannotBeEmptyException(this, "Content cannot be empty");
            }
            else if (this.Content.Length < this._minLength)
            {
                throw new ApplicationContentTooShortException(this, $"The Content should contain a minimum of {this._minLength} characters");
            }
            else if (this.Content.Length >= this._maxLength)
            {
                throw new ApplicationContentTooLongException(this, $"The Content should contain a minimum of {this._maxLength} characters");
            }
        }
    }
}
