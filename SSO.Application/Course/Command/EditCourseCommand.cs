using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.Command
{
    public class EditCourseCommand : ICommand<CommandResult>
    {
        public EditCourseCommand(int id, string name,
            int courseTypeId, int vahed )
        {
            Id = id;
            Name = name;
            CourseTypeId = courseTypeId;
            Vahed = vahed;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseTypeId { get; set; }

        public int Vahed { get; set; }



    }
}
