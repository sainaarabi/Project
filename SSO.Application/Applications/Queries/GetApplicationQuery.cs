using SSO.Application.Configuration.Queries;

namespace SSO.Application.Applications.Queries
{
    public class GetApplicationQuery : QueryBase<QueryResult>
    {


        public GetApplicationQuery(int page = 0, int count = 0) : base(page, count)
        {
        }



    }
}





 