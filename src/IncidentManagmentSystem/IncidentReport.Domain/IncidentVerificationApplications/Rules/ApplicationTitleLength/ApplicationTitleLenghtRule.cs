using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength
{
    public class ApplicationTitleLenghtRule : IBusinessRule
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
                throw new ApplicationTitleCannotBeEmptyException(this);
            }
            else if (this.Title.Length < this._minLength)
            {
                throw new ApplicationTitleTooShortException(this, this._minLength);
            }
            else if (this.Title.Length >= this._maxLength)
            {
                throw new ApplicationTitleTooLongException(this, this._maxLength);
            }
        }
    }
}
