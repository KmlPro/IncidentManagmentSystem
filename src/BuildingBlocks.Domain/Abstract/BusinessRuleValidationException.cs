using System;
using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(IBusinessRule brokenRule, string message) : base(message)
        {
            this.BrokenRule = brokenRule;
            this.Details = message;
        }

        public IBusinessRule BrokenRule { get; }
        private string Details { get; }

        public override string ToString()
        {
            return $"{this.BrokenRule.GetType().FullName}: {this.Details}";
        }
    }
}
