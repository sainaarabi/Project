using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.Queries
{
    public class GetAcademicYearByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetAcademicYearByIdQuery(int id)
        {
            Id = id;
        }
    }
}
