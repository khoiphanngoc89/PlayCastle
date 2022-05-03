using MongoDB.Driver;
using Common.SharedKernel.DatabaseProvider;
using Serilog;

namespace Catalog.API.Repositories
{

    public class MongoDbRepository<T> : IRepository<T>
        where T : IEntity
    {
        private readonly IMongoCollection<T> _dbCollection;

        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoDbRepository(IMongoDatabase db, string collectionName)
        {
            _dbCollection = db.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var filter = filterBuilder.Eq(n => n.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                Log.Error("The entity is null");
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                Log.Error("The entity is null");
                throw new ArgumentNullException(nameof(entity));
            }

            var filter = filterBuilder.Eq(n => n.Id, entity.Id);
            await _dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(n => n.Id, id);
            await _dbCollection.DeleteOneAsync(filter);
        }
    }
}