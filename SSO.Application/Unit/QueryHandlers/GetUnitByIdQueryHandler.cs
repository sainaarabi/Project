using SSO.Application.Configuration.Queries;
using SSO.Application.Course.Exceptions;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Teacher.Queries;
using SSO.Application.Unit.Exceptions;
using SSO.Application.Unit.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.QueryHandlers
{
    public class GetUnitByIdQueryHandler : IQueryHandler<GetUnitByIdQuery, QueryResult>
    {
        private readonly IUnitRepository _unitRepository;

        public GetUnitByIdQueryHandler(IUnitRepository repository)
        {
            _unitRepository = repository;
        }

        public async Task<QueryResult> Handle(GetUnitByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitRepository.GetAsync(request.Id);
            if (result == null)
                throw new UnitNotFoundException(request.Id);
            return new QueryResult(result.AsDto());
        }
    }
}
