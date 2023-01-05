using SSO.Application.Configuration.Commands;

namespace SSO.Application.Applications.Commands
{
    public class CreateApplicationCommand : ICommand<CommandResult>
    {
        public CreateApplicationCommand(string title
                            , string code
                            , string link
                           )
        {
            Title = title;
            Code = code;
            Link = link;

        }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }

    }
}
