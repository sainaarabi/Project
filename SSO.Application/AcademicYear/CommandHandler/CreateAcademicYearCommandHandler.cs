using SSO.Application.AcademicYear.Command; 
using SSO.Application.Configuration.Commands;
using SSO.Application.Teacher.Command; 
using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicYears = SSO.Core.Domain.AcademicYear.AcademicYear;
namespace SSO.Application.AcademicYear.CommandHandler
{
    public class CreateAcademicYearCommandHandler :
        ICommandHandler<CreateAcademicYearCommand, CommandResult>
    {
        private readonly IAcademicYearRepository _academicYearRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAcademicYearCommandHandler(IAcademicYearRepository academicYearRepository,
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
         _academicYearRepository = academicYearRepository;
    }

    public IAcademicYearRepository AcademicYearRepository => _academicYearRepository;

    public async Task<CommandResult> Handle(CreateAcademicYearCommand request,
        CancellationToken cancellationToken)
    {
        var academicYear = AcademicYears.Create( date: request.Date);
        await _academicYearRepository.InsertOneAsync(academicYear);
        await _unitOfWork.CommitAsync();
        return CommandResult.Ok;

    }


}
}
