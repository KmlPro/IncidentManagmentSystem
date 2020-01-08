using BuildingBlocks.Domain.Interfaces;

namespace BuildingBlocks.Domain.Abstract
{
    public abstract class WithCheckRule
    {
        protected void CheckRule(IBusinessRule rule)
        {
            rule.CheckIsBroken();
        }
    }
}
