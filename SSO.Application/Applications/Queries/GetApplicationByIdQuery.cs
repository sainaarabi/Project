using SSO.Application.Configuration.Queries;

namespace SSO.Application.Applications.Queries
{
    public class GetApplicationByIdQuery : QueryBase<QueryResult>
    {

        public int Id { get; private set; }

        public GetApplicationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
