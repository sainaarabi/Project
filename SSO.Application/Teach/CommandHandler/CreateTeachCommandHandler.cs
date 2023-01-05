 
using SSO.Application.Configuration.Commands;
using SSO.Application.Teach.Command;
using SSO.Application.Teach.Exceptions;
using SSO.Application.Teacher.Command; 
using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teachs = SSO.Core.Domain.Teach.Teach;
namespace SSO.Application.Teach.CommandHandler
{
    public class CreateTeachCommandHandler:
        ICommandHandler<CreateTeachCommand, CommandResult>
    {
    private readonly ITeachRepository _teachRepository;
    private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitRepository _unitRepository;
        public CreateTeachCommandHandler(ITeachRepository teachRepository,
        IUnitOfWork unitOfWork,
        IUnitRepository unitRepository)
        {
            _unitOfWork = unitOfWork;
            _teachRepository = teachRepository;
            _unitRepository = unitRepository;
        }

            public ITeachRepository TeachRepository => _teachRepository;

    public async Task<CommandResult> Handle(CreateTeachCommand request,
        CancellationToken cancellationToken)
    {
        var teach = teachs.Create(teacherID: request.TeacherID
        , unitID: request.UnitID);
            var unit = await _unitRepository.GetAsync(request.UnitID);
            List<teachs> te =   _teachRepository.FilterBy(x => x.TeacherID == request.TeacherID && x.Unit.TimeScheduleID == unit.TimeScheduleID).ToList();
            if (te.Count != 0)
            {
                throw new InterferenceTimeException();
            }
            await _teachRepository.InsertOneAsync(teach);
        await _unitOfWork.CommitAsync();
        return CommandResult.Ok;

    }


}
}
