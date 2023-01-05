using SSO.Application.Applications.DTO;
using SSO.Application.Configuration.Commands;

namespace SSO.Application.Applications.Commands
{
    public class EditApplicationCommand : ICommand<CommandResult>
    {
        public EditApplicationCommand(int id, string title,
            string code,
            string link)
        {
            Id = id;
            Title = title;
            Code = code;
            Link =  link;

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }




      
    }
}
