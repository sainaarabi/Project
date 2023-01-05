using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.Exceptions
{
    public class TimeSchedulNotFoundException : AppException
    {
        public TimeSchedulNotFoundException(int id) :
            base(Common.AppExceptionBaseType.NotFound,
                $"   زمانی  با شناسه {id} وجود ندارد", "TimeSchedul_not_found")
        {

        }
    }
}
