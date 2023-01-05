using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.Command
{
    public class DeleteTeacherCommand : ICommand<CommandResult>
    {
        public DeleteTeacherCommand(int id)
        {

            Id = id;
        }
        public int Id { get; private set; }

    }
}
