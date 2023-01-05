using SSO.Application.Configuration.Queries;
using SSO.Application.Teach.Exceptions;
using SSO.Application.Teach.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using units = SSO.Core.Domain.Unit.Unit;
namespace SSO.Application.Teach.QueryHandlers
{
    public class GetClassTimingQueryHandler : IQueryHandler<GetClassTimingQuery, QueryResult>
    {
        private readonly ITeachRepository _teachRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;
        public GetClassTimingQueryHandler(ITeachRepository teachRepository,
        IUnitOfWork unitOfWork,
        IUnitRepository unitRepository)
        {
            _unitOfWork = unitOfWork;
            _teachRepository = teachRepository;
            _unitRepository = unitRepository;
        }
        public async Task<QueryResult> Handle(GetClassTimingQuery request,
            CancellationToken cancellationToken)
        {
            //IQueryable<units> course = await _unitRepository.Get(request.CourseId);
            //IQueryable<units> te = _unitRepository.FilterBy(x => x.CourseID != course.COU && x.Unit.TimeScheduleID == unit.TimeScheduleID).ToList();
            var result = await _teachRepository.GetAsync(request.TeacherId);
 
            return new QueryResult(result.AsDto());
        }
    }
}
