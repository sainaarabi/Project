 using SSO.Application.Configuration.Commands; 
using SSO.Application.Teach.Command;
using SSO.Application.Teach.Exceptions;
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Teach.CommandHandler
{
    public class EditTeachCommandHandler : ICommandHandler<EditTeachCommand, CommandResult>
    {
        private readonly ITeachRepository _teachRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditTeachCommandHandler(ITeachRepository teachRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _teachRepository = teachRepository;
        }
        public async Task<CommandResult> Handle(EditTeachCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _teachRepository.GetAsync(request.Id);
            if (application == null)
                throw new TeachNotFoundException(request.Id);
            application.ChangeTeacherID(request.TeacherID);
            application.ChangeUnitID(request.UnitID); 
            await _teachRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
