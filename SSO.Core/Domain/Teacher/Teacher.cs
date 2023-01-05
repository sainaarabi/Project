using SSO.Core.Definitions; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSO.Core.Domain.Teacher
{
    public class Teacher : Entity, IAggregateRoot
    {
        public int ID { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
          
        [NotMapped]
        public string FullName => $"[{FirstName}]-{LastName}";


        public virtual ICollection<Teach.Teach> Teachs { get; private set; }
        public Teacher() { }

        public Teacher(
                string firstName
              , string  lastName )
        {
            
            FirstName = firstName; 
            LastName = lastName;  
        }


        public void ChangeFirstName(string firstName)
        { 
            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        { 
            //CheckRule(new ApplicationMustHaveTitleRule(LastName));
            LastName = lastName;
        }

        //public void ChangeCode(string code)
        //{
        //    CheckRule(new ApplicationCodeMustHaveValidLengthRule(applicationCode: code,
        //                                              minLength: 0,
        //                                              maxLength: 100));
        //    CheckRule(new ApplicationCodeMustNotContaintRegularExpressionRule(code));
        //    CheckRule(new ApplicationMustHaveCodeRule(code));
        //    Code = code;
        //}
        public static Teacher Create(string firstName
                                , string lastName )
        {
            var teacher = new Teacher(firstName: firstName
                                    , lastName: lastName);

            return teacher;
        }
    }
}
