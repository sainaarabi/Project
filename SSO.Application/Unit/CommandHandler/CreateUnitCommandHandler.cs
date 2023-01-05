 
using SSO.Application.Configuration.Commands;
using SSO.Application.Course.Command;
using SSO.Application.Teacher.Command;
using SSO.Application.Unit.Command; 
using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units = SSO.Core.Domain.Unit.Unit;
namespace SSO.Application.Unit.CommandHandler
{
    public class CreateUnitCommandHandler :
        ICommandHandler<CreateUnitCommand, CommandResult>
    {
        private readonly IUnitRepository _unitRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUnitCommandHandler(IUnitRepository unitRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
    }

    public IUnitRepository UnitRepository => _unitRepository;

    public async Task<CommandResult> Handle(CreateUnitCommand request,
        CancellationToken cancellationToken)
    {
        var  course = Units.Create(courseID: request.CourseID
        , academicYearID: request.AcademicYearID , timeScheduleID: request.TimeScheduleID);
        await _unitRepository.InsertOneAsync(course);
        await _unitOfWork.CommitAsync();
        return CommandResult.Ok;

    }


}
}
