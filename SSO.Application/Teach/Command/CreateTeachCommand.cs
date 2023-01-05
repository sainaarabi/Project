using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Command
{
    public class CreateTeachCommand : ICommand<CommandResult>
    {

        public CreateTeachCommand( int teacherID
                           , int unitID
                          )
        {
            TeacherID = teacherID;
            UnitID = unitID;

        }
        public int TeacherID { get; set; }
        public int UnitID { get; set; }


    }
}
