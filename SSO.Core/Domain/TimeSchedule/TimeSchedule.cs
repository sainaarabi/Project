using SSO.Core.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSO.Core.Domain.TimeSchedule
{
    public class TimeSchedule : Entity, IAggregateRoot
    {
        public int ID { get; set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public  int Day { get; private set; }

        public virtual ICollection<Unit.Unit> Units { get; private set; }

        public TimeSchedule() { }

        public TimeSchedule(
                string startTime
              , string endTime
               , int day)
        {

             StartTime = startTime;
             EndTime = endTime;
            Day= day;

        }


        public void ChangeStartTime(string startTime)
        {
            StartTime = startTime;
        }

        public void ChangeEndTime(string endTime)
        {
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            EndTime = endTime;
        }
        public void ChangeDay(int day)
        {
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            Day = day;
        }
        public static TimeSchedule Create(string  startTime
                                , string  endTime
                                 , int day)
        {
            var timeSchedules = new TimeSchedule(startTime: startTime
                                    , endTime: endTime
                                    , day : day);

            return timeSchedules;
        }
    }
}
