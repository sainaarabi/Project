using SSO.Core.Domain.Course;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSO.Core.Domain.AcademicYear;

namespace SSO.Core.Repositories
{
    public interface IAcademicYearRepository
    {
        Task InsertOneAsync(AcademicYear academicYear);
        bool IsExists(Expression<Func<AcademicYear, bool>> filter);
        bool IsExists(int id);
        Task<AcademicYear> GetAsync(int id);
        Task<AcademicYear> GetAsync(int? id);
        Task UpdateOneAsync(AcademicYear academicYear);
        long Count();
        Task DeleteByIdAsync(int id);

        IQueryable<AcademicYear> AsQueryable();
        IQueryable<AcademicYear> FilterBy(Expression<Func<AcademicYear, bool>> filterExpression);
    }
}
