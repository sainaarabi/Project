using SSO.Application.Applications.Commands;
using SSO.Application.Applications.Exceptions;
using SSO.Application.Configuration.Commands;
using SSO.Application.Customers.Exceptions;
using SSO.Core.Repositories;

namespace SSO.Application.Applications.CommandHandlers
{
    public class DeleteApplicationCommandHandler : ICommandHandler<DeleteApplicationCommand, CommandResult>
    {
        private readonly IApplicationRepository _applicationRepository; 
        private readonly IUnitOfWork _unitOfWork;
        public DeleteApplicationCommandHandler(IApplicationRepository applicationRepository 
            , IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository; 
        }

        public async Task<CommandResult> Handle(DeleteApplicationCommand request,
            CancellationToken cancellationToken)
        {
            if (!_applicationRepository.IsExists(request.Id))
                throw new ApplicationNotFoundException(request.Id);
            

         
           
            await _applicationRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}

