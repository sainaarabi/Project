using SSO.Core.Domain.Course;
using SSO.Core.Domain.Unit;
using SSO.Core.Repositories;
using SSO.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using units = SSO.Core.Domain.Unit.Unit;
namespace SSO.Infrastructure.Repositories
{
    public class UnitRepository : GenericRepository<units>, IUnitRepository
    {
        public UnitRepository(SSODbContext dbContext) : base(dbContext) { }

        public long Count()
        {
            return base.Count(x => true);
        }
        public bool IsExists(int id) => _dbset.Any(x => x.ID == id);

        public Task<IQueryable<Unit>> Get(List<int> courseId)
        {
            return Task.FromResult(FilterBy(x => courseId.Contains(x.CourseID)));
        }
    }
}

