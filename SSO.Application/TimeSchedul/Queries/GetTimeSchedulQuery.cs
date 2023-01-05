using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.Queries
{
    public class GetTimeSchedulQuery : QueryBase<QueryResult>
    {

        public GetTimeSchedulQuery(int page = 0, int count = 0) : base(page, count) { }
 
    }
}
