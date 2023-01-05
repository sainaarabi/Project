using SSO.Common.Exceptions;

namespace SSO.Application.Customers.Exceptions
{
    public class ApplicationNotFoundException : AppException
    {
        public ApplicationNotFoundException(long applicatioId) :
            base(Common.AppExceptionBaseType.NotFound,
                $"برنامه با شناسه {applicatioId} وجود ندارد", "applicatio_not_found")
        {

        }
    }
}
