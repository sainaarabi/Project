namespace SSO.Application.Configuration.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected CommandBase()
        {
        }

    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        protected CommandBase()
        {
        }
    }
}
