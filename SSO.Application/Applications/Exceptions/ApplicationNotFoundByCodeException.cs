using SSO.Common.Exceptions;

namespace SSO.Application.Applications.Exceptions
{
    public class ApplicationNotFoundByCodeException : AppException
    {
        public ApplicationNotFoundByCodeException(string code) :
            base(Common.AppExceptionBaseType.NotFound,
                $"  کد برنامه نامعتبر است", "application_not_found")
        {

        }
    }
}
