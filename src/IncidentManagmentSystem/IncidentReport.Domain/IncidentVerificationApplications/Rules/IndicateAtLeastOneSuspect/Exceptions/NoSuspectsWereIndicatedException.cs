using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect.Exceptions
{
    internal class NoSuspectsWereIndicatedException : BusinessRuleValidationException
    {
        private static readonly string _errorMessage = Resources.NoSuspectsWereIndicatedException;

        public NoSuspectsWereIndicatedException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
