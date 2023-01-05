using SSO.Core.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSO.Core.Domain.Course
{
    public class Course : Entity, IAggregateRoot
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public int  CourseTypeId { get; private set; }

        public int Vahed { get; private set; }

        public virtual ICollection<Unit.Unit>  Units { get; private set; }

        public Course() { }

        public Course(
                string  name
              , int courseTypeId
            , int vahed)
        {

            Name = name;
            CourseTypeId = courseTypeId;
            Vahed = vahed;
        }


        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeCourseTypeId(int courseTypeId)
        {
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            CourseTypeId = courseTypeId;
        }

        public void ChangeVahed(int vahed)
        { 
            Vahed = vahed;
        }
        public static Course Create(string name
                                , int courseTypeId
                                , int vahed)
        {
            var course = new Course(name: name
                                    , courseTypeId: courseTypeId
                                    , vahed: vahed);

            return course;
        }
    } 
}
