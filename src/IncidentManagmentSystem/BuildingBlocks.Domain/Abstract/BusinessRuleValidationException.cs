using System;
using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class BusinessRuleValidationException : Exception
    {
        private IBusinessRule BrokenRule { get; }
        private string Details { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule, string message) : base(message)
        {
            this.BrokenRule = brokenRule;
            this.Details = message;
        }

        public override string ToString()
        {
            return $"{this.BrokenRule.GetType().FullName}: {this.Details}";
        }
    }
}
