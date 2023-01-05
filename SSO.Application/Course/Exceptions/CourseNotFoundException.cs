using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.Exceptions
{
    public class CourseNotFoundException : AppException
    {
        public CourseNotFoundException(int id) :
            base(Common.AppExceptionBaseType.NotFound,
                $"  درسی  با شناسه {id} وجود ندارد", "course_not_found")
        {

        }
    }
}
