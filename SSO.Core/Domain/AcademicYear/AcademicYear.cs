using SSO.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Core.Domain.AcademicYear
{
    public class AcademicYear : Entity, IAggregateRoot
    {
        public int ID { get; set; }
        public string Date { get; private set; }

        public virtual ICollection<Unit.Unit> Units { get; private set; }

        public AcademicYear() { }

        public AcademicYear(
                string  date )
        {

            Date = date; 
        }


        public void ChangeDate(string name)
        {
            Date = name;
        }

      
        public static AcademicYear Create(string date )
        {
            var academicYear = new AcademicYear(date: date);

            return academicYear;
        }
    }
}
