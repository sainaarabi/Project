using SSO.Application.AcademicYear.Exceptions;
using SSO.Application.AcademicYear.Queries;
using SSO.Application.Configuration.Queries;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Teacher.Queries;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.QueryHandlers
{
    public class GetAcademicYearByIdQueryHandler : IQueryHandler<GetAcademicYearByIdQuery, QueryResult>
    {
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetAcademicYearByIdQueryHandler(IAcademicYearRepository academicYearRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _academicYearRepository = academicYearRepository;
        }

        public async Task<QueryResult> Handle(GetAcademicYearByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _academicYearRepository.GetAsync(request.Id);
            if (result == null)
                throw new AcademicYearNotFoundException(request.Id);
            return new QueryResult(result.AsDto());
        }
    }
}
