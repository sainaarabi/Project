using SSO.Core.Domain.Course;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSO.Core.Domain.Unit;

namespace SSO.Core.Repositories
{
    public interface IUnitRepository
    {
        Task InsertOneAsync(Unit unit);
        bool IsExists(Expression<Func<Unit, bool>> filter);
        bool IsExists(int id);
        Task<Unit> GetAsync(int id);
        Task<Unit> GetAsync(int? id);
        Task UpdateOneAsync(Unit unit);
        long Count();
        Task DeleteByIdAsync(int id);

        IQueryable<Unit> AsQueryable();
        IQueryable<Unit> FilterBy(Expression<Func<Unit, bool>> filterExpression); 
        Task<IQueryable<Unit>> Get(List<int> courseId);
    }
}
