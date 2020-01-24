using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength.Exceptions
{
    internal class ApplicationContentCannotBeEmptyException : BusinessRuleValidationException
    {
        private const string _errorMessage = "Content cannot be empty";
        public ApplicationContentCannotBeEmptyException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
