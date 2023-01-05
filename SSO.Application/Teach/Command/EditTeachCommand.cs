using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Command
{
    public class EditTeachCommand : ICommand<CommandResult>
    {
        public EditTeachCommand(int id,  int teacherID,
            int unitID)
        {
            Id = id;
            TeacherID = teacherID;
            UnitID = unitID; 

        }
        public int Id { get; set; }
        public int TeacherID { get; set; }
        public int UnitID { get; set; }




    }
}
