using SSO.Application.AcademicYear.Queries; 
using SSO.Application.Configuration.Queries;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.QueryHandlers
{
    public class GetAcademicYearQueryHandler : IQueryHandler<GetAcademicYearQuery, QueryResult>
    {
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetAcademicYearQueryHandler(IAcademicYearRepository academicYearRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _academicYearRepository = academicYearRepository;
        }


        public Task<QueryResult> Handle(GetAcademicYearQuery request,
               CancellationToken cancellationToken)
        {
            var applications = _academicYearRepository.AsQueryable().
                     Skip(request.Page).Take(request.Count).ToList().AsDtos();
            var count = _academicYearRepository.Count();
            return Task.FromResult(new QueryResult(applications, count));
        }



    }
}
