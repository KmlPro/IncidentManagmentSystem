using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleCannotBeEmptyException : BusinessRuleValidationException
    {
        private const string _errorMessage = "Description cannot be empty";

        public ApplicationTitleCannotBeEmptyException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
