using SSO.Application.Configuration.Queries;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.QueryHandlers
{
    public class GetCourseQueryHandler : IQueryHandler<GetCourseQuery, QueryResult>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseQueryHandler(ICourseRepository repository)
        {
            _courseRepository = repository;
        }


        public Task<QueryResult> Handle(GetCourseQuery request,
               CancellationToken cancellationToken)
        {
            var  courses = _courseRepository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsDtos();
            var count = _courseRepository.Count();
            return Task.FromResult(new QueryResult(courses, count));
        }



    }
}
