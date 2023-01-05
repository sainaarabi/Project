using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.Command
{
    public class DeleteCourseCommand : ICommand<CommandResult>
    {
        public DeleteCourseCommand(int id)
        {

            Id = id;
        }
        public int Id { get; private set; }

    }
}
