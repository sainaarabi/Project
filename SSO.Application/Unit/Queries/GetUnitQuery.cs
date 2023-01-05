using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.Queries
{
    public class GetUnitQuery : QueryBase<QueryResult>
    {

        public GetUnitQuery(int page = 0, int count = 0) : base(page, count) { }
 
    }
}
