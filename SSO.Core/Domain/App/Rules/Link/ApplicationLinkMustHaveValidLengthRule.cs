using SSO.Core.Definitions;

namespace SSO.Core.Domain.Applications.Rules.Link
{
    public class ApplicationLinkMustHaveValidLengthRule : IBusinessRule
    {
        public string ApplicationLink { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        public string Message => $"طول آدرس برنامه باید بین {MinLength} تا {MaxLength} باشد";
        public string ErrorCode => "invalid_application_link_lenght";

        public ApplicationLinkMustHaveValidLengthRule(string applicationLink,
            int minLength = 0,
            int maxLength = 50)
        {
            ApplicationLink = applicationLink;
            MinLength = minLength;
            MaxLength = maxLength;
        }

        public bool IsBroken()
        {
            return !(ApplicationLink.Length >= MinLength && ApplicationLink.Length <= MaxLength);
        }
    } 
} 
