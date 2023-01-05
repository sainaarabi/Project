 using SSO.Application.Configuration.Commands;
using SSO.Application.Course.Command;
using SSO.Application.Course.Exceptions; 
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Application.TimeSchedul.Command;
using SSO.Application.TimeSchedul.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.CommandHandler
{
    public class DeleteTimeSchedulCommandHandler : ICommandHandler<DeleteTimeSchedulCommand, CommandResult>
    {
        private readonly ITimeSchedulRepository _timeSchedulRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTimeSchedulCommandHandler(ITimeSchedulRepository timeSchedulRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _timeSchedulRepository = timeSchedulRepository;
        }
        public async Task<CommandResult> Handle(DeleteTimeSchedulCommand request,
            CancellationToken cancellationToken)
        {
            if (!_timeSchedulRepository.IsExists(request.Id))
                throw new TimeSchedulNotFoundException(request.Id);




            await _timeSchedulRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}
