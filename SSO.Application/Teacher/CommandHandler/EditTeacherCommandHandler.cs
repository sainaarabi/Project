using SSO.Application.Configuration.Commands; 
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teacher.CommandHandler
{
    public class EditTeacherCommandHandler : ICommandHandler<EditTeacherCommand, CommandResult>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditTeacherCommandHandler(ITeacherRepository teacherRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherRepository = teacherRepository;
        }
        public async Task<CommandResult> Handle(EditTeacherCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _teacherRepository.GetAsync(request.Id);
            if (application == null)
                throw new TeacherNotFoundException(request.Id);
            application.ChangeFirstName(request.FirstName);
            application.ChangeLastName(request.LastName); 
            await _teacherRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
