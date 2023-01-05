 
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
    public class EditUnitCommandHandler : ICommandHandler<EditUnitCommand, CommandResult>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditUnitCommandHandler(IUnitRepository unitRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitRepository = unitRepository;
        }
        public async Task<CommandResult> Handle(EditUnitCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _unitRepository.GetAsync(request.Id);
            if (application == null)
                throw new UnitNotFoundException(request.Id);
            application.ChangeCourseID(request.CourseID);
            application.ChangeAcademicYearID(request.AcademicYearID);
            application.ChangeTimeScheduleID(request.TimeScheduleID);
            await _unitRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
