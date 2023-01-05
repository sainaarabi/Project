using SSO.Application.Configuration.Commands;
using SSO.Application.Course.Command;
using SSO.Application.Course.Exceptions; 
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.Unit.Command;
using SSO.Application.Unit.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Unit.CommandHandler
{
    public class DeleteUnitCommandHandler : ICommandHandler<DeleteUnitCommand, CommandResult>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUnitCommandHandler(IUnitRepository unitRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }

        public async Task<CommandResult> Handle(DeleteUnitCommand request,
            CancellationToken cancellationToken)
        {
            if (!_unitRepository.IsExists(request.Id))
                throw new UnitNotFoundException(request.Id);



            await _unitRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}
