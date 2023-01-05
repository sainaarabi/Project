using SSO.Application.Configuration.Queries;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Queries;
using SSO.Application.TimeSchedul.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.QueryHandlers
{
    public class GetTimeSchedulQueryHandler : IQueryHandler<GetTimeSchedulQuery, QueryResult>
    {
        private readonly ITimeSchedulRepository _timeSchedulRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetTimeSchedulQueryHandler(ITimeSchedulRepository timeSchedulRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _timeSchedulRepository = timeSchedulRepository;
        }


        public Task<QueryResult> Handle(GetTimeSchedulQuery request,
               CancellationToken cancellationToken)
        {
            var TimeSchedul = _timeSchedulRepository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsDtos();
            var count = _timeSchedulRepository.Count();
            return Task.FromResult(new QueryResult(TimeSchedul, count));
        }



    }
}
