using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Link
{
    public class ApplicationLinkMustNotContaintRegularExpressionRule : IBusinessRule
    {
        public string Message => " در لینک برنامه  نمی توان از کاراکترهای غیرمجاز استفاده کرد";
        public string ErrorCode => "regular_expression_in_application_link";
        public string ApplicationLink { get; private set; }

        public ApplicationLinkMustNotContaintRegularExpressionRule(string applicationLink)
        {
            ApplicationLink = applicationLink;
        }

        public bool IsBroken()
        {
            var invalidChars = "!@#$%^'[]<>";
            foreach (var ch in invalidChars)
                if (ApplicationLink.Contains(ch))
                    return true;
            return false;
        }
    }
}
