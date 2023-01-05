using SSO.Application.Course.DTO;
using SSO.Application.Teacher.DTO;
using SSO.Application.Unit.DTO; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Units = SSO.Core.Domain.Unit.Unit;
namespace SSO.Application.Unit
{
    public static class Extensions
    {


        public static Units AsEntity(this UnitDto appDto)
    => new Units();
        public static UnitDto AsDto(this Units app)
            => app == null ? null : new UnitDto()
            {
                ID = app.ID,
                CourseID = app.CourseID,
                AcademicYearID = app.AcademicYearID,
                TimeScheduleID = app.TimeScheduleID

            };


        public static List<UnitDto> AsDtos(this List<Units> applications)
           => applications.Select(AsDto).ToList(); 
    }
}
