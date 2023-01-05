using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.Command
{
    public class CreateUnitCommand : ICommand<CommandResult>
    {
        public CreateUnitCommand(int courseID
                                  , int academicYearID
                                  , int timeScheduleID
                                 )
        {
            CourseID = courseID;
            AcademicYearID = academicYearID;
            TimeScheduleID = timeScheduleID;

        }
        public int CourseID { get; set; }
        public int AcademicYearID { get; set; }

        public int TimeScheduleID { get; set; }

    }
}
