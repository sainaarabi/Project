 using SSO.Application.Configuration.Queries;
using SSO.Application.Teach.Queries;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.QueryHandlers
{
    public class GetTeachQueryHandler : IQueryHandler<GetTeachQuery, QueryResult>
    {
        private readonly ITeachRepository _teachRepository;

        public GetTeachQueryHandler(ITeachRepository repository)
        {
            _teachRepository = repository;
        }


        public Task<QueryResult> Handle(GetTeachQuery request,
               CancellationToken cancellationToken)
        {
            var applications = _teachRepository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsDtos();
            var count = _teachRepository.Count();
            return Task.FromResult(new QueryResult(applications, count));
        }



    }
}
