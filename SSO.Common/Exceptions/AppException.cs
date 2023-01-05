using System;

namespace SSO.Common.Exceptions
{
    public class AppException : Exception
    {
        public virtual string Code { get; }

        public AppExceptionBaseType ExceptionBaseType { get; }

        protected AppException(AppExceptionBaseType appExceptionBaseType, string message = "",
            string code = "") : base(message)
        {
            Code = code;
            ExceptionBaseType = appExceptionBaseType;
        }
    }
   
}
