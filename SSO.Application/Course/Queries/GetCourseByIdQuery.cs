using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.Queries
{
    public class GetCourseByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
