using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.Command
{
    public class DeleteUnitCommand : ICommand<CommandResult>
    {
        public DeleteUnitCommand(int id)
        {

            Id = id;
        }
        public int Id { get; private set; }

    }
}
