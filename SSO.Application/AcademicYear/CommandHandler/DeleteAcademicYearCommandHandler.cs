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
    public class DeleteAcademicYearCommandHandler : ICommandHandler<DeleteAcademicYearCommand, CommandResult>
    {
        private readonly IAcademicYearRepository _academicYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAcademicYearCommandHandler(IAcademicYearRepository academicYearRepository
            , IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _academicYearRepository = academicYearRepository;
        }

        public async Task<CommandResult> Handle(DeleteAcademicYearCommand request,
            CancellationToken cancellationToken)
        {
            if (!_academicYearRepository.IsExists(request.Id))
                throw new AcademicYearNotFoundException(request.Id);




            await _academicYearRepository.DeleteByIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
            return CommandResult.Ok;
        }
    }
}
