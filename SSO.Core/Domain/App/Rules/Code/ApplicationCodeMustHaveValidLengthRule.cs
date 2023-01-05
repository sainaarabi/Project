using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Code
{
    public class ApplicationCodeMustHaveValidLengthRule : IBusinessRule
    {
        public string ApplicationCode { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public string Message => $"طول کد برنامه باید بین {MinLength} تا {MaxLength} باشد";
        public string ErrorCode => "invalid_application_code_lenght";

        public ApplicationCodeMustHaveValidLengthRule(string applicationCode,
            int minLength = 0,
            int maxLength = 100)
        {
            ApplicationCode = applicationCode;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        public bool IsBroken()
        {
            return !(ApplicationCode.Length >= MinLength && ApplicationCode.Length <= MaxLength);
        }
    }
}
