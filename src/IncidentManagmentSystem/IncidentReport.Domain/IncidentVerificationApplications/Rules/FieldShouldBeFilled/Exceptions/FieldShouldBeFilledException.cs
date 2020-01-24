using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.FieldShouldBeFilled.Exceptions
{
    internal class FieldShouldBeFilledException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The field {0} cannot be null or empty";

        public FieldShouldBeFilledException(IBusinessRule brokenRule, string fieldName) : base(brokenRule, string.Format(_errorMessage, fieldName))
        {
        }
    }
}
