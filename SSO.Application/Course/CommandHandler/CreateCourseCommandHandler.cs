 using SSO.Application.Configuration.Commands;
using SSO.Application.Course.Command;
using SSO.Application.Teacher.Command; 
using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using courses = SSO.Core.Domain.Course.Course;
namespace SSO.Application.Course.CommandHandler
{
    public class CreateCourseCommandHandler:
        ICommandHandler<CreateCourseCommand, CommandResult>
    {
        private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(ICourseRepository courseRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
    }

    public ICourseRepository CourseRepository => _courseRepository;

    public async Task<CommandResult> Handle(CreateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var  course = courses.Create(name: request.Name
        , courseTypeId: request.CourseTypeId , vahed :request.Vahed);
        await _courseRepository.InsertOneAsync(course);
        await _unitOfWork.CommitAsync();
        return CommandResult.Ok;

    }


}
}
