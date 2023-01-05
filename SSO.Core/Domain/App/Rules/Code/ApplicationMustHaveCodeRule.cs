using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Code
{
    public class ApplicationMustHaveCodeRule : IBusinessRule
    {
        public string Message => "برنامه باید دارای کد باشد";
        public string ErrorCode => "application_code_required";
        public string ApplicationCode { get; private set; }

        public ApplicationMustHaveCodeRule(string applicationCode)
        {
            ApplicationCode = applicationCode;
        }
        public bool IsBroken() => string.IsNullOrEmpty(ApplicationCode) || string.IsNullOrWhiteSpace(ApplicationCode);
    }
}
