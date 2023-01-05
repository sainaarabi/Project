 
using SSO.Application.Teacher.DTO; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teachers = SSO.Core.Domain.Teacher.Teacher;
namespace SSO.Application.Teacher
{
    public static class Extensions
    {


        public static teachers AsEntity(this TeacherDto appDto)
    => new teachers();
        public static TeacherDto AsDto(this teachers app)
            => app == null ? null : new TeacherDto()
            {
                ID = app.ID,
                FirstName = app.FirstName,
                LastName = app.LastName,

            };


        public static List<TeacherDto> AsDtos(this List<teachers> applications)
           => applications.Select(AsDto).ToList(); 
    }
}
