using MongoDB.Driver;
using Catalog.API.Repositories;
using Common.SharedKernel.DatabaseProvider;
using Common.SharedKernel.Settings;

namespace Catalog.API.Config
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepository<T>(this IServiceCollection services, IMongoDbSettings mongoDbSettings)
            where T : IEntity
        {
            services.AddTransient<IRepository<T>>(serviceProvider =>
            {
                var db = serviceProvider.GetService<IMongoDatabase>();
                return new MongoDbRepository<T>(db, mongoDbSettings.CollectionName);
            });

            return services;
        }
    }
}