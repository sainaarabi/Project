using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Code
{
    public class ApplicationCodeMustNotContaintRegularExpressionRule : IBusinessRule
    {
        public string Message => " در کد برنامه  نمی توان از کاراکترهای غیرمجاز استفاده کرد";
        public string ErrorCode => "regular_expression_in_application_code";
        public string ApplicationCode { get; private set; }

        public ApplicationCodeMustNotContaintRegularExpressionRule(string applicationCode)
        {
            ApplicationCode = applicationCode;
        }

        public bool IsBroken()
        {
            var invalidChars = "!@#$%^'[]<>";
            foreach (var ch in invalidChars)
                if (ApplicationCode.Contains(ch))
                    return true;
            return false;
        }
    }
}
