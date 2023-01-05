using SSO.Application.Configuration.Commands;

namespace SSO.Application.Applications.Commands
{
    public  class DeleteApplicationCommand : ICommand<CommandResult>
    {
        public DeleteApplicationCommand(int id)
        { 

            Id = id;
        }
        public int Id { get; private set; }

    }
}

