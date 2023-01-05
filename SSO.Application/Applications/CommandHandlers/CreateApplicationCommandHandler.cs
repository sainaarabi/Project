using SSO.Application.Applications.Commands;
using SSO.Application.Configuration.Commands;
using SSO.Core.Domain.Applications;
using SSO.Core.Repositories;

namespace SSO.Application.Applications.CommandHandlers
{
    public class CreateApplicationCommandHandler :
        ICommandHandler<CreateApplicationCommand, CommandResult>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateApplicationCommandHandler(IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
        }

        public IApplicationRepository ApplicationRepository => _applicationRepository;

        public async Task<CommandResult> Handle(CreateApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var app = App.Create(title: request.Title
                                       , code: request.Code
                                       , link: request.Link);
            await _applicationRepository.InsertOneAsync(app);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
 
        }


    }
}
