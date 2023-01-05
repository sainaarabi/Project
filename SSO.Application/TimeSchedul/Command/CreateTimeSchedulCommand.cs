using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.TimeSchedul.Command
{
    public class CreateTimeSchedulCommand : ICommand<CommandResult>
    {
        public CreateTimeSchedulCommand(string  startTime
                                  ,  string  endTime
                                  , int  day
                                 )
        {
            StartTime = startTime;
            EndTime = endTime;
            Day = day;

        }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Day { get; set; }

    }
}
