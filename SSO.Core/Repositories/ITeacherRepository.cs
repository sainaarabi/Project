 
using SSO.Core.Domain.Teacher;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Core.Repositories
{
    public  interface ITeacherRepository
    {
        Task InsertOneAsync(Teacher teacher);
        bool IsExists(Expression<Func<Teacher, bool>> filter);
        bool IsExists(int id);
        Task<Teacher> GetAsync(int id);
        Task<Teacher> GetAsync(int? id);
        Task UpdateOneAsync(Teacher teacher);
        long Count();
        Task DeleteByIdAsync(int id);  

        IQueryable<Teacher> AsQueryable();
        IQueryable<Teacher> FilterBy(Expression<Func<Teacher, bool>> filterExpression); 
    }
}
