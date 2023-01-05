using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Application.Course.DTO
{
    public class CourseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CourseTypeId { get; set; }
        public int Vahed { get; set; }
    }
}
