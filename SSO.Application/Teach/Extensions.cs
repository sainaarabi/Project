using SSO.Application.Teach.DTO;
using SSO.Application.Teacher.DTO; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using teachs = SSO.Core.Domain.Teach.Teach;
namespace SSO.Application.Teach
{
    public static class Extensions
    {


        public static teachs AsEntity(this TeachDto appDto)
    => new teachs();
        public static TeachDto AsDto(this teachs app)
            => app == null ? null : new TeachDto()
            {
                ID = app.ID,
                TeacherID = app.TeacherID,
                UnitID = app.UnitID,

            };


        public static List<TeachDto> AsDtos(this List<teachs> applications)
           => applications.Select(AsDto).ToList(); 
    }
}
