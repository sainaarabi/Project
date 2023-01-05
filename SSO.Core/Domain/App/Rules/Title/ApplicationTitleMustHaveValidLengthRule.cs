using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Title
{
    public class ApplicationTitleMustHaveValidLengthRule : IBusinessRule
    {
        public string ApplicationTitle { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public string Message => $"طول عنوان برنامه باید بین {MinLength} تا {MaxLength} باشد";
        public string ErrorCode => "invalid_application_title_lenght";

        public ApplicationTitleMustHaveValidLengthRule(string applicationTitle,
            int minLength = 5,
            int maxLength = 100)
        {
            ApplicationTitle = applicationTitle;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        public bool IsBroken()
        {
            return !(ApplicationTitle.Length >= MinLength && ApplicationTitle.Length <= MaxLength);
        }
    }
}
