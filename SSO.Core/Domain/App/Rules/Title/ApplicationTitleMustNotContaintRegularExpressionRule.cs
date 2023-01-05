using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Title
{
    public class ApplicationTitleMustNotContaintRegularExpressionRule : IBusinessRule
    {
        public string Message => " در این فیلد نمی توان از کاراکترهای غیرمجاز استفاده کرد";
        public string ErrorCode => "regular_expression_in_application_title";
        public string ApplicationTitle { get; private set; }

        public ApplicationTitleMustNotContaintRegularExpressionRule(string applicationTitle)
        {
            ApplicationTitle = applicationTitle;
        }

        public bool IsBroken()
        {
            var invalidChars = "!@#$%^'[]<>";
            foreach (var ch in invalidChars)
                if (ApplicationTitle.Contains(ch))
                    return true;
            return false;
        }
    }
}
