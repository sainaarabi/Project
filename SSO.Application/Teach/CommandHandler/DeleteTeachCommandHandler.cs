 using SSO.Application.Configuration.Commands; 
using SSO.Application.Teach.Command;
using SSO.Application.Teach.Exceptions;
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.CommandHandler
{
    public class DeleteTeachCommandHandler : ICommandHandler<DeleteTeachCommand, CommandResult>
    {
        private readonly ITeachRepository _teachRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTeachCommandHandler(ITeachRepository teachRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teachRepository = teachRepository;
        }

        public async Task<CommandResult> Handle(DeleteTeachCommand request,
            CancellationToken cancellationToken)
        {
            if (!_teachRepository.IsExists(request.Id))
                throw new TeachNotFoundException(request.Id);




            await _teachRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}
