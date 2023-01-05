using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.Exceptions
{
    public class AcademicYearNotFoundException : AppException
    {
        public AcademicYearNotFoundException(int id) :
            base(Common.AppExceptionBaseType.NotFound,
                $"  سالی با شناسه {id} وجود ندارد", "AcademicYear_not_found")
        {

        }
    }
}
