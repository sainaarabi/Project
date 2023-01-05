using SSO.Core.Definitions; 
using System;
using System.Collections.Generic;
using System.Text;
using Courses = SSO.Core.Domain.Course.Course;
using AcademicYears = SSO.Core.Domain.AcademicYear.AcademicYear;
using TimeSchedules = SSO.Core.Domain.TimeSchedule.TimeSchedule;
using SSO.Core.Domain.TimeSchedule;

namespace SSO.Core.Domain.Unit
{
    public class Unit : Entity, IAggregateRoot
    {
        public int ID { get; set; }


        public  int CourseID { get; private set; }
        public int AcademicYearID { get; private set; }

        public int TimeScheduleID { get; private set; }


        public virtual Courses Course { get; private set; }

        public virtual AcademicYears AcademicYear { get; private set; }

        public virtual  TimeSchedules TimeSchedule { get; private set; }


        public virtual ICollection<Teach.Teach> Teachs { get; private set; }

        public Unit() { }

        public Unit(int courseID
            , int academicYearID,
              int timeScheduleID)
        {

            CourseID = courseID;
            AcademicYearID = academicYearID;
            TimeScheduleID = timeScheduleID;
        }


        public void ChangeAcademicYearID(int academicYearID)
        {
            AcademicYearID = academicYearID;
        }

        public void ChangeCourseID(int courseID)
        {
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            CourseID = courseID;
        }
        public void ChangeTimeScheduleID(int timeScheduleID)
        {
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            TimeScheduleID = timeScheduleID;
        }
        public static Unit Create( int courseID
                                , int academicYearID
            ,int timeScheduleID)
        {
            var units = new Unit(courseID: courseID
            , academicYearID: academicYearID
                                    , timeScheduleID : timeScheduleID);

            return units;
        }
    }
}
