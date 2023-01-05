using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Queries
{
    public class GetTeachQuery : QueryBase<QueryResult>
    {

        public GetTeachQuery(int page = 0, int count = 0) : base(page, count) { }
 
    }
}
