using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Exceptions
{
    public class TeachNotFoundException : AppException
    {
        public TeachNotFoundException(int id) :
            base(Common.AppExceptionBaseType.NotFound,
                $"  انتخابی با شناسه {id} وجود ندارد", "teach_not_found")
        {

        }
    }
}
