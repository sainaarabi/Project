using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.Command
{
    public class CreateTeacherCommand : ICommand<CommandResult>
    {

        public CreateTeacherCommand(string firstName
                           , string lastName
                          )
        {
            FirstName = firstName;
            LastName = lastName;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

    }
}
