using SSO.Core.Definitions;
using SSO.Core.Domain.AcademicYear;
using SSO.Core.Domain.Course;
using SSO.Core.Domain.TimeSchedule;
using System;
using System.Collections.Generic;
using System.Text;
using Teachers = SSO.Core.Domain.Teacher.Teacher;
using Units = SSO.Core.Domain.Unit.Unit;
namespace SSO.Core.Domain.Teach
{
    public class Teach : Entity, IAggregateRoot
    {
        public int ID { get; set; }
         
        public int TeacherID { get; private set; }
        public int UnitID { get; private set; } 

        public virtual Teachers Teacher { get; private set; }

        public virtual Units Unit { get; private set; }

        public Teach() { }

        public Teach(int teacherID
            , int unitID)
        {

            TeacherID = teacherID;
            UnitID = unitID; 
        }


        public void ChangeUnitID(int unitID)
        {
            UnitID = unitID;
        }

        public void ChangeTeacherID(int teacherID)
        {
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            TeacherID = teacherID;
        }
  
        public static Teach Create(int teacherID
                                , int unitID )
        {
            var teachs = new Teach(teacherID: teacherID
            , unitID: unitID );

            return teachs;
        }
    }
}
