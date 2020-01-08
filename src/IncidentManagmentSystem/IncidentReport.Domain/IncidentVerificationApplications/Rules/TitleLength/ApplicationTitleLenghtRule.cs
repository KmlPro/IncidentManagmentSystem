using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.TitleLength.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.TitleLength
{
    internal class ApplicationTitleLenghtRule : IBusinessRule
    {
        private readonly int _minLength = 10;
        private readonly int _maxLength = 100;
        private string Title { get; }

        public ApplicationTitleLenghtRule(string title)
        {
            this.Title = title;
        }

        public void CheckIsBroken()
        {
            if (string.IsNullOrEmpty(this.Title))
            {
                throw new ApplicationTitleCannotBeEmptyException(this, "Title can not be empty");
            }
            else if (this.Title.Length < this._minLength)
            {
                throw new ApplicationTitleTooShortException(this, $"The Title should contain a minimum of {this._minLength} characters");
            }
            else if (this.Title.Length >= this._maxLength)
            {
                throw new ApplicationTitleTooLongException(this, $"The Title should contain a minimum of {this._maxLength} characters");
            }
        }
    }
}
