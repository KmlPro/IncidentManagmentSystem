using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleCannotBeEmptyException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicationTitleCannotBeEmptyException;

        public ApplicationTitleCannotBeEmptyException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
