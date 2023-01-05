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
    public class EditTimeSchedulCommandHandler : ICommandHandler<EditTimeSchedulCommand, CommandResult>
    {
        private readonly ITimeSchedulRepository _timeSchedulRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditTimeSchedulCommandHandler(ITimeSchedulRepository timeSchedulRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _timeSchedulRepository = timeSchedulRepository;
        }
        public async Task<CommandResult> Handle(EditTimeSchedulCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _timeSchedulRepository.GetAsync(request.Id);
            if (application == null)
                throw new TimeSchedulNotFoundException(request.Id);
            application.ChangeStartTime(request.StartTime);
            application.ChangeEndTime(request.EndTime);
            application.ChangeDay(request.Day);
            await _timeSchedulRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
