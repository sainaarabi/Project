using SSO.Application.Configuration.Queries;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.QueryHandlers
{
    public class GetTeacherByIdQueryHandler : IQueryHandler<GetTeacherByIdQuery, QueryResult>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherByIdQueryHandler(ITeacherRepository repositoy)
        {
            _teacherRepository = repositoy;
        }
        public async Task<QueryResult> Handle(GetTeacherByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _teacherRepository.GetAsync(request.Id);
            if (result == null)
                throw new TeacherNotFoundException(request.Id);
            return new QueryResult(result.AsDto());
        }
    }
}
