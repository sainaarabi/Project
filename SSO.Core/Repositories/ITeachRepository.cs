using SSO.Core.Domain.Teacher;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSO.Core.Domain.Teach;

namespace SSO.Core.Repositories
{
    public interface ITeachRepository
    {
        Task InsertOneAsync(Teach teach);
        bool IsExists(Expression<Func<Teach, bool>> filter);
        bool IsExists(int id);
        Task<Teach> GetAsync(int id);
        Task<Teach> GetAsync(int? id);
        Task UpdateOneAsync(Teach teach);
        long Count();
        Task DeleteByIdAsync(int id);

        IQueryable<Teach> AsQueryable();
        IQueryable<Teach> FilterBy(Expression<Func<Teach, bool>> filterExpression);
    }
}