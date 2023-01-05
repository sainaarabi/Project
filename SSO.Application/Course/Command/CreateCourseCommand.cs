using SSO.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.Command
{
    public class CreateCourseCommand : ICommand<CommandResult>
    {
        public CreateCourseCommand(string name
                                  , int courseTypeId
                                  , int vahed
                                 )
        {
            Name = name;
            CourseTypeId = courseTypeId;
            Vahed = vahed;

        }
        public string Name { get; set; }
        public int CourseTypeId { get; set; }
        public int Vahed { get; set; }

    }
}
