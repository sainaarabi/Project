using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.Queries
{
    public class GetUnitByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetUnitByIdQuery(int id)
        {
            Id = id;
        }
    }
}
