using SSO.Application.AcademicYear.Command;
using SSO.Application.AcademicYear.Exceptions; 
using SSO.Application.Configuration.Commands; 
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Exceptions;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.CommandHandler
{
    public class EditAcademicYearCommandHandler : ICommandHandler<EditAcademicYearCommand, CommandResult>
    {
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditAcademicYearCommandHandler(IAcademicYearRepository academicYearRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _academicYearRepository = academicYearRepository;
        }

        public async Task<CommandResult> Handle(EditAcademicYearCommand request,
          CancellationToken cancellationToken)
        {
            var application = await _academicYearRepository.GetAsync(request.Id);
            if (application == null)
                throw new AcademicYearNotFoundException(request.Id);
            application.ChangeDate(request.Date); 
            await _academicYearRepository.UpdateOneAsync(application);
            await _unitOfWork.CommitAsync();

            return CommandResult.Ok;
        }


    }
}
