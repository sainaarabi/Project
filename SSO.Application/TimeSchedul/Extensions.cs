using SSO.Application.Course.DTO;
using SSO.Application.Teacher.DTO;
using SSO.Application.TimeSchedul.DTO; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeScheduls = SSO.Core.Domain.TimeSchedule.TimeSchedule;
namespace SSO.Application.TimeSchedul
{
    public static class Extensions
    {


        public static TimeScheduls AsEntity(this TimeSchedulDto appDto)
    => new TimeScheduls();
        public static TimeSchedulDto AsDto(this TimeScheduls app)
            => app == null ? null : new TimeSchedulDto()
            {

                ID = app.ID,
                StartTime = app.StartTime,
                EndTime = app.EndTime,
                Day = app.Day

            };


        public static List<TimeSchedulDto> AsDtos(this List<TimeScheduls> applications)
           => applications.Select(AsDto).ToList(); 
    }
}
