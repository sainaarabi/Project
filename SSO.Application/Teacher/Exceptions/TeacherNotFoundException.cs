using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.Exceptions
{
    public class TeacherNotFoundException : AppException
    {
        public TeacherNotFoundException(int id) :
            base(Common.AppExceptionBaseType.NotFound,
                $" استادی با شناسه {id} وجود ندارد", "teacher_not_found")
        {

        }
    }
}
