using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SSO.Core.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
      
        IQueryable<T> AsQueryable();
        IQueryable<T> FilterBy(Expression<Func<T, bool>> filterExpression);
        T GetOne(Expression<Func<T, bool>> filterExpression);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filterExpression);
        T Get(short id);
        Task<T> GetAsync(int id);
        void InsertOne(T document);
        Task InsertOneAsync(T document);
        void UpdateOne(T document);
        Task UpdateOneAsync(T document);
        void DeleteOne(Expression<Func<T, bool>> filterExpression);
        void DeleteOneAsync(Expression<Func<T, bool>> filterExpression);
        void DeleteById(short id);
        Task DeleteByIdAsync(int id);
        long Count(Expression<Func<T, bool>> filterExpression);
        Task<long> CountAsync(Expression<Func<T, bool>> filterExpression);

        //DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //void AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        //void RemoveThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    }
}

