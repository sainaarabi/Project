using SSO.Application.Applications.DTO;
using SSO.Application.Configuration.Commands;

namespace SSO.Application.Applications.Commands
{
    public class SearchApplicationCommand : ICommand<CommandResult>
    {
        public SearchApplicationCommand(SearchApplicationDto applicationDto
                           )
        {
            Title = applicationDto.Title;
            Code = applicationDto.Code;
 

        }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }

    }
}
