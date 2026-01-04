using System.Linq.Expressions;

using MongoDB.Driver;

namespace M365.Infrastructure.Mongo;

public abstract class MongoRepository<T>(IMongoDatabase db, string collectionName)
{
    protected readonly IMongoCollection<T> _collection = db.GetCollection<T>(collectionName);

    public async Task InsertAsync(T entity) =>
        await _collection.InsertOneAsync(entity);

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter) =>
        await _collection.Find(filter).FirstOrDefaultAsync();

    public async Task UpdateAsync(Expression<Func<T, bool>> filter, T entity) =>
        await _collection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });
}