using SSO.Application.Applications.Commands;
using SSO.Application.Applications.DTO;
using SSO.Application.Configuration.Commands;
using SSO.Core.Domain.Applications;
using SSO.Core.Repositories;
 

namespace SSO.Application.Applications.CommandHandlers
{
    public class SearchApplicationCommandHandler :
        ICommandHandler<SearchApplicationCommand, CommandResult>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SearchApplicationCommandHandler(IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
        }

        public IApplicationRepository ApplicationRepository => _applicationRepository;

        public async Task<CommandResult> Handle(SearchApplicationCommand request,
            CancellationToken cancellationToken)
        {
 
            List<App> list = new List<App>();
            list = _applicationRepository.FilterBy(x =>
                                (request.Title == null ? true : x.Title == request.Title) &&
                                (request.Code == null ? true : x.Code == request.Code)).OrderByDescending(x => x.ID).ToList();
            var result = new List<SearchApplicationDto>();
            result = list.Select(b => new SearchApplicationDto()
            {
                Title = b.Title,
                Code = b.Code
            }).ToList();
            return new CommandResult(Enums.CommandResultStatus.Success, result);

        }


    }
}
