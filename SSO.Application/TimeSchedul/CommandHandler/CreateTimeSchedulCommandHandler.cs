using SSO.Application.Configuration.Commands;
using SSO.Application.Course.Command;
using SSO.Application.Teacher.Command;
using SSO.Application.TimeSchedul.Command; 
using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSchedules = SSO.Core.Domain.TimeSchedule.TimeSchedule;
namespace SSO.Application.TimeSchedul.CommandHandler
{
    public class CreateTimeSchedulCommandHandler :
        ICommandHandler<CreateTimeSchedulCommand, CommandResult>
    {
        private readonly ITimeSchedulRepository _timeSchedulRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTimeSchedulCommandHandler(ITimeSchedulRepository timeSchedulRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
            _timeSchedulRepository = timeSchedulRepository;
    }

    public ITimeSchedulRepository TimeSchedulRepository => _timeSchedulRepository;

    public async Task<CommandResult> Handle(CreateTimeSchedulCommand request,
        CancellationToken cancellationToken)
    {
        var  course = TimeSchedules.Create(startTime: request.StartTime
        , endTime: request.EndTime , day: request.Day);
        await _timeSchedulRepository.InsertOneAsync(course);
        await _unitOfWork.CommitAsync();
        return CommandResult.Ok;

    }


}
}
