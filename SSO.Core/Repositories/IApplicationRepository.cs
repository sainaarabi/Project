using SSO.Core.Domain.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SSO.Core.Repositories
{
    public interface IApplicationRepository
    {
        Task InsertOneAsync(App application);
        bool IsExists(Expression<Func<App, bool>> filter);
        bool IsExists(int id);
        Task<App> GetAsync(int id);
        Task<App> GetAsync(int? id);
        Task UpdateOneAsync(App application);
        long Count();
        Task DeleteByIdAsync(int id);
        List<App> GetApplicationListOfCustomerUser(int Id);
        Tuple<IEnumerable<App>, int> Get(string code,
           int page, int count);

        IQueryable<App> AsQueryable(); 
        IQueryable<App> FilterBy(Expression<Func<App, bool>> filterExpression);
        Task<App> GetApplicationByCode(string code);
    }
}
