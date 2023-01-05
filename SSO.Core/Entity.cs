using SSO.Core.Definitions;

namespace SSO.Core
{
    public abstract class Entity : Document
    {
        protected virtual void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
