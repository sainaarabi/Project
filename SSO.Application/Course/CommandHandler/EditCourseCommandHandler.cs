 using SSO.Application.Configuration.Commands;
using SSO.Application.Course.Command;
using SSO.Application.Course.Exceptions; 
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.CommandHandler
{
    public class EditCourseCommandHandler : ICommandHandler<EditCourseCommand, CommandResult>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditCourseCommandHandler(ICourseRepository courseRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }
        public async Task<CommandResult> Handle(EditCourseCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _courseRepository.GetAsync(request.Id);
            if (application == null)
                throw new CourseNotFoundException(request.Id);
            application.ChangeName(request.Name);
            application.ChangeCourseTypeId(request.CourseTypeId);
            application.ChangeVahed(request.Vahed);
            await _courseRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
