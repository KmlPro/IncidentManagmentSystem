using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions
{
    internal class ApplicationDescriptionCannotBeEmptyException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicationDescriptionCannotBeEmptyException;

        public ApplicationDescriptionCannotBeEmptyException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
