using SSO.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using courses = SSO.Core.Domain.Course.Course;
namespace SSO.Application.Teach.Queries
{
    public class GetClassTimingQuery : QueryBase<QueryResult>
    {

        public int TeacherId { get; private set; } 
        public List<int> CourseId { get; private set; }

        public GetClassTimingQuery(int teacherId, List<int> courseId)
        {
            TeacherId = teacherId;
            CourseId = courseId;
        }
    }
}
