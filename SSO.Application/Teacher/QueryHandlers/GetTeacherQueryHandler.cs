using SSO.Application.Configuration.Queries;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.QueryHandlers
{
    public class GetTeacherQueryHandler : IQueryHandler<GetTeacherQuery, QueryResult>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetTeacherQueryHandler(ITeacherRepository repository)
        {
            _teacherRepository = repository;
        }


        public Task<QueryResult> Handle(GetTeacherQuery request,
               CancellationToken cancellationToken)
        {
            var applications = _teacherRepository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsDtos();
            var count = _teacherRepository.Count();
            return Task.FromResult(new QueryResult(applications, count));
        }



    }
}
