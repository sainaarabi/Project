using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Title
{
    public class ApplicationMustHaveTitleRule : IBusinessRule
    {
        public string Message => "برنامه باید دارای عنوان باشد";
        public string ErrorCode => "application_title_required";
        public string ApplicationTitle { get; private set; }

        public ApplicationMustHaveTitleRule(string applicationTitle)
        {
            ApplicationTitle = applicationTitle;
        }
        public bool IsBroken() => string.IsNullOrEmpty(ApplicationTitle) || string.IsNullOrWhiteSpace(ApplicationTitle);
    }
}
