using SSO.Application.Configuration.Queries;
using SSO.Application.Course.Exceptions;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Teacher.Queries;
using SSO.Application.TimeSchedul.Exceptions;
using SSO.Application.TimeSchedul.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.QueryHandlers
{
    public class GetTimeSchedulByIdQueryHandler : IQueryHandler<GetTimeSchedulByIdQuery, QueryResult>
    {
        private readonly ITimeSchedulRepository _timeSchedulRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetTimeSchedulByIdQueryHandler(ITimeSchedulRepository timeSchedulRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _timeSchedulRepository = timeSchedulRepository;
        }

        public async Task<QueryResult> Handle(GetTimeSchedulByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _timeSchedulRepository.GetAsync(request.Id);
            if (result == null)
                throw new TimeSchedulNotFoundException(request.Id);
            return new QueryResult(result.AsDto());
        }
    }
}
