 
using SSO.Application.Course.DTO;
using SSO.Application.Teacher.DTO; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using courses = SSO.Core.Domain.Course.Course;
namespace SSO.Application.Course
{
    public static class Extensions
    {


        public static courses AsEntity(this CourseDto appDto)
    => new courses();
        public static CourseDto AsDto(this courses app)
            => app == null ? null : new CourseDto()
            {
                ID = app.ID,
                Name = app.Name,
                CourseTypeId = app.CourseTypeId,
                Vahed = app.Vahed

            };


        public static List<CourseDto> AsDtos(this List<courses> applications)
           => applications.Select(AsDto).ToList(); 
    }
}
