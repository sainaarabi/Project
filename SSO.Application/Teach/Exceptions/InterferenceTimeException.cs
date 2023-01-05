using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Exceptions
{
    internal class InterferenceTimeException : AppException
    {
        public InterferenceTimeException() :
            base(Common.AppExceptionBaseType.NotFound,
                $"  به دلیل تداخل زمانی امکان پذیر نیست", "Interference-Time")
        {

        }

    }
}