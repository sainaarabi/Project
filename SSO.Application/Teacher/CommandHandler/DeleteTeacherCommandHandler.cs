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
    public class DeleteTeacherCommandHandler : ICommandHandler<DeleteTeacherCommand, CommandResult>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teacherRepository = teacherRepository;
        }

        public async Task<CommandResult> Handle(DeleteTeacherCommand request,
            CancellationToken cancellationToken)
        {
            if (!_teacherRepository.IsExists(request.Id))
                throw new TeacherNotFoundException(request.Id);




            await _teacherRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}
