using SSO.Application.Applications.Commands;
using SSO.Application.Configuration.Commands;
using SSO.Application.Customers.Exceptions;
using SSO.Core.Repositories;

namespace SSO.Application.Applications.CommandHandlers
{
    public  class EditApplicationCommandHandler : ICommandHandler<EditApplicationCommand, CommandResult>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditApplicationCommandHandler(IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
        }
        public async Task<CommandResult> Handle(EditApplicationCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _applicationRepository.GetAsync(request.Id);
            if (application == null)
                throw new ApplicationNotFoundException(request.Id);
            application.ChangeCode(request.Code);
            application.ChangeTitle(request.Title);
            application.ChangeLink(request.Link);
            await _applicationRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
