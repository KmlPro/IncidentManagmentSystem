using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions
{
    internal class ApplicationDescriptionTooShortException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicationDescriptionTooShortException;

        public ApplicationDescriptionTooShortException(IBusinessRule brokenRule, int minLength) : base(brokenRule, string.Format( _errorMessage, minLength))
        {
        }
    }
}
