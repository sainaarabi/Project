using SSO.Application.Configuration.Commands;
using SSO.Core.Domain.AcademicYear;
using SSO.Core.Domain.Course;
using SSO.Core.Domain.TimeSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.Command
{
    public class EditUnitCommand : ICommand<CommandResult>
    {
        public EditUnitCommand(int id, int courseID
                                  , int academicYearID
                                  , int timeScheduleID)
        {
            Id = id;
            CourseID = courseID;
            AcademicYearID = academicYearID;
            TimeScheduleID = timeScheduleID;

        }
        public int Id { get; set; }
        public int CourseID { get; set; }
        public int AcademicYearID { get; set; }
        public int TimeScheduleID { get; set; }



    }
}
