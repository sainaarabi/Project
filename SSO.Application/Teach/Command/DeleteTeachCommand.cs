using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.Command
{
    public class DeleteTeachCommand : ICommand<CommandResult>
    {
        public DeleteTeachCommand(int id)
        {

            Id = id;
        }
        public int Id { get; private set; }

    }
}
