using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions
{
    internal class ApplicationDescriptionCannotBeEmptyException : BusinessRuleValidationException
    {
        private const string _errorMessage = "Description cannot be empty";
        public ApplicationDescriptionCannotBeEmptyException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
