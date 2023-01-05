using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.Queries
{
    public class GetTimeSchedulByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetTimeSchedulByIdQuery(int id)
        {
            Id = id;
        }
    }
}
