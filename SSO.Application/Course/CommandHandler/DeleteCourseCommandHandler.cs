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
    public class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand, CommandResult>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCourseCommandHandler(ICourseRepository courseRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<CommandResult> Handle(DeleteCourseCommand request,
            CancellationToken cancellationToken)
        {
            if (!_courseRepository.IsExists(request.Id))
                throw new CourseNotFoundException(request.Id);




            await _courseRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}
