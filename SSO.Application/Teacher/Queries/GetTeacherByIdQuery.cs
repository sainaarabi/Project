using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.Queries
{
    public class GetTeacherByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetTeacherByIdQuery(int id)
        {
            Id = id;
        }
    }
}
