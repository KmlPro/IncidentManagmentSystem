using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect.Exceptions
{
    internal class NoSuspectsWereIndicatedException : BusinessRuleValidationException
    {
        private const string _errorMessage = "No suspects were indicated";

        public NoSuspectsWereIndicatedException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
