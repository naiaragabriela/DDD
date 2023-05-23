using System.Linq.Expressions;
using CQRS.Domain.Contracts.v1;
using CQRS.Domain.Entities.v1;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CQRS.Infra.Repository.v1.Repositories;

public abstract class BaseRepository<T> where T : IEntity
{
    protected BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings)
    {
        var database = client.GetDatabase(settings.Value.DatabaseName);
        Collection = database.GetCollection<T>(typeof(T).Name);
    }

    public readonly IMongoCollection<T> Collection;

    public async Task AddAsync(T entity, CancellationToken cancellation)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellation);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellation)
    {

        var filter = GetFilterById(entity.Id);
        await Collection.ReplaceOneAsync(
           filter, 
           entity,
           cancellationToken: cancellation);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellation)
    {
        var filter = GetFilterById(id);
        await Collection.DeleteOneAsync(filter, cancellationToken: cancellation);
    }

    public async Task<T> FindByIdAsync(Guid id, CancellationToken cancellation)
    {
        var filter = GetFilterById(id);
        return await Collection.Find(filter).FirstOrDefaultAsync(cancellation);
    }
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellation)
    {
        var filter = Builders<T>.Filter.Where(expression);

        return await Collection.Find(filter).ToListAsync(cancellation);
    }
    public FilterDefinition<T> GetFilterById(Guid id)
    {
        return Builders<T>.Filter.Eq(entity => entity.Id, id);
    }
}
