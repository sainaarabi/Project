 using SSO.Application.Configuration.Queries;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Queries;
using SSO.Application.Unit.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.QueryHandlers
{
    public class GetUnitQueryHandler : IQueryHandler<GetUnitQuery, QueryResult>
    {
        private readonly IUnitRepository _unitRepository;

        public GetUnitQueryHandler(IUnitRepository repository)
        {
            _unitRepository = repository;
        }


        public Task<QueryResult> Handle(GetUnitQuery request,
               CancellationToken cancellationToken)
        {
            var  courses = _unitRepository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsDtos();
            var count = _unitRepository.Count();
            return Task.FromResult(new QueryResult(courses, count));
        }



    }
}
