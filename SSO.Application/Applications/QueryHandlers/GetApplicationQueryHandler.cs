//using SSO.Application.Applications.Queries;
//using SSO.Application.Configuration.Queries;
//using SSO.Core.Repositories;

//namespace SSO.Application.Applications.QueryHandlers
//{
//    public class GetApplicationQueryHandler : IQueryHandler<GetApplicationQuery, QueryResult>
//    {
//        private readonly IApplicationRepository _applicationRepository;
//        public GetApplicationQueryHandler(IApplicationRepository applicationRepository)
//        {
//            _applicationRepository = applicationRepository;
//        }
//        public async Task<QueryResult> Handle(GetApplicationQuery request,
//        CancellationToken cancellationToken)
//        {
//            var AppData = _applicationRepository.Get(code: request.Code, page: request.Page, count: request.Count);
//            return new QueryResult(AppData.Item1);
//        }
//    }
//}
