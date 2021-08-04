using MatchSchedulerAPI.Data;
using MatchSchedulerAPI.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MatchSchedulerAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : IDocument
    {
        private IMongoCollection<T> collection = null;

        public Repository(IMatchSchedulerDatabaseSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute)type.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return collection.AsQueryable();
        }


        public void DeleteById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);
            collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);
                collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => collection.DeleteManyAsync(filterExpression));
        }

        public void DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => collection.FindOneAndDeleteAsync(filterExpression));
        }

        public virtual IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            return collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public T FindByID(string Id)
        {
            var objectId = new ObjectId(Id);
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);
            return collection.Find(filter).SingleOrDefault();
        }

        public Task<T> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectID = new ObjectId(id);
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectID);
                return collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            return collection.Find(filterExpression).FirstOrDefault();
        }

        public Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => { return collection.Find(filterExpression).FirstOrDefaultAsync(); });
        }


        public void InsertMany(ICollection<T> documents)
        {
            collection.InsertMany(documents);
        }

        public virtual async Task InsertManyAsync(ICollection<T> documents)
        {
            await collection.InsertManyAsync(documents);
        }

        public void InsertOne(T document)
        {
            collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(T document)
        {
            return Task.Run(() => collection.InsertOneAsync(document));
        }

        public void ReplaceOne(T document)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceOneAsync(T document)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository<T>.FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            throw new NotImplementedException();
        }
    }
}
