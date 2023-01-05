using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.AcademicYear.Command
{
    public class CreateAcademicYearCommand : ICommand<CommandResult>
    {

        public CreateAcademicYearCommand(string date 
                          )
        {
            Date =  date; 

        }
        public string Date { get; set; }


    }
}
