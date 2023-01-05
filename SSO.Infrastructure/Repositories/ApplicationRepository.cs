using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SSO.Core.Domain.Applications;
using SSO.Core.Repositories;
using SSO.Infrastructure.DBContext;

namespace SSO.Infrastructure.Repositories
{
    public class ApplicationRepository : GenericRepository<App>, IApplicationRepository
    {
        public ApplicationRepository(SSODbContext dbContext) : base(dbContext) { }

        public long Count()
        {
            return base.Count(x => true);
        }

        public Tuple<IEnumerable<App>, int> Get(string code,
          int page, int count)
        {
            var apps = AsQueryable();
            if (!string.IsNullOrEmpty(code))
                apps = apps.Where(x => x.Code.Contains(code));
            var result = apps.AsQueryable().Skip(page).Take(count).ToList();
            var countNumber = apps.Count();
            return new Tuple<IEnumerable<App>, int>(result, countNumber);
        }

        public List<App> GetApplicationListOfCustomerUser(int Id)
        {
            var param = new SqlParameter("@pCustomerId", Id);
            var result = _context.Applications
                .FromSqlRaw("dbo.GetApplicationListOfCustomerUser @pCustomerId",
                     new SqlParameter("@pCustomerId ", Id)).ToList();
            return result;
        }

      
 
        public async Task<App> GetApplicationByCode(string code)
        {           
            var app = await _context.Applications.FirstOrDefaultAsync(x => x.Code == code);
            return app;
        }
        public bool IsExists(int id) => _dbset.Any(x => x.ID == id);
        public async Task DeleteByIdAsync(int id) => _dbset.Remove((await _dbset.FindAsync(id)));
        public async Task<App> GetAsync(int id) => await _dbset.FindAsync(id);
        public async Task<App> GetAsync(int? id) => await _dbset.FindAsync(id);

    }
}
