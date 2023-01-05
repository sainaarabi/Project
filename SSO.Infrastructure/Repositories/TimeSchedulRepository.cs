using SSO.Core.Domain.Course;
using SSO.Core.Domain.TimeSchedule;
using SSO.Core.Repositories;
using SSO.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Infrastructure.Repositories
{
    public class TimeSchedulRepository : GenericRepository<TimeSchedule>, ITimeSchedulRepository
    {
        public TimeSchedulRepository(SSODbContext dbContext) : base(dbContext) { }

        public long Count()
        {
            return base.Count(x => true);
        }
        public bool IsExists(int id) => _dbset.Any(x => x.ID == id);
    }
}
