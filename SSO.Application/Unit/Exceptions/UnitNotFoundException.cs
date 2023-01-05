using SSO.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.Exceptions
{
    public class UnitNotFoundException : AppException
    {
        public UnitNotFoundException(int id) :
            base(Common.AppExceptionBaseType.NotFound,
                $"   واحدی  با شناسه {id} وجود ندارد", "Unit_not_found")
        {

        }
    }
}
