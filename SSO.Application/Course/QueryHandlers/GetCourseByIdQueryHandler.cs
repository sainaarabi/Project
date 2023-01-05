using SSO.Application.Configuration.Queries;
using SSO.Application.Course.Exceptions;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.QueryHandlers
{
    public class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, QueryResult>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdQueryHandler(ICourseRepository repository)
        {
            _courseRepository = repository;
        }

        public async Task<QueryResult> Handle(GetCourseByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _courseRepository.GetAsync(request.Id);
            if (result == null)
                throw new CourseNotFoundException(request.Id);
            return new QueryResult(result.AsDto());
        }
    }
}
