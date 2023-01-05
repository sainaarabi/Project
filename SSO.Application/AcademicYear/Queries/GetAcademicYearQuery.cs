using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.Queries
{
    public class GetAcademicYearQuery : QueryBase<QueryResult>
    {

        public GetAcademicYearQuery(int page = 0, int count = 0) : base(page, count) { }
 
    }
}
