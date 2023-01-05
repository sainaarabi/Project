using SSO.Common.Exceptions;

namespace SSO.Application.Applications.Exceptions
{
    public class ApplicationHasApplicationModuleException : AppException
    {
        public ApplicationHasApplicationModuleException( ) :
            base(Common.AppExceptionBaseType.NotFound,
                $"به دلیل داشتن ماژول قادر به حذف برنامه نیستید", "Application-Has-ApplicationModule-Exception")
        {

        }
    }
}
