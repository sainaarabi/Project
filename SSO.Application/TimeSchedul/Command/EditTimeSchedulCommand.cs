using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.Command
{
    public class EditTimeSchedulCommand : ICommand<CommandResult>
    {
        public EditTimeSchedulCommand(int id ,string  startTime
                                  , string endTime
                                  , int day)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;

        }
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Day { get; set; }



    }
}
