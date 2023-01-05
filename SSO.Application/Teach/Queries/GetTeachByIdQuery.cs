using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Queries
{
    public class GetTeachByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetTeachByIdQuery(int id)
        {
            Id = id;
        }
    }
}
