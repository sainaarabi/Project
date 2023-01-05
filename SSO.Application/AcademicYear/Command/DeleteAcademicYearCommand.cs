using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.Command
{
    public class DeleteAcademicYearCommand : ICommand<CommandResult>
    {
        public DeleteAcademicYearCommand(int id)
        {

            Id = id;
        }
        public int Id { get; private set; }

    }
}
