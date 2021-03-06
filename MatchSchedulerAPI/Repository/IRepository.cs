using MatchSchedulerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MatchSchedulerAPI.Repository
{
    public interface IRepository<T> where T:IDocument
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression);
        IEnumerable<T> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TProjected>> projectionExpression);
        T FindOne(Expression<Func<T, bool>> filterExpression);
        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);
        T FindByID(string Id);
        Task<T> FindByIdAsync(string id);

        void InsertOne(T document);

        Task InsertOneAsync(T document);

        void InsertMany(ICollection<T> documents);

        Task InsertManyAsync(ICollection<T> documents);

        void ReplaceOne(T document);

        Task ReplaceOneAsync(T document);

        void DeleteOne(Expression<Func<T, bool>> filterExpression);

        Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

        void DeleteById(string id);

        Task DeleteByIdAsync(string id);

        void DeleteMany(Expression<Func<T, bool>> filterExpression);

        Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
    }
}
