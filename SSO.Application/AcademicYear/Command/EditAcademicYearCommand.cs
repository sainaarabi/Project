using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.Command
{
    public class EditAcademicYearCommand : ICommand<CommandResult>
    {
        public EditAcademicYearCommand(int id, string date )
        {
            Id = id;
            Date =  date; 

        }
        public int Id { get; set; }
        public string Date { get; set; }



    }
}
