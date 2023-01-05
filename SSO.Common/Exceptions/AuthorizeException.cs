using System;

namespace SSO.Common.Exceptions
{

    public class AuthorizeException : Exception
    {
        public virtual string Code { get; }
        public AppExceptionBaseType ExceptionBaseType { get; }

        protected AuthorizeException(AppExceptionBaseType appExceptionBaseType, string message = "",
            string code = "") : base(message)
        {
            Code = code;
            ExceptionBaseType = appExceptionBaseType;
        }
    }

}
