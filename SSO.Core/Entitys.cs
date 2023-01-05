using SSO.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Core
{
    public abstract class Entitys  
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
