using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.Command
{
    public class DeleteTimeSchedulCommand : ICommand<CommandResult>
    {
        public DeleteTimeSchedulCommand(int id)
        {

            Id = id;
        }
        public int Id { get; private set; }

    }
}
