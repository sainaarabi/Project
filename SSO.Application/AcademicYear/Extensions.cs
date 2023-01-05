using SSO.Application.AcademicYear.DTO; 
using SSO.Application.Teacher.DTO; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcademicYears = SSO.Core.Domain.AcademicYear.AcademicYear;
namespace SSO.Application.AcademicYear
{
    public static class Extensions
    {


        public static AcademicYears AsEntity(this AcademicYearDto appDto)
    => new AcademicYears();
        public static AcademicYearDto AsDto(this AcademicYears app)
            => app == null ? null : new AcademicYearDto()
            {
                ID = app.ID,
                Date = app.Date ,

            };


        public static List<AcademicYearDto> AsDtos(this List<AcademicYears> applications)
           => applications.Select(AsDto).ToList(); 
    }
}
