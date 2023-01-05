using Microsoft.EntityFrameworkCore;
using SSO.Core;
using SSO.Core.Repositories;
using SSO.Infrastructure.DBContext;
using System.Linq.Expressions;


namespace SSO.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        protected SSODbContext _context;
        protected DbSet<T> _dbset;

        public GenericRepository(SSODbContext context)
        {
            this._context = context;
            _dbset = context.Set<T>();
        }

        public IQueryable<T> AsQueryable() => _dbset.AsQueryable();

        public long Count(Expression<Func<T, bool>> filterExpression) => _dbset.Count(filterExpression);

        public async Task<long> CountAsync(Expression<Func<T, bool>> filterExpression) =>
            await _dbset.CountAsync(filterExpression);

        public void DeleteById(short id) => _dbset.Remove(_dbset.Find(id));

        public async Task DeleteByIdAsync(int id) => _dbset.Remove((await _dbset.FindAsync(id)));

        public void DeleteOne(Expression<Func<T, bool>> filterExpression) =>
            _context.Entry(filterExpression).State = EntityState.Deleted;

        public void DeleteOneAsync(Expression<Func<T, bool>> filterExpression) =>
             _context.Remove(filterExpression);

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> filterExpression) =>
            _dbset.Where(filterExpression).AsNoTracking().AsQueryable<T>();


     

        public T Get(short id) => _dbset.Find(id);

        public async Task<T> GetAsync(int id) => await _dbset.FindAsync(id);
        public async Task<T> GetAsync(int? id) => await _dbset.FindAsync(id);

        public T GetOne(Expression<Func<T, bool>> filterExpression) => _dbset.SingleOrDefault(filterExpression);

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filterExpression) =>
            await _dbset.SingleOrDefaultAsync(filterExpression);

        public void InsertOne(T document) => _dbset.Add(document);

        public async Task InsertOneAsync(T document) => await _dbset.AddAsync(document);

        public void UpdateOne(T document) => _context.Entry(document).State = EntityState.Modified;

        public Task UpdateOneAsync(T document)
        {
            _context.Update(document);
            return _context.SaveChangesAsync();
        }
   
        public bool IsExists(Expression<Func<T, bool>> filter) => _dbset.Any(filter);

     //  public bool IsExists(int id) => _dbset.Any(x => x.ID == id);


        //public void RemoveThisRange<TEntity>(IEnumerable<TEntity> entities) 
        //    where TEntity : class
        //{
        //   _dbset.RemoveRange();
        //}


        //public void AddThisRange<TEntity>(IEnumerable<TEntity> entities) 
        //    where TEntity : class
        //{
        //    _dbset.AddRange();
        //}


        //public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Modified;
        //}
        //public void MarkAsDetached<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Detached;
        //}

        //public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        //{
        //    Entry(entity).State = EntityState.Deleted;
        //}
    }
}
