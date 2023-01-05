using SSO.Application.Configuration.Queries;
using SSO.Application.Teach.Exceptions;
using SSO.Application.Teach.Queries;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.QueryHandlers
{
    public class GetTeachByIdQueryHandler : IQueryHandler<GetTeachByIdQuery, QueryResult>
    {
        private readonly ITeachRepository _teachRepository;
        public GetTeachByIdQueryHandler(ITeachRepository repositoy)
        {
            _teachRepository = repositoy;
        }
        public async Task<QueryResult> Handle(GetTeachByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _teachRepository.GetAsync(request.Id);
            if (result == null)
                throw new TeachNotFoundException(request.Id);
            return new QueryResult(result.AsDto());
        }
    }
}
