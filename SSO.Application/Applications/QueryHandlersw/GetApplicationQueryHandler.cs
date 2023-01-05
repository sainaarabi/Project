using SSO.Application.Applications.Queries;
using SSO.Application.Configuration.Queries;
using SSO.Core.Repositories;

namespace SSO.Application.Applications.QueryHandlers
{
    public class GetApplicationQueryHandler : IQueryHandler<GetApplicationQuery, QueryResult>
    {
        private readonly IApplicationRepository _repository; 

        public GetApplicationQueryHandler(IApplicationRepository repository )
        {
            _repository = repository; 
        }


        public Task<QueryResult> Handle(GetApplicationQuery request,
               CancellationToken cancellationToken)
        {
            var applications = _repository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsAppDtos()  ; 
            var count = _repository.Count();
            return Task.FromResult(new QueryResult(applications ,  count));
        }



    }
}

 