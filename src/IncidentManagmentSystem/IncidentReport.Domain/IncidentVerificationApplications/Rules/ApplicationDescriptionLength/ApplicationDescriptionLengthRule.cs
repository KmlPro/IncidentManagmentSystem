using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength
{
    public class ApplicationDescriptionLengthRule : IBusinessRule
    {
        private readonly int _minLength = 10;
        private readonly int _maxLength = 1000;
        private string Description { get; }

        public ApplicationDescriptionLengthRule(string content)
        {
            this.Description = content;
        }

        public void CheckIsBroken()
        {
            if (string.IsNullOrEmpty(this.Description))
            {
                throw new ApplicationDescriptionCannotBeEmptyException(this);
            }
            else if (this.Description.Length < this._minLength)
            {
                throw new ApplicationDescriptionTooShortException(this, this._minLength);
            }
            else if (this.Description.Length >= this._maxLength)
            {
                throw new ApplicationDescriptionTooLongException(this, this._maxLength);
            }
        }
    }
}
