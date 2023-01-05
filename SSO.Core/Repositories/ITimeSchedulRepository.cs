using SSO.Core.Domain.Course;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSO.Core.Domain.TimeSchedule;

namespace SSO.Core.Repositories
{
    public interface ITimeSchedulRepository
    {
        Task InsertOneAsync(TimeSchedule timeSchedule);
        bool IsExists(Expression<Func<TimeSchedule, bool>> filter);
        bool IsExists(int id);
        Task<TimeSchedule> GetAsync(int id);
        Task<TimeSchedule> GetAsync(int? id);
        Task UpdateOneAsync(TimeSchedule timeSchedule);
        long Count();
        Task DeleteByIdAsync(int id);

        IQueryable<TimeSchedule> AsQueryable();
        IQueryable<TimeSchedule> FilterBy(Expression<Func<TimeSchedule, bool>> filterExpression);
    }
}
