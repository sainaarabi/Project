using SSO.Core.Domain.Teacher;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSO.Core.Domain.Course;

namespace SSO.Core.Repositories
{
    public interface ICourseRepository
    {
        Task InsertOneAsync(Course course);
        bool IsExists(Expression<Func<Course, bool>> filter);
        bool IsExists(int id);
        Task<Course> GetAsync(int id);
        Task<Course> GetAsync(int? id);
        Task UpdateOneAsync(Course course);
        long Count();
        Task DeleteByIdAsync(int id);

        IQueryable<Course> AsQueryable();
        IQueryable<Course> FilterBy(Expression<Func<Course, bool>> filterExpression);
    }
}
