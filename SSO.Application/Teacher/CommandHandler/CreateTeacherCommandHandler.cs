 
using SSO.Application.Configuration.Commands;
using SSO.Application.Teacher.Command; 
using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teachers = SSO.Core.Domain.Teacher.Teacher;
namespace SSO.Application.Teacher.CommandHandler
{
    public class CreateTeacherCommandHandler:
        ICommandHandler<CreateTeacherCommand, CommandResult>
    {
        private readonly ITeacherRepository _teacherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTeacherCommandHandler(ITeacherRepository teacherRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
            _teacherRepository = teacherRepository;
    }

    public ITeacherRepository TeacherRepository => _teacherRepository;

    public async Task<CommandResult> Handle(CreateTeacherCommand request,
        CancellationToken cancellationToken)
    {
        var teacher = teachers.Create(firstName: request.FirstName
        , lastName: request.LastName);
        await _teacherRepository.InsertOneAsync(teacher);
        await _unitOfWork.CommitAsync();
        return CommandResult.Ok;

    }


}
}
