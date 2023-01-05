 using SSO.Core.Domain.Teacher;
using SSO.Core.Repositories;
using SSO.Infrastructure.DBContext; 

namespace SSO.Infrastructure.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SSODbContext dbContext) : base(dbContext) { }

        public long Count()
        {
            return base.Count(x => true);
        }
        public bool IsExists(int id) => _dbset.Any(x => x.ID == id);

    }
}
